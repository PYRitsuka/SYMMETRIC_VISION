using DG.Tweening;
using UnityEngine;

namespace UI.Base
{
    public class OpenCloseCanvasGroup : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvas;
        
        protected void OpenCanvasGroup()
        {
            canvas.DOFade(1, .3f);
            canvas.interactable = true;
            canvas.blocksRaycasts = true;
        }

        protected void CloseCanvasGroup()
        {
            canvas.DOFade(0, .3f).OnComplete(() =>
            {
                canvas.interactable = false;
                canvas.blocksRaycasts = false;
            });
        }
    }
    
    public abstract class ShowHideMonoBehaviour : MonoBehaviour
    {
        protected abstract void Show();

        protected abstract void Hide();
    }
}