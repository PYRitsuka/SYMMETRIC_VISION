Shader "Custom/RectangleMaskShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Rotation ("Rotation", Float) = 0.0
        _Center ("Center", Vector) = (0.5, 0.5, 0.0, 0.0)
        _AspectRatio ("Aspect Ratio", Float) = 1.0
        _Skew ("Skew", Vector) = (0.0, 0.0, 0.0, 0.0)
        _Scale ("Scale", Vector) = (1.0, 1.0, 0.0, 0.0)
        _ScaleMul ("Mul Scale", Float) = 1.0
        _Fade ("Fade", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Pass
        {
            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Rotation;
            float4 _Center;
            float _AspectRatio;
            float4 _Skew;
            float4 _Scale;
            float _ScaleMul;
            float _Fade;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float2 center = _Center.xy;
                float2 skew = _Skew.xy;
                float2 scale = _Scale.xy * _ScaleMul;
                float2 uv = i.uv - center;

                uv.x += skew.x * uv.y;
                uv.y += skew.y * uv.x;

                float s = sin(_Rotation);
                float c = cos(_Rotation);
                float2 rotatedUV = float2(c * uv.x - s * uv.y, s * uv.x + c * uv.y);

                rotatedUV /= scale;

                rotatedUV.x *= _AspectRatio;

                float2 finalUV = rotatedUV + center;
                half4 color = tex2D(_MainTex, i.uv); 

                if (abs(rotatedUV.x) > 0.5 || abs(rotatedUV.y) > 0.5)
                {
                    color.a = 0.0; 
                }

                color.a *= _Fade;

                return color;
            }
            ENDCG
        }
    }
}
