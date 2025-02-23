using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using GamePlay.Story.UI;
using GamePlay.StoryV2;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace GamePlay.Story.Backlog
{
    public class BacklogManager : MonoBehaviourSingleton<BacklogManager>
    {
        [SerializeField] private Log logArchetype;
        [SerializeField] private RectTransform contentTransform;
        [SerializeField] private KeyCode enterKeyCode = KeyCode.Backspace;

        private CanvasGroup _canvasGroup;
        private int _logCount = 0;
        private readonly List<Log> _logs = new();
        private const float HeightPerLog = 230f;
        private string TextContant;

        public ScrollRect scrollRect;
        public float threshold = 0.01f; // Tolerance for being considered "at the bottom"


        public bool hasClick;

        public static bool IsReadingLogs { get; set; }

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
            return !IsReadingLogs && (Input.GetKeyDown(enterKeyCode) || Input.GetAxis("Mouse ScrollWheel") > 0f) && !ScriptResolverV2.IsBlocked();
        }

        public bool ShouldClose() {
            return (  StoryUtils.CheckUserCancelInput() || Input.GetKeyDown(enterKeyCode)) && IsReadingLogs ;
        }
        private bool IsScrollAtBottom()
        {
            return scrollRect.verticalNormalizedPosition <= threshold;
        }

        private void Update()
        {
            if (ShouldOpen())
            {
                // if (ScriptResolver.BlockExecution.Value != 0) return;
                Show();
                return;
            }
            if (IsReadingLogs && Input.GetAxis("Mouse ScrollWheel") < 0f && IsScrollAtBottom()) {
                 Hide();
                return;
            }
            if (!Input.anyKeyDown) return;

            if (hasClick) {
                hasClick = false;
                // Debug.Log("Skip Present!");
                return;
            }
            // if (ScriptResolver.IsPerforming) return;
            // if (!ScriptResolver.CanSkip.Value) return;
            if (ShouldOpen())
            {
                // if (ScriptResolver.BlockExecution.Value != 0) return;
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
            // if (ScriptResolver.IsPerforming) return;
            // if (!ScriptResolver.CanSkip.Value) return;
            // if (ScriptResolver.BlockExecution.Value != 0) return;
           
            if (GameObject.Find("/[Canvases][游戏主体部分]/文本框层").GetComponent<CanvasGroup>().alpha != 1) return;
            if (IsReadingLogs) return;
            ScriptResolverV2.Instance.BlockExecution++;
            gameObject.SetActive(true);

            //滚动到底部位置
            GameObject.Find("/[Canvases][游戏主体部分]/Backlog层/Backlog/Scroll View").GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 0);

            PlayClip("划入界面.ogg");
            // ScriptResolver.BlockExecution.Value++;
            IsReadingLogs = true;
            _canvasGroup.DOFade(1, .5f).OnComplete(delegate
            {
                _canvasGroup.blocksRaycasts = true;
            });
        }

        private void Hide()
        {
            // ScriptResolverV2.Instance.hasClick = true;
            
            ScriptResolverV2.Instance.rightMenuManager.hasClick = true;
            PlayClip("退出界面.ogg");
            _canvasGroup.blocksRaycasts = false;
            IsReadingLogs = false;
            _canvasGroup.DOFade(0, .5f).OnComplete(delegate
            {
                // ScriptResolver.BlockExecution.Value--;
                ScriptResolverV2.Instance.BlockExecution--;
                if (!IsReadingLogs) {
                    gameObject.SetActive(false);
                }
            });
        }

        public void AppendLog(string speaker, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }
            _logCount++;

            if (!string.IsNullOrEmpty(speaker))
            {
                TextContant = "<size=24>\n</size><size=42><b>" + speaker + "</size><size=12></b>" + "\n</size>　　";
                TextContant = TextContant + content + "\n";
            }
            else
            {
                TextContant = "<size=24>\n</size>";
                TextContant = TextContant + content + "\n";
            }
            GameObject.Find("/[Canvases][游戏主体部分]/Backlog层/Backlog/Scroll View/Viewport/Content").GetComponent<TextMeshProUGUI>().text += TextContant;
            //var log = Instantiate(logArchetype, contentTransform);
            //contentTransform.anchoredPosition = new Vector2(0, -940f);
            //log.SetContent(speaker, content);
            //_logs.Add(log);
            //Debug.Log($"{_logs.Count}");
            //if(_logs.Count>=50)
            //{
            //    _logs.RemoveAt(0);
            //}
        }

        public void ResetColor()
        {
            _logs.ForEach(x => x.ResetColor());
        }
    }
}