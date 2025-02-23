using UnityEngine;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 模糊shader提供器
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class BlurShaderProvider : MonoBehaviour
    {
        [SerializeField] protected Shader shader;
        [SerializeField] private float blurSize;
        [SerializeField] [Range(1, 8)] private int iterations;
        [SerializeField] [Range(0, 4)] private int kernel;
        
        private Material _blurMaterial = null;
        
        //private static readonly int BlurX = Shader.PropertyToID("_BlurX");
        //private static readonly int BlurY = Shader.PropertyToID("_BlurY");
        //private static readonly int Iterations = Shader.PropertyToID("_Iterations");
        private static readonly int Radius = Shader.PropertyToID("_Radius");

        public float BlurSize { get => blurSize; set => blurSize = value; }

        void OnEnable()
        {
            _blurMaterial = new Material(shader);
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (BlurSize < float.Epsilon)
            {
                Graphics.Blit(source, destination);
                return;
            }
            
            var rt2 = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

            for (int i = 0; i < iterations; i++)
            {
                // helps to achieve a larger blur
                float radius = (float)i * BlurSize + BlurSize;
                _blurMaterial.SetFloat(Radius, radius);

                Graphics.Blit(source, rt2, _blurMaterial, 1 + kernel);
                source.DiscardContents();

                // is it a last iteration? If so, then blit to destination
                if (i == iterations - 1)
                {
                    Graphics.Blit(rt2, destination, _blurMaterial, 2 + kernel);
                }
                else
                {
                    Graphics.Blit(rt2, source, _blurMaterial, 2 + kernel);
                    rt2.DiscardContents();
                }
            }

            RenderTexture.ReleaseTemporary(rt2);
        }
    }
}
