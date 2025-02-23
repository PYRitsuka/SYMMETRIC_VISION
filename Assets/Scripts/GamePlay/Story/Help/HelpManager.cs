using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GamePlay.Story.UI;
using GamePlay.StoryV2;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.Help
{
    public class HelpManager : MonoBehaviourSingleton<HelpManager>
    {
        [SerializeField] private KeyCode enterKeyCode = KeyCode.H;

        private CanvasGroup _canvasGroup;
        public bool hasClick;

        private static bool IsReadingHelp { get; set; }

        void PlayClip(string clipName)
        {
            var clip = StoryUtils.LoadResource<AudioClip>($"SE/{clipName}");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.5f);
        }

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public bool ShouldOpen() {
            var shouldOpen =  !IsReadingHelp && Input.GetKeyDown(enterKeyCode) && !ScriptResolverV2.IsBlocked();
            Debug.Log($"BackLogManager: Should Open {shouldOpen}");
            return shouldOpen;
        }

        public bool ShouldClose() {
            return (StoryUtils.CheckUserCancelInput() || Input.GetKeyDown(enterKeyCode) ||  Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) && IsReadingHelp ;
        }


        private void Update()
        {
            if (hasClick) {
                hasClick = false;
                return;
            }
            // do nothing
            if (IsReadingHelp) {
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
            if (ShouldOpen())
            {
                PlayClip("划入界面.ogg");
                Show();
                return;
            }

            if (TipPresenter.IsReadingTips) return;

            if (ShouldClose())
            {
                Hide();
                return;
            }
        }

        public void Show()
        {
            if (GameObject.Find("/[Canvases][游戏主体部分]/文本框层").GetComponent<CanvasGroup>().alpha != 1) return;
            if (IsReadingHelp) return;
            IsReadingHelp = true;
            hasClick = true;
            ScriptResolverV2.Instance.BlockExecution++;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.DOFade(1, .5f).OnComplete(delegate
            {
                
            });
        }
        
        private void Hide()
        {
            // ScriptResolverV2.Instance.hasClick = true;
            ScriptResolverV2.Instance.rightMenuManager.hasClick = true;
            ScriptResolverV2.Instance.BlockExecution--;
            PlayClip("退出界面.ogg");
            _canvasGroup.blocksRaycasts = false;
            IsReadingHelp = false;
            _canvasGroup.DOFade(0, .5f).OnComplete(()=>{});
        }
    }
}