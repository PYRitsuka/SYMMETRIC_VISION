using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePlay.StoryV2;
using Lean.Gui;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace UI.Settings
{
    public class SettingManager : MonoBehaviour
    {
        [SerializeField] private List<SettingPageControl> settingPages;
        [SerializeField] private Button backButton;
        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private LeanSwitch Menu;
        void PlayClip(string clipName)
        {
            var clip = StoryUtils.LoadResource<AudioClip>($"SE/{clipName}");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.5f);
        }

        public void ToggleGraphicSetting()
        {
            #if UNITY_ANDROID || UNITY_IPHONE
                Menu.State = 1;
            #else
                Menu.State = 2;
            #endif
        }


        private void Start()
        {
            canvasGroup.DOFade(1, .3f);
             if (ScriptResolverV2.Instance != null) {
                ScriptResolverV2.Instance.BlockExecution++;
             }
            backButton.onClick.AddListener(Exit);
        }

        private void Update()
        {
            if (StoryUtils.CheckUserCancelInput() || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.T))
            {
                Exit();
            }
        }

        private void Exit()
        {
            if (ScriptResolverV2.Instance != null) {
                ScriptResolverV2.Instance.BlockExecution--;
                ScriptResolverV2.Instance.hasClick=true;
            }

            PlayClip("退出界面.ogg");
            settingPages.ForEach(x => x.Save());
            canvasGroup.DOFade(0, .3f).OnComplete(delegate
            {
                SceneManager.UnloadSceneAsync("SettingsScene");
            });
        }
    }
}