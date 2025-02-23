
using UnityEngine;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 数字错乱shader提供器
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class DigitalGlitchShaderProvider : ShaderProviderBase
    {
        [SerializeField, Range(0, 1)] private float intensity;

        private Texture2D _noiseTexture;
        private RenderTexture _trashFrame1;
        private RenderTexture _trashFrame2;
        private static readonly int Intensity = Shader.PropertyToID("_Intensity");
        private static readonly int NoiseTex = Shader.PropertyToID("_NoiseTex");
        private static readonly int TrashTex = Shader.PropertyToID("_TrashTex");

        static Color RandomColor()
        {
            return new Color(Random.value, Random.value, Random.value, Random.value);
        }

        protected override void Init()
        {
            mat.hideFlags = HideFlags.DontSave;

            _noiseTexture = new Texture2D(64, 32, TextureFormat.ARGB32, false);
            _noiseTexture.hideFlags = HideFlags.DontSave;
            _noiseTexture.wrapMode = TextureWrapMode.Clamp;
            _noiseTexture.filterMode = FilterMode.Point;

            _trashFrame1 = new RenderTexture(Screen.width, Screen.height, 0);
            _trashFrame2 = new RenderTexture(Screen.width, Screen.height, 0);
            _trashFrame1.hideFlags = HideFlags.DontSave;
            _trashFrame2.hideFlags = HideFlags.DontSave;

            UpdateNoiseTexture();
        }

        void UpdateNoiseTexture()
        {
            var color = RandomColor();

            for (var y = 0; y < _noiseTexture.height; y++)
            {
                for (var x = 0; x < _noiseTexture.width; x++)
                {
                    if (Random.value > 0.89f) color = RandomColor();
                    _noiseTexture.SetPixel(x, y, color);
                }
            }

            _noiseTexture.Apply();
        }
    
        void Update()
        {
            if (Random.value > Mathf.Lerp(0.9f, 0.5f, intensity))
            {
                UpdateNoiseTexture();
            }
        }

        protected override void BeforeRender()
        {
            var fcount = Time.frameCount;
            //if (fcount % 13 == 0) Graphics.Blit(source, _trashFrame1);
            //if (fcount % 73 == 0) Graphics.Blit(source, _trashFrame2);

            mat.SetFloat(Intensity, intensity);
            mat.SetTexture(NoiseTex, _noiseTexture);
            var trashFrame = Random.value > 0.5f ? _trashFrame1 : _trashFrame2;
            mat.SetTexture(TrashTex, trashFrame);

        }
    }
}