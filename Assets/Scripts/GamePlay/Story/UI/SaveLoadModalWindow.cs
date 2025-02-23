using System.Collections.Generic;
using System.Threading.Tasks;
using Lean.Gui;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.UI
{
    public class SaveLoadModalWindow : MonoBehaviourSingleton<SaveLoadModalWindow>, IShowHide
    {
        [SerializeField] private LeanWindow window;
        [SerializeField] private Image dialogImage;
        [SerializeField] private Button confirmButton, cancelButton;
        [SerializeField] private List<Sprite> dialogSprites;
        [SerializeField] private List<Sprite> confirmSprites;
        [SerializeField] private List<Sprite> cancelSprites;
        
        public static bool IsOpen { get; private set; }
        public static bool IsConfirmed { get; private set; }

        void Start()
        {
            confirmButton.onClick.AddListener(delegate
            {
                SaveLoadUIManager.Instance.hasClick = true;
                IsConfirmed = true;
                Hide();
            });
            cancelButton.onClick.AddListener(delegate
            {
                SaveLoadUIManager.Instance.hasClick = true;
                IsConfirmed = false;
                Hide();
            });
        }
        
        public void Show()
        {
            if (IsOpen)
            {
                return;
            }
            IsConfirmed = false;
            dialogImage.sprite =
                dialogSprites[
                    UIModeController.Instance.GetCurrentUIIndex() + 
                    (SaveLoadUIManager.Instance.CurrentType == SaveLoadUIManager.SaveLoad.Save ? 0 : 6)];
            confirmButton.GetComponent<Image>().sprite = confirmSprites[UIModeController.Instance.GetCurrentUIIndex()];
            cancelButton.GetComponent<Image>().sprite = cancelSprites[UIModeController.Instance.GetCurrentUIIndex()];
            IsOpen = true;
            window.TurnOn();
        }

        public void Hide()
        {
            if (!IsOpen)
            {
                return;
            }
            window.TurnOff();
            IsOpen = false;
        }
    }
}