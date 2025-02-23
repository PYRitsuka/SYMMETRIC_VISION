using GamePlay.Story.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class UIModeBindColor : MonoBehaviour
    {
        [SerializeField] private Graphic graphic;
        
        private void Start()
        {
            RefreshBind();
        }

        public void RefreshBind()
        {
            graphic.color = UIModeController.Instance.GetCurrentUI().GetMainColor();
        }
    }
}