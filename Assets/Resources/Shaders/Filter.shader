Shader "Unlit/Filter"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Filter Color", Color) = (0, 0, 0, 1)
        _MainColor ("Main Color", Color) = (0, 0, 0, 1)
        _Amplifier ("Amplifier", Range(0, 5)) = 1
        _GreenToggle ("Is Greenscreen", Float) = 0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Cull Off
        ZTest Always
        ZWrite Off
        Blend One OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
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
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _MainColor;
            fixed _GreenToggle;
            float _Amplifier;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed diff = clamp(sqrt(pow(col.r - _Color.r, 2) + pow(col.g - _Color.g, 2) + pow(col.b - _Color.b, 2)) / sqrt(3) * _Amplifier,0,1);
                col.a = diff;
                if (_GreenToggle)
                {
                    col.g = (col.r + col.b) / 2;
                }
                col *= _MainColor;
                return col;
            }
            ENDCG
        }
    }
}
