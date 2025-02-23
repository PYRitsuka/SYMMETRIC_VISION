using Common;
using DG.Tweening;
using GamePlay.Story;
using Save;
using UnityEngine;
using UnityEngine.UI;
using UI.Story;
using Vector2 = UnityEngine.Vector2;
using GamePlay.StoryV2;
using Newtonsoft.Json;

namespace Utils.StoryScriptFunctions
{
    public class StoryBlockUIController : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private bool canInteract;
        [SerializeField] private CanvasGroup InfoCanvas;
        [SerializeField] public string jumpToStory;

        private Image _image;
        private FloatButton _button;

        private string filename;
        private bool markon = false;
        private Vector2 outlineposition;

        void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<FloatButton>();
            _button.onPointerEnter.AddListener(OnFloat);
            _button.onPointerExit.AddListener(OffFloat);
            _button.onClick.AddListener(OnClick);
        }
        
        void Start()
        {
            NoticeUpdate();
            // if(!markon)
            // {
            //     filename = ScriptResolver.ScriptFileName;
            //     MarkProgress();
            //     markon = true;
            // }
        }

        private void NoticeUpdate()
        {
            var unlocked =  GlobalSaveManager.HasIndexedSystemFlag("StoryBlock",id);
            _image.DOFade(unlocked ? 1 : 0, .01f);
            _button.interactable = canInteract && unlocked;
        }

        private void OnFloat()
        {
            if(_button.interactable)
            {
                Camera main;
                Vector2 mouse = (main = Camera.main).ScreenToViewportPoint(Input.mousePosition) * new Vector2(1920, 1080);
                Vector2 point = _button.GetComponent<RectTransform>().anchoredPosition;

                if (mouse.x > 960 && mouse.y > 540)
                {
                    InfoCanvas.GetComponent<RectTransform>().anchoredPosition = point + new Vector2(-2165, -765);
                }
                if (mouse.x < 960 && mouse.y > 540)
                {
                    InfoCanvas.GetComponent<RectTransform>().anchoredPosition = point + new Vector2(2165, -765);
                }
                if (mouse.x > 960 && mouse.y < 540)
                {
                    InfoCanvas.GetComponent<RectTransform>().anchoredPosition = point + new Vector2(-2165, 765);
                }
                if (mouse.x < 960 && mouse.y < 540)
                {
                    InfoCanvas.GetComponent<RectTransform>().anchoredPosition = point + new Vector2(2165, 765);
                }
                InfoCanvas.DOFade(1, .2f);
            }
        }

        private void OffFloat()
        {
            InfoCanvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100000, -100000);
        }

        private void OnClick()
        {
            //var asset = StoryUtils.LoadResource<TextAsset>($"脚本/{jumpToStory}");
            //ScriptResolver.ScriptFileName = jumpToStory;
            //ScriptResolver.ReloadScript(asset, null);
            //SceneTransit.Instance.TransitTo("StoryScene");
            if (jumpToStory == "") return;
            if (!jumpToStory.EndsWith("json")) {
                Debug.Log($"Invalid Script {jumpToStory}");
                return;
            }
            ScriptResolverV2.ScriptFileName = jumpToStory;
            _ = SceneTransit.Instance.TransitTo("StoryScene");
        }

        private void MarkProgress()
        {
            switch (filename)
            {
                case "V2/sv_01_01.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block001").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_01a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block001").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_02.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block002").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_03.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block003").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_03a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block003").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_04.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block004").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_04a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block004").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_04b.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block004").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_05.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block005").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_05a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block005").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_06.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block006").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_07.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block007").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_08.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block008").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_09.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block009").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_10.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block011").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_11.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block012").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_11a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block013").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_12.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block014").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_12a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block014").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_13.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block015").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_13a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block015").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_13b.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block015").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_14.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block016").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_15.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block017").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_16.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block018").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_17.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block019").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_17a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block019").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_18.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block020").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_19.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block021").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_20.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block022").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_20a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block023").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_21.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block024").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_22.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block025").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_22a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block027").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_23.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block028").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_23a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block028").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_23b.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block028").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_24.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block029").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block030").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block031").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25b.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block030").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25c.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block031").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25d.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block030").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25e.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block031").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25f.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block030").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25g.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block031").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_25h.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block030").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_26.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block032").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_26a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block033").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_27.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block035").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_28.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block036").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_29.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block037").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_29a.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block037").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_30.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block038").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_31.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block039").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_32.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block040").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_33.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block041").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
                case "V2/sv_01_34.json":
                    outlineposition = GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/block042").GetComponent<RectTransform>().anchoredPosition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree/Block/ProgressOutline").GetComponent<RectTransform>().anchoredPosition = outlineposition;
                    GameObject.Find("/Canvas/Scroll View/Viewport/Storytree").GetComponent<RectTransform>().anchoredPosition = new Vector2(-3596, -720) - outlineposition / 5;
                    break;
            }
        }
    }
}