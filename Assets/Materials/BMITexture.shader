Shader "UI/BMI"
{
    Properties
    {
        _MainTex ("Texture 1", 2D) = "white" {}
        _SecondTex ("Texture 2", 2D) = "white" {}
        _Rotation1 ("Rotation 1 (Degrees)", Range(0,360)) = 0
        _Rotation2 ("Rotation 2 (Degrees)", Range(0,360)) = 0
        _Blend ("Blend Factor", Range(0,1)) = 0.5

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15

        _Fade ("Fade", Range(0,1)) = 1
        _MaskRadius ("Mask Radius", Range(0,1.5)) = 0.5
        _MaskBlur ("Mask Blur", Range(0,1)) = 0.1
        _MaskFlip ("Flip Mask", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Pass
        {
            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            Stencil
            {
                Ref [_Stencil]
                Comp [_StencilComp]
                Pass [_StencilOp]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            sampler2D _SecondTex;
            float4 _MainTex_ST;
            float4 _SecondTex_ST;
            float _Rotation1;
            float _Rotation2;
            float _Blend;
            float _Fade;
            float _MaskRadius;
            float _MaskBlur;
            float _MaskFlip;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float2 RotateUV(float2 uv, float angle)
            {
                float rad = radians(angle);
                float cosA = cos(rad);
                float sinA = sin(rad);
                float2 center = float2(0.5, 0.5);
                uv -= center;
                float2 rotatedUV = float2(
                    uv.x * cosA - uv.y * sinA,
                    uv.x * sinA + uv.y * cosA
                );
                return rotatedUV + center;
            }

            float CircularMask(float2 uv, float radius, float blur, float flip)
            {
                float2 pos = uv;
                float2 scale = float2(1920.0/1080,1);
                float2 center = float2(0.5, 0.5);
                pos = (pos - center) * scale + center;
                float dist = distance(pos, center);
                float mask = smoothstep(radius, radius - blur, dist);
                return flip > 0.5 ? 1.0 - mask : mask;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv1 = RotateUV(i.uv, _Rotation1);
                float2 uv2 = RotateUV(i.uv, _Rotation2);

                fixed4 tex1 = tex2D(_MainTex, uv1);
                fixed4 tex2 = tex2D(_SecondTex, uv2);
                fixed4 blendedColor = lerp(tex1, tex2, _Blend);

                float mask = CircularMask(i.uv, _MaskRadius, _MaskBlur, _MaskFlip);
                blendedColor.a *= mask * _Fade;

                return blendedColor;
            }
            ENDCG
        }
    }
    FallBack "UI/Default"
}
