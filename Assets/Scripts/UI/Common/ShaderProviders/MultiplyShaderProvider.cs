
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 正片叠底shader提供器
    /// </summary>
    public class MultiplyShaderProvider : ShaderProviderBase
    {
        [SerializeField] private Texture2D multiplyTexture;
        private static readonly int BlendTex = Shader.PropertyToID("_BlendTex");
        private static readonly int Opacity = Shader.PropertyToID("_Opacity");

        protected override void Init()
        {
            mat.SetTexture(BlendTex, multiplyTexture);
            mat.SetFloat(Opacity, 1f);
        }
    }
}