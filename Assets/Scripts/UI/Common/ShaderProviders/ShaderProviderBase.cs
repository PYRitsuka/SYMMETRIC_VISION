using UnityEngine;

namespace UI.Common.ShaderProviders
{
    /// <summary>
    /// 所有shader提供器的爹
    /// </summary>
    [ExecuteInEditMode, ImageEffectAllowedInSceneView]
    public class ShaderProviderBase : MonoBehaviour
    {
        [SerializeField] protected Shader shader;
    
        protected Material mat = null;
        private void Start()
        {
            mat = new Material(shader);
            Init();
        }
    
        protected virtual void Init() { }

        protected virtual void BeforeRender() { }

        private void OnRenderImage (RenderTexture sourceTexture, RenderTexture destTexture)
        {
            if (mat == null)
                mat = new Material(shader);
            BeforeRender();
            Graphics.Blit(sourceTexture, destTexture, mat);
        }
    }
}
