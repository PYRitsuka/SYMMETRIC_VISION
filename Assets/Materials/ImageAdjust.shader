Shader "Custom/ImageAdjust"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Brightness ("Brightness", Range(-1, 1)) = 0
        _Contrast ("Contrast", Range(0, 2)) = 1
        _Saturation ("Saturation", Range(0, 2)) = 1
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 100

        Pass
        {
            Cull Off
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            // Stencil operations for UI Mask
            // Stencil
            // {
            //     Ref 1
            //     Comp Equal
            //     Pass Keep
            //     Fail Keep
            //     ZFail Keep
            // }
            Stencil
            {
                Ref [_Stencil]
                Comp NotEqual
                Pass Keep
                Fail Keep
                ZFail Keep
                // ReadMask [_StencilReadMask]
                // WriteMask [_StencilWriteMask]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 texcoord : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float _Brightness;
            float _Contrast;
            float _Saturation;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // Transform vertex to clip space
                o.texcoord = v.texcoord;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.texcoord) * i.color; // Apply vertex color

                // Adjust brightness
                if (_Brightness > 0)
                {
                    color.rgb = lerp(color.rgb, float3(1.0, 1.0, 1.0), _Brightness);
                }
                else
                {
                    color.rgb = lerp(color.rgb, float3(0.0, 0.0, 0.0), -_Brightness);
                }

                // Adjust contrast
                color.rgb = ((color.rgb - 0.5) * max(_Contrast, 0)) + 0.5;

                // Adjust saturation
                float grey = dot(color.rgb, fixed3(0.299, 0.587, 0.114));
                color.rgb = lerp(grey, color.rgb, _Saturation);

                // Handle alpha properly
                color.a *= i.color.a;

                return color;
            }
            ENDCG
        }
    }
    FallBack "UI/Default"
}
