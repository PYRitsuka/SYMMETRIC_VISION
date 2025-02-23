Shader "Unlit/Subtract" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0

		
		_BlendTex ("Blend Texture", 2D) = "white" {}
		_Opacity ("Blend Opacity", Range(0.0, 1.0)) = 1.0
		_Color ("Tint", Color) = (1,1,1,1)
	}
	SubShader {
		Tags 
		{
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

		Pass {
 			Cull Off
			Lighting Off
			ZWrite Off
			ZTest [unity_GUIZTestMode]
			Blend SrcAlpha OneMinusSrcAlpha


			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#pragma multi_compile_local _ UNITY_UI_CLIP_RECT
			#pragma multi_compile_local _ UNITY_UI_ALPHACLIP

			struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

			struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };
			
			uniform sampler2D _MainTex;
			uniform sampler2D _BlendTex;
			fixed _Opacity;
			fixed4 _Color;
			float4 _MainTex_ST;
			fixed4 _TextureSampleAdd;

			v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                OUT.color = v.color * _Color;
                return OUT;
            }
			
			fixed4 frag(v2f i) : COLOR
			{
				//Get the colors from the RenderTexture and the uv's
				//from the v2f_img struct
				half4 color = (tex2D(_MainTex, i.texcoord) + _TextureSampleAdd) * i.color;
				fixed4 blendTex = tex2D(_BlendTex, i.texcoord);
				float4 renderTex = color;
				// // Perform a subtract Blend mode
				fixed4 blendedMultiply = abs(blendTex - renderTex);

				blendedMultiply.a = renderTex.a;
				
				// // Adjust amount of Blend Mode with a lerp
				renderTex = lerp(renderTex, blendedMultiply,  _Opacity);

				// renderTex.a *= _Color.a;
				
				return renderTex;
			}
			
			ENDCG
		}
	}
	FallBack Off
}