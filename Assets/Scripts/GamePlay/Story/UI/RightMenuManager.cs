using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using Common;
using DG.Tweening;
using GamePlay.Story.Backlog;
using GamePlay.Story.Help;
using GamePlay.Story.RecordsResolver;
using GamePlay.StoryV2;
using Newtonsoft.Json;
using Save;
using Serializable;
using UI.Common.ShaderProviders;
using UI.Story;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using XPostProcessing;
using  GamePlay.StoryV2.RecordsResolver;
using Sequence = DG.Tweening.Sequence;
using Vector2 = UnityEngine.Vector2;

namespace GamePlay.Story.UI
{
    public class RightMenuManager : MonoBehaviour,IPointerClickHandler
    {
        // [SerializeField] private List<FloatButton> buttons;
        [SerializeField] private List<Image> options;
        [SerializeField] private Image tile;
        [SerializeField] private CanvasGroup rightClickMenuCanvas;
        [SerializeField] private CanvasGroup contentCanvas;
        [SerializeField] private Image dim;

        private SubtractShaderProvider _previous;
        private SelectionState _previousSelection;
        private BlurShaderProvider _blurShaderProvider;
        private bool _isOpened;
        private Sequence _animationSequence;
        public bool hasClick; // blocker from button

        public UnityEvent OnEnterMenu { get; } = new UnityEvent();
        public UnityEvent OnExitMenu { get; } = new UnityEvent();

        void Start()
        {
            for(var i = options.Count - 1; i >= 0; i--)
            {
                var b = options[i].GetComponent<Button>();
                Debug.Assert(b!=null);
                // Debug.Log($"DEBUGHHH: {b==null}");
                b.onClick.AddListener(OnClick);
            }
            _previous = options[0].GetComponent<SubtractShaderProvider>();
            _previousSelection = SelectionState.Save;
            _blurShaderProvider = ScriptResolver.Instance.GetBlurProvider();
            // OnEnterMenu.AddListener(OnEnter);
            // OnExitMenu.AddListener(OnExit);
            //MenuButton.onClick.AddListener(OnEnter);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick();
            hasClick = true;
        }

        int GetIndexUnderMouse() {
            var mouseY = Input.mousePosition.y;
            var (minDist,index) = options.Select((option,i)=>(Mathf.Abs(option.rectTransform.position.y -mouseY),i) ).Min();
            // Debug.Log($"Index:{index} {mouseY} {minDist}");
            return index;
        }
        // void Update()
        // {
        //     if (hasClick) {
        //         hasClick = false;
        //         return;
        //     }
        //     if (_isOpened && (Input.GetMouseButtonUp(0) ||( Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetMouseButtonUp(1) || Input.GetKeyDown(KeyCode.Escape)))
        //     {
        //         Hide();
        //         ScriptResolverV2.Instance.hasClick = true;
        //         return;
        //     }

        //     if (!_isOpened && Input.GetMouseButtonUp(1)|| Input.GetKeyDown(KeyCode.Escape)) //检测右键
        //     {
        //         Debug.Log($"RightClick Opened! {OnEnterMenu==null}");
        //         Show();
        //     }
        //     if (_isOpened) {
        //         var idx = GetIndexUnderMouse();
        //         OnSelect(idx);
        //     }

        // }

        private void OnSelect(int index)
        {
            if (_previousSelection == (SelectionState) index) {
                return;
            } 
            var i = options[index];
            Debug.Log($"Chose {(SelectionState)index}");
            tile.rectTransform.DOAnchorPosY(i.rectTransform.anchoredPosition.y, .3f);
            _previous.DOFade(0, .3f);
            var ssp = i.GetComponent<SubtractShaderProvider>();
            ssp.DOFade(1, .3f);
            _previous = ssp;
            _previousSelection = (SelectionState) index;
        }

        public void ToggleSave() {
            if (ScriptResolverV2.Instance.BlockExecution>0 || ScriptResolverV2.Instance.hasClick ) return;
            ScriptResolverV2.Instance.hasClick = true;
             SaveLoadUIManager.Instance.SetType(SaveLoadUIManager.SaveLoad.Save);
            SaveLoadUIManager.Instance.Show();
        }

        public void ToggleLoad() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.hasClick = true;
                        SaveLoadUIManager.Instance.SetType(SaveLoadUIManager.SaveLoad.Load);
                        SaveLoadUIManager.Instance.Show();
        }
        public void ToggleBacklog() {
            Debug.Log($"ToggleBackLog {ScriptResolverV2.Instance.BlockExecution}");
            if (ScriptResolverV2.Instance.BlockExecution>0 ) return;
            ScriptResolverV2.Instance.hasClick = true;
                      BacklogManager.Instance.Show();
        }

        public void ToggleTitle() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.hasClick = true;
               AudioResolverV2.Instance.StopManually();
                        SceneManager.UnloadSceneAsync("StoryScene");
                        SceneTransit.Instance.TransitTo("TitleScene");
        }

        public void ToggleStoryTree() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.hasClick = true;
            SceneManager.LoadScene("StorylineScene", LoadSceneMode.Additive);
        }

        public void ToggleHelp() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.hasClick = true;
           HelpManager.Instance.Show();
        }

        public void ToggleSetting() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.hasClick = true;
            SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
        }


        public void ToggleAuto() {
            if (ScriptResolverV2.Instance.BlockExecution>0) return;
            ScriptResolverV2.Instance.ToggleAuto(); 
        }
        private void OnClick()
        {
            Debug.Log("On click menu!");
            ScriptResolverV2.Instance.hasClick = true;
            hasClick = true;
            //Do something.
            switch (_previousSelection)
            {
                case SelectionState.Save:
                    Hide(ToggleSave);
                    break;
                case SelectionState.Load:
                    Hide(ToggleLoad);
                    break;
                case SelectionState.Backlog:
                    Hide(ToggleBacklog);
                    break;
                case SelectionState.Title:
                    Hide(ToggleTitle);
                    break;
                case SelectionState.StoryTree:
                    Hide(ToggleStoryTree);
                    break;
                case SelectionState.Help:
                    Hide(ToggleHelp);
                    break;
                case SelectionState.Settings:
                    Hide(ToggleSetting);
                    SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
                    break;
                default:
                    Debug.LogWarning("nah.");
                    break;
            }
        }

        void Show()
        {
            //MenuButton.enabled = false;
            // ScriptResolver.BlockExecution.Value++;
            ScriptResolverV2.Instance.BlockExecution++;
            rightClickMenuCanvas.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
            GetComponent<Image>().sprite = UIModeController.Instance.GetCurrentUI().GetContextMenu();
            _isOpened = true;
            _animationSequence = DOTween.Sequence();
            _animationSequence.Append(DOTween.To(() => _blurShaderProvider.BlurSize,
                (x) => _blurShaderProvider.BlurSize = x,
                1, .3f));
            _animationSequence.Insert(0, dim.DOFade(.4f, .3f));
            _animationSequence.Insert(0,rightClickMenuCanvas.DOFade(1, .3f));
            _animationSequence.AppendCallback(delegate { rightClickMenuCanvas.blocksRaycasts = true; ContentCanvas(true);});
            _animationSequence.OnComplete(
                ()=>_animationSequence = null
            );
            _animationSequence.OnKill(
                ()=>{_animationSequence.Complete(true);}
            );
            // _animationSequence.Play();
        }



        public void Hide(Action onComplete = null)
        {
            ScriptResolverV2.Instance.BlockExecution--;
            Debug.Log("Hide !!!!");
            if (_animationSequence != null) {
                _animationSequence.Kill(true);
            }
            ContentCanvas(false);
            rightClickMenuCanvas.blocksRaycasts = false;
            _isOpened = false;
            _animationSequence = DOTween.Sequence();
            _animationSequence.Insert(0,rightClickMenuCanvas.DOFade(0,.3f));
            _animationSequence.Insert(0,dim.DOFade(0.0f, .4f));
            _animationSequence.Append(DOTween.To(() => _blurShaderProvider.BlurSize,
                (x) => _blurShaderProvider.BlurSize = x,
                0, .3f));
            _animationSequence.OnComplete(
                ()=>{_animationSequence = null;}
            );
            _animationSequence.OnKill(
                ()=>{_animationSequence.Complete(true);}
            );
            if (onComplete != null) {
                onComplete();
            }
            
        }

        // private void QuickSave()
        // {
        //     var save = new StorySave
        //     {
        //         chapterNumber = ScriptResolverV2.ChapterNumber,
        //         chapterName = ScriptResolverV2.ChapterName,
        //         saveTime = DateTime.Now.ToString(SaveController.DateTimeFormat),
        //         scriptLine = ScriptResolverV2.ScriptLine,
        //         scriptName = ScriptResolverV2.ScriptFileName,
        //         text = TextResolver.CurrentText,
        //         uiMode = UIModeController.Instance.GetCurrentUIIndex(),
        //         userSelections = ScriptResolver.UserSelections,
        //     };
        //     SaveManager.Save(save, SaveManager.QuickSaveIndicator);
        // }

        // private void QuickLoad()
        // {
        //     var qSave = SaveManager.LoadSave(SaveManager.QuickSaveIndicator);
        //     if (qSave == null)
        //     {
        //         return;
        //     }
        //     var asset = StoryUtils.LoadResource<TextAsset>($"脚本/{qSave.scriptName}");
        //     //ScriptResolver.Instance.ResetStoryCanvas();
        //     ScriptResolver.ScriptFileName = qSave.scriptName;
        //     ScriptResolver.ReloadScript(asset,qSave.userSelections , qSave.scriptLine);
        //     SceneTransit.Instance.TransitTo("StoryScene");
        // }
        
        private void ContentCanvas(bool show)
        {
            contentCanvas.DOFade(Convert.ToInt32(show), .3f);
            contentCanvas.blocksRaycasts = show;
        }

        private void OnEnter()
        {
            //MenuButton.enabled = false;
            //将框体移到鼠标位置
            // Camera main;
            // Vector2 point = (main = Camera.main).ScreenToViewportPoint(Input.mousePosition) * new Vector2(1920, 1080);
            // rightClickMenuCanvas.GetComponent<RectTransform>().pivot =
            //     new Vector2(point.x >= 1420 ? 1 : 0, point.y <= 560 ? 0 : 1);
            // point.x += (UnityEngine.Screen.width / 2 - 960);
            // point.y += (UnityEngine.Screen.height / 2 - 540);
            // rightClickMenuCanvas.GetComponent<RectTransform>().anchoredPosition = point;
            // Show();
        }

        private void OnExit()
        {
            Hide();
        }

        private enum SelectionState
        {
            Save = 0,
            Load,
            StoryTree,
            Help,
            Backlog,
            Settings,
            Title
        }
    }
}
