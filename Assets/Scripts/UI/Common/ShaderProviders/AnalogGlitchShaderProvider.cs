
using UnityEngine;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 模拟错乱shader提供器
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class AnalogGlitchShaderProvider : ShaderProviderBase
    {
        [SerializeField, Range(0, 1)] private float scanLineJitter;
        [SerializeField, Range(0, 1)] private float verticalJump;
        [SerializeField, Range(0, 1)] private float horizontalShake;
        [SerializeField, Range(0, 1)] private float colorDrift;
    
        private static readonly int ColorDrift = Shader.PropertyToID("_ColorDrift");
        private static readonly int ScanLineJitter = Shader.PropertyToID("_ScanLineJitter");
        private static readonly int VerticalJump = Shader.PropertyToID("_VerticalJump");
        private static readonly int HorizontalShake = Shader.PropertyToID("_HorizontalShake");
    
        private float _verticalJumpTime;

        protected override void BeforeRender()
        {
            _verticalJumpTime += Time.deltaTime * verticalJump * 11.3f;

            var sl_thresh = Mathf.Clamp01(1.0f - scanLineJitter * 1.2f);
            var sl_disp = 0.002f + Mathf.Pow(scanLineJitter, 3) * 0.05f;
            mat.SetVector(ScanLineJitter, new Vector2(sl_disp, sl_thresh));

            var vj = new Vector2(verticalJump, _verticalJumpTime);
            mat.SetVector(VerticalJump, vj);

            mat.SetFloat(HorizontalShake, horizontalShake * 0.2f);

            var cd = new Vector2(colorDrift * 0.04f, Time.time * 606.11f);
            mat.SetVector(ColorDrift, cd);

        }
    }
}