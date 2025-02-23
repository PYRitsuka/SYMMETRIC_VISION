using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 差值shader提供器
    /// </summary>
    public class SubtractShaderProvider : ShaderProviderBase
    {
        [SerializeField] private Texture2D subtractTexture;
        [SerializeField, Range(0, 1)] private float percent;
        [SerializeField] private bool isForImage;
        private static readonly int BlendTex = Shader.PropertyToID("_BlendTex");
        private static readonly int Opacity = Shader.PropertyToID("_Opacity");

        protected override void Init()
        {
            mat.SetTexture(BlendTex, subtractTexture);
            mat.SetFloat(Opacity, percent);
            if (isForImage)
                GetComponent<Image>().material = mat;
        }

        public void DOFade(float alpha, float duration)
        {
            mat.DOFloat(alpha, Opacity, duration);
        }
    }
}