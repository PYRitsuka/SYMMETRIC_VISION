using System;
using GamePlay.Story.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class UIModeBindImage : MonoBehaviour
    {
        [SerializeField] private string uiName;
        [SerializeField] private Image image;

        private void Start()
        {
            RefreshBind();
        }

        public void RefreshBind()
        {
            image.sprite = UIModeController.GetCurrentUIElementByFieldName<Sprite>(uiName);
        }
    }
}