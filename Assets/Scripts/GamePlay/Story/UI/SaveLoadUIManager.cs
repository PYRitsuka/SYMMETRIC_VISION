using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePlay.Story.Backlog;
using GamePlay.StoryV2;
using Save;
using UI.Common.ShaderProviders;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;
using XPostProcessing;

namespace GamePlay.Story.UI
{
    public class SaveLoadUIManager : MonoBehaviourSingleton<SaveLoadUIManager>
    {
        [SerializeField] private KeyCode saveKeyCode = KeyCode.S;
        [SerializeField] private KeyCode loadKeyCode = KeyCode.L;
        [SerializeField] private Image frame;
        [SerializeField] private Image dim;
        [SerializeField] private Button exitButton;
        [SerializeField] private Transform content;
        [SerializeField] private SaveController saveArchetype;
        [SerializeField] private bool isTitle;

        [SerializeField] private RectTransform mouseBlockRegion;
        
        public bool hasClick;

        public bool hasClickConsistent;
        private BlurShaderProvider _blurShaderProvider;
        public bool _isOpened;
        private Sequence _animationSequence;
        private CanvasGroup _canvasGroup;
        private List<SaveController> _saves;
        public SaveLoad CurrentType { get; private set; }

        public void setisOpened(bool set)
        {
            _isOpened = set;
        }
        public bool getisOpened()
        {
            return _isOpened;
        }

        public void BlockClick() {
            Debug.Log("Save Load: Block One Click!");
            hasClickConsistent = true;
        }

        bool IsMouseOverUIElement(RectTransform rectTransform)
        {
            // Get the mouse position in screen space
            Vector2 mousePosition = Input.mousePosition;

            // Convert the screen space mouse position to local space within the RectTransform
            Vector2 localMousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, null, out localMousePosition);

            // Check if the local mouse position is within the bounds of the RectTransform
            return rectTransform.rect.Contains(localMousePosition);
        }
        public void BlockClickIfMouseDown() {
            if (Input.GetMouseButton(0) && IsMouseOverUIElement(mouseBlockRegion) ){
                            Debug.Log("Save Load: Block One Click!");
                hasClickConsistent = true;
            }

        }

        public void TryBockExitCick() {
         Debug.Log($"Mouse Down? {Input.GetMouseButtonDown(0)}");
            if (Input.GetMouseButton(0)) {
                hasClickConsistent = true;
            }
            
        }

        private void Start()
        {
            if (!isTitle) _blurShaderProvider = ScriptResolver.Instance.GetBlurProvider();
            _canvasGroup = GetComponent<CanvasGroup>();
            // exitButton.onClick.AddListener(delegate
            // {
            //     if (_isOpened)
            //     {
            //         Hide();
            //     }
            // });
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && hasClickConsistent) {
                hasClickConsistent = false;
                Debug.Log("SaveManager: Blocked for hasClickConsistent");
                return;
            }
            if (hasClick) {
                hasClick = false;
                Debug.Log("SaveManager: Blocked for hasClick");
                return;
            }
 
            if (_isOpened) {
                if (Input.GetMouseButtonUp(0) ||
                Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended
                )
                {
                    // ScriptResolverV2.Instance.hasClick = true;
                    Hide();
                    return;
                }  
            }
            if (!Input.anyKeyDown) return;

            if (isTitle)
            {
                if (_isOpened && (Input.GetKeyDown(KeyCode.Escape)||Input.GetMouseButton(1)))
                {
                    Hide();
                }
                return;
            }

            if (_isOpened)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(saveKeyCode) || Input.GetKeyDown(loadKeyCode) || Input.GetMouseButton(1)
                )
                {
                    Hide();
                    return;
                }  
            }
            if (!isTitle) {
                if (ScriptResolverV2.Instance.BlockExecution > 0) return;
                if (!ScriptResolverV2.Instance.CanSkip) return;
            }


            if (!_isOpened)
            {
                if (Input.GetKeyDown(saveKeyCode)&& !ScriptResolverV2.IsBlocked())
                {
                   // if (ScriptResolver.IsPerforming) ScriptResolver.Instance.InterruptPerforming();
                    SetType(SaveLoad.Save);
                    Show();
                    return;
                }

                if (Input.GetKeyDown(loadKeyCode)&& !ScriptResolverV2.IsBlocked())
                {
                   // if (ScriptResolver.IsPerforming) ScriptResolver.Instance.InterruptPerforming();
                    SetType(SaveLoad.Load);
                    Show();
                    return;
                }
            }
        }

        public void ReloadSaves()
        {
            for (var i = 0; i < content.childCount; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
            //Add user saves
            foreach (var s in SaveManager.LoadSaves())
            {
                var sc = Instantiate(saveArchetype, content);
                sc.Bind(s);
            }
            //Then add a blank save
            if (CurrentType == SaveLoad.Save)
            {
                Instantiate(saveArchetype, content);
            }
        }

        public void SetType(SaveLoad type)
        {
            CurrentType = type;
            frame.sprite = type == SaveLoad.Save
                ? UIModeController.Instance.GetCurrentUI().GetSaveFrame()
                : UIModeController.Instance.GetCurrentUI().GetLoadFrame();
        }
        public void SaveShow()
        {
            if (GameObject.Find("/[Canvases][游戏主体部分]/文本框层").GetComponent<CanvasGroup>().alpha != 1) return;
            Instance.SetType(SaveLoadUIManager.SaveLoad.Save);
            Instance.Show();
        }
        public void LoadShow()
        {
            if (GameObject.Find("/[Canvases][游戏主体部分]/文本框层").GetComponent<CanvasGroup>().alpha != 1) return;
            Instance.SetType(SaveLoadUIManager.SaveLoad.Load);
            Instance.Show();
        }

        public void Show()
        {
            if (_isOpened) {
                return;
            }
            hasClick = true;
            content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            if (!isTitle) {
                ScriptResolverV2.Instance.BlockExecution++;
            }
            ReloadSaves();
            _isOpened = true;
            _animationSequence = DOTween.Sequence();
            if (!isTitle) _animationSequence.Append(DOTween.To(() => _blurShaderProvider.BlurSize,
                (x) => _blurShaderProvider.BlurSize = x,
                1, .3f));
            _animationSequence.Insert(0, dim.DOFade(.4f, .3f));
            _animationSequence.Append(_canvasGroup.DOFade(1, .3f));
            _animationSequence.AppendCallback(delegate { _canvasGroup.blocksRaycasts = true; });
            _animationSequence.Play();
        }

        public void Hide(Action onComplete = null)
        {
            if (!_isOpened) {
                return;
            }
            _animationSequence.PlayBackwards();
            if (!isTitle) {
                ScriptResolverV2.Instance.BlockExecution--;
            }
            _isOpened = false;
            if (_animationSequence != null) {
                _animationSequence.Kill(true);
            }
            _canvasGroup.blocksRaycasts = false;

            _animationSequence = DOTween.Sequence();
            _animationSequence.Insert(0,_canvasGroup.DOFade(0,.3f));
            _animationSequence.Insert(0,dim.DOFade(0.0f, .4f));
            _animationSequence.Append(DOTween.To(() => _blurShaderProvider.BlurSize,
                (x) => _blurShaderProvider.BlurSize = x,
                0, .3f));
            _animationSequence.OnComplete(
                ()=>{_animationSequence = null; onComplete();}
            );
            _animationSequence.OnKill(
                ()=>{_animationSequence.Complete(true);}
            );
            SaveLoadModalWindow.Instance.Hide();
            // if (onComplete != null) {
            //     onComplete();
            // }
           
        }

        public enum SaveLoad
        {
            Save,
            Load
        }
    }
}