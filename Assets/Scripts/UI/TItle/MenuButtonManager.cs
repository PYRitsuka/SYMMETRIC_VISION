using System.Collections.Generic;
using Common;
using Constants;
using DG.Tweening;
using GamePlay.Story;
using GamePlay.StoryV2;
using GamePlay.Story.UI;
using Save;
using UI.Common.ShaderProviders;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
#if UNITY_EDITOR
using UnityEditor;
using System.Threading;
#endif

namespace UI.Title
{
    public class MenuButtonManager : MonoBehaviour
    {
        [SerializeField] private List<Button> buttons;
        [SerializeField] private List<Image> options;
        [SerializeField] private Image tile;

        private SubtractShaderProvider _previous;
        private SelectionState _previousSelection;
    
        void Start()
        {
            for(int i = buttons.Count - 1; i >= 0; i--)
            {
                Button b = buttons[i];
                Image option = options[i];
                var i1 = i;
                b.onClick.AddListener(delegate() { OnClick(i1, option); });
            }
            _previous = options[0].GetComponent<SubtractShaderProvider>();
            _previousSelection = SelectionState.Start;
        }

        private void OnClick(int index, Image i)
        {
#if UNITY_ANDROID || UNITY_IPHONE
            bool chooseOrSelect = true;
            _previousSelection = (SelectionState) index;
#else
            bool chooseOrSelect = index == (int) _previousSelection;
#endif
            Debug.Log($"{(chooseOrSelect ? "Chose" : "Selected")} {(SelectionState)index}");
            tile.rectTransform.DOAnchorPosY(i.rectTransform.anchoredPosition.y, .3f);
            _previous.DOFade(0, .3f);
            var ssp = i.GetComponent<SubtractShaderProvider>();
            ssp.DOFade(1, .3f);
            _previous = ssp;
            if (chooseOrSelect)
            {
                //Do some scene jumping.
                switch (_previousSelection)
                {
                    case SelectionState.Start:
                        //ScriptResolver.InitGraph();
                        // ScriptResolver.ReloadScript("程序,,串行,JumpToScript(Startup.txt);,", 1);
                        ScriptResolverV2.ScriptFileName = "脚本/V2/sv_00_00.json";
                        _ = SceneTransit.Instance.TransitTo("StoryScene");
                        break;
                    case SelectionState.Load:
                        if (SaveLoadUIManager.Instance.getisOpened())
                            break;
                        // SaveLoadUIManager.Instance.setisOpened(true);
                        SaveLoadUIManager.Instance.SetType(SaveLoadUIManager.SaveLoad.Load);
                        SaveLoadUIManager.Instance.Show();
                        //TipsUIManager.Instance.Open();
                        break;
                    case SelectionState.Continue:
                        GlobalSaveManager.LoadSave();
                        SceneManager.LoadScene("StorylineScene", LoadSceneMode.Additive);
                        break;
                    case SelectionState.Help:
                        MenuManager.Instance.ShowHelp();
                        break;
                    case SelectionState.Settings:
                        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
                        break;
                    case SelectionState.Sponsor:
                        Application.OpenURL("https://space.bilibili.com/2129725443?spm_id_from=333.1007.0.0");
                        break;
                    case SelectionState.Exit:
#if UNITY_EDITOR
                        EditorApplication.ExitPlaymode();
#else
                        Application.Quit(0);
#endif
                        break;
                    default:
                        Debug.LogWarning("Scene jumping is not supported rn.");
                        break;
                }
                return;
            }
            _previous = ssp;
            _previousSelection = (SelectionState) index;
        }
        
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
        //     ScriptResolver.ReloadScript(asset, qSave.userSelections, qSave.scriptLine);
        //     SceneTransit.Instance.TransitTo("StoryScene");
        // }

        private enum SelectionState
        {
            Start = 0,
            Load = 1,
            Continue = 2,
            Help = 3,
            Settings = 4,
            Sponsor = 5,
            Exit = 6
        }

    }
}