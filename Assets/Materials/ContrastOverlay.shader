Shader "UI/ContrastOverlay"
{
    Properties
    {
        _Contrast ("Contrast", Range(0.5, 3.0)) = 1.5
        _Fade ("Fade", Range(0,1)) = 1
        _MaskRadius ("Mask Radius", Range(0,1.5)) = 0.5
        _MaskBlur ("Mask Blur", Range(0,1)) = 0.1
        _MaskFlip ("Flip Mask", Float) = 0
    }
    
    SubShader
    {
        Tags { "Queue" = "Overlay" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
        GrabPass { "_GrabTexture" }

        Pass
        {
            Name "ContrastPass"
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off
            Lighting Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _GrabTexture;
            float _Contrast;
            float _MaskRadius;
            float _MaskBlur;
            float _MaskFlip;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // Calculate UV coordinates based on screen position
                o.uv = ComputeScreenPos(o.vertex).xy / ComputeScreenPos(o.vertex).w;
                return o;
            }

            float CircularMask(float2 uv, float radius, float blur, float flip)
            {
                float2 pos = uv;
                float aspectRatio = _ScreenParams.x / _ScreenParams.y;
                float2 scale;
                float cutoff = (1920.0/1080.0);
                if (aspectRatio > cutoff) {
                    scale = float2(aspectRatio,1);
                } else {
                    scale = cutoff * float2(1,1/aspectRatio);
                }
                 
                float2 center = float2(0.5, 0.5);
                pos = (pos - center) * scale + center;
                float dist = distance(pos, center);
                float mask = smoothstep(radius, radius - blur, dist);
                return flip > 0.5 ? 1.0 - mask : mask;
            }

            float4 frag (v2f i) : SV_Target
            {
                // Convert UV to screen space (0-1 range)
                float2 screenUV = i.uv;

                // Sample the grabbed texture in screen space
                float4 grabbed = tex2D(_GrabTexture, screenUV);

                // Apply contrast formula: result = (color - 0.5) * contrast + 0.5
                float3 modified = (grabbed.rgb - 0.5) * _Contrast + 0.5;
                float mask = CircularMask(i.uv, _MaskRadius, _MaskBlur, _MaskFlip);
                float3 output = grabbed.rgb * (1-mask) +  modified * mask;
                // Preserve the original alpha
                return float4(output, grabbed.a);
            }
            ENDCG
        }
    }
}
