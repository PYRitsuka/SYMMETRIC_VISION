Shader "UI/OverlayFadeShader"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _Blend ("Blend Factor", Range(0,1)) = 0.0
        _BlendColor ("Blend Color", Color) = (1,1,1,1)
        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _ColorMask ("Color Mask", Float) = 15

        _RGBMultiplier ("RGB Multiplier", Color) = (1,1,1,1)
        _Fade ("Fade", Range(0,1)) = 1
        _CropXMin ("Crop X Min", Range(0,1)) = 0.0
        _CropXMax ("Crop X Max", Range(0,1)) = 1.0
        _CropYMin ("Crop Y Min", Range(0,1)) = 0.0
        _CropYMax ("Crop Y Max", Range(0,1)) = 1.0
        _CropAngleMin ("Crop Angle Min", Range(0,360)) = 0.0
        _CropAngleMax ("Crop Angle Max", Range(0,360)) = 360.0
        _InvertMask ("Invert Mask", Float) = 0.0 // Boolean represented as float (0 or 1)

        _EdgeSoftness ("Edge Softness", Range(0,1)) = 0.1

        _GridSize  ("CALL_GridSize", Range(0,10)) = 1.15
        _StripeAlpha  ("CALL_StripeAlpha", Range(0,1)) = 0.189
        _StripeFreq ("CALL_StripeFreq", Range(0.1,1)) = 0.129
        _StripeSpeed ("CALL_StripeSpeed", Float) = 1.0
        _CallEnable ("CALL_CallEnable", Float) = 0
        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0

        _BlurStrength ("Blur Strength", Range(0, 1)) = 1.0
        _BlurSamples ("Blur Samples", Range(1, 4096)) = 400
        _BlurRadius  ("Blur Radius", Range(0, 100)) = 0.4
        _BlurScale  ("Blur Scale", Range(0, 1.0)) = 0.0
    }



    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull Off
        Lighting Off
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha
        ColorMask [_ColorMask]

        Pass
        {
            Name "Default"
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
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord  : TEXCOORD0;
                float4 worldPosition : TEXCOORD1;
                float2 uv : TEXCOORD0;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            fixed4 _Color;
            fixed4 _TextureSampleAdd;
            float4 _ClipRect;
            float4 _MainTex_ST;
            float4 _RGBMultiplier;
            float _Fade;
            float _CropXMin;
            float _CropXMax;
            float _CropYMin;
            float _CropYMax;
            float _CropAngleMin;
            float _CropAngleMax;
            float _InvertMask;
            float _EdgeSoftness;
            float _GridSize;
            float _StripeAlpha;
            float _StripeFreq;
            float _StripeSpeed;
            float _CallEnable;
            float _Blend;
            float4 _BlendColor;
            float _BlurStrength;
            float _BlurSamples;
            float _BlurRadius;
            float _BlurScale;

            v2f vert(appdata_t v)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);

                OUT.color = v.color * _Color;
                OUT.uv = v.uv;
                return OUT;
            }

            // half4 GaussianBlur(v2f i){
            //     half4 accumulator = 0.0;
            //     half weightSum = 0.0;
        
            //     for (int j = 0; j < _BlurSamples; j++)
            //     {
            //         // Generate random offset within the radius
            //         // Calculate deterministic offset in a circular pattern
            //         half angle = j * (6.2831853 / _BlurSamples); // Spread sample points evenly around a circle
            //         half radius = (j / (float)_BlurSamples) * _BlurRadius; // Gradual increase in radius
            //         half2 randomOffset = radius * half2(cos(angle), sin(angle));
                    
            //         // Sample texture at the offset
            //         half2 sampledUV = i.texcoord + randomOffset * _BlurScale;
            //         sampledUV = clamp(sampledUV, 0.0, 1.0);

            //         half4 sampleColor = tex2D(_MainTex, sampledUV);
        
            //         // Compute weight based on Gaussian distribution
            //         half weight = exp(-dot(randomOffset, randomOffset) / (_BlurRadius * _BlurRadius));
            //         accumulator += sampleColor * weight;
            //         weightSum += weight;
            //     }
            //     return accumulator / weightSum;
            // }
            half4 GaussianBlur(v2f i)
            {
                half4 accumulator = 0.0;
                half weightSum = 0.0;

                // Define grid size
                int gridSize = sqrt(_BlurSamples); // Total grid points per side (e.g., 5x5)
                half stepSize = 2.0 * _BlurRadius / (gridSize - 1); // Distance between grid points

                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        // Calculate offset
                        half2 offset = half2(x * stepSize - _BlurRadius, y * stepSize - _BlurRadius);

                        // Calculate UV coordinate with the offset
                        half2 sampledUV = i.texcoord + offset * _BlurScale / 10;

                        // Clamp UV coordinates to [0, 1] to stay within bounds
                        sampledUV = clamp(sampledUV, 0.0, 1.0);

                        // Sample texture at the clamped UV
                        half4 sampleColor = tex2D(_MainTex, sampledUV);

                        // Compute weight based on Gaussian distribution
                        half weight = exp(-dot(offset, offset) / (_BlurRadius * _BlurRadius));
                        accumulator += sampleColor * weight;
                        weightSum += weight;
                    }
                }

                // Normalize the accumulated color
                return accumulator / weightSum;
            }

            float fastSineTaylor(float x)
            {
                // Wrap input angle to [-π, π]
                x = x +  _Time.y * _StripeSpeed;
                x = fmod(x /_StripeFreq + + 3.14159265, 6.28318530) - 3.14159265;
                
                float x2 = x * x;
                return x * (1.0 - x2 / 6.0 + x2 * x2 / 120.0);
            }
            float3 colorDoge(float3 baseColor, float3 blendColor) {

                // Apply color dodge
                float3 resultColor = baseColor / (1.0 - blendColor);
                resultColor = saturate(resultColor); // Clamp to [0, 1]
                return resultColor;
            }
            float3 getRGBColor(float2 position, float gridSize)
            {
                // Calculate the grid position
                int2 gridPos = int2(position / gridSize);
                half sinwave = fastSineTaylor(gridPos.y);
                float3 gridColor;
                // Determine color based on grid position
                if ((gridPos.x % 3 == 0 && gridPos.y % 2 == 0) || (gridPos.x % 3 == 2 && gridPos.y % 2 == 1))
                    gridColor = float3(0.62, 0.5, 0.5); // Red
                else if ((gridPos.x % 3 == 1 && gridPos.y % 2 == 0) || (gridPos.x % 3 == 0 && gridPos.y % 2 == 1))
                    gridColor = float3(0.5, 0.62,0.5); // Green
                else
                    gridColor = float3(0.5, 0.5, 0.62); // Blue
                gridColor = gridColor * (sinwave-1) * _StripeAlpha + gridColor ;
                gridColor = colorDoge(gridColor,float3(.1,.2,0.5));
                gridColor = gridColor * 1.0;
                gridColor = saturate(gridColor);
                return gridColor;
                // Add Stripe

            }



            fixed4 frag(v2f IN) : SV_Target
            {
                float2 screenPos = IN.vertex.xy / float2(_ScreenParams.x, -_ScreenParams.y) * 0.5 + 0.5;
                screenPos.y = 1.0 - screenPos.y;
                float3 colorGrid3 = getRGBColor(screenPos * _ScreenParams.xy, _GridSize);
                half4 colorGrid = float4(colorGrid3, 1.0);
                half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;
                // Blur

                    // Apply blur
                float2 blurOffsets[9] = {
                    float2(-1, -1), float2(0, -1), float2(1, -1),
                    float2(-1, 0),  float2(0, 0),  float2(1, 0),
                    float2(-1, 1),  float2(0, 1),  float2(1, 1)
                };
                // float blurFactor = _BlurStrength / 9.0;
                if (_BlurScale > 0) {
                    fixed4 blurredColor = GaussianBlur(IN);
                    color.rgb = lerp(color.rgb, blurredColor.rgb, _BlurStrength);
                }


                // Calculate distance from center
                float2 center = float2(0.5, 0.5); // Assuming center of the texture is at (0.5, 0.5)
                float2 fromCenter = IN.uv - center;
                float radiusAngle = atan2(fromCenter.y, fromCenter.x) * (180.0 / 3.14159265358979323846) + 180;
                float toDiscard = _InvertMask;

                // Soft edge calculation
                float edgeAlpha = 1.0;
                float softness = max(_EdgeSoftness,1e-3);
                float factor =   1.0 / (1.0 + 2 * softness);
                float centeredX = (IN.uv.x - 0.5) * factor + 0.5;
                float centeredY = (IN.uv.y - 0.5) * factor + 0.5;
                if (centeredX < _CropXMin)
                    edgeAlpha *= smoothstep(_CropXMin - softness, _CropXMin, centeredX);
                if (centeredX > _CropXMax)
                    edgeAlpha *= smoothstep(_CropXMax + softness, _CropXMax, centeredX);

                if (centeredY < _CropYMin)
                    edgeAlpha *= min(edgeAlpha, smoothstep(_CropYMin - softness, _CropYMin, centeredY));
                if (centeredY > _CropYMax)
                    edgeAlpha *= min(edgeAlpha, smoothstep(_CropYMax + softness, _CropYMax, centeredY));

                if (radiusAngle < _CropAngleMin)
                    edgeAlpha *= min(edgeAlpha, smoothstep(_CropAngleMin - softness * 360.0, _CropAngleMin, radiusAngle));
                if (radiusAngle > _CropAngleMax)
                    edgeAlpha *= min(edgeAlpha, smoothstep(_CropAngleMax + softness * 360.0, _CropAngleMax, radiusAngle));

                // Apply cropping based on properties
                // if (centeredX < _CropXMin || centeredX > _CropXMax || centeredY < _CropYMin || centeredY > _CropYMax ||
                //     radiusAngle < _CropAngleMin || radiusAngle > _CropAngleMax)
                // {
                //     toDiscard = 1 - toDiscard; // Discard pixel outside crop region
                // } 

                // if (toDiscard) 
                // {
                //     color.a = 0.000;
                // } 
                // else 
                // {
                //     color.a *= edgeAlpha;
                // }
                if (toDiscard == 1){
                    edgeAlpha = 1- edgeAlpha;
                }
                color.a *= edgeAlpha;
                color.rgb *= _RGBMultiplier.rgb;
                color.a *= _Fade;
                if (_CallEnable) {
                    color.rgb = 0.3 * color.rgb + 0.7 * color.rgb * colorGrid.rgb ; // Overlay
                }
                if (_Blend > 0) {
                    color.rgb = lerp(color.rgb,_BlendColor.rgb,_Blend);
                }
                

                #ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif

                #ifdef UNITY_UI_ALPHACLIP
                clip (color.a - 0.001);
                #endif
                

                return color;
            }
            ENDCG
        }
    }
}