using System.Collections.Generic;
using Common;
using DG.Tweening;
using UI.Common.ShaderProviders;
using GamePlay.Story;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using Utils;
using System.Threading;
using ScriptableObjects;
using GamePlay.Story.UI;

namespace UI.Title
{
    public class MenuManager : MonoBehaviourSingleton<MenuManager>
    {
        [SerializeField] private Animator uiAnimator;
        [SerializeField] private PostProcessVolume postProcess;
        [SerializeField] private PostProcessLayer postProcessLayer;
        [SerializeField] private AnalogGlitchShaderProvider postProcessGlitch;
        [SerializeField] private SceneBGMPlayer bgmPlayer;
        [SerializeField] private Image helpImage;

        [Space(10),Header("进入画面（login）"), SerializeField]
        private CanvasGroup loginCanvasGroup;
        [SerializeField] private List<Image> loginInformationList;
        [Space(10),SerializeField] private Image coverImage;
        [SerializeField] private CanvasGroup privacyPolicyCanvas;
        [SerializeField] private Button acceptButton, denyButton;
    
        private static readonly int IsClicked = Animator.StringToHash("IsClicked");
    
        
        
        private bool _isClicked;
        private bool _isAnimOver;
        private bool _isReadingHelp;
        private int _pointer = 0;
        private Tween _nowTween;

        void PlayClip(string clipName)
        {
            var clip = StoryUtils.LoadResource<AudioClip>($"SE/{clipName}");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.5f);
        }

        void Start()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
            QualitySettings.vSyncCount = 1; //开启垂直同步
            helpImage.sprite = UIModeController.Instance.GetCurrentUI().GetGameHelp();

            if (PlayerPrefs.GetInt("__pp_accepted__", 0) == 1)
            {
                Destroy(privacyPolicyCanvas.gameObject);
            }
            else
            {
                acceptButton.onClick.AddListener(() =>
                {
                    privacyPolicyCanvas.DOFade(0, .3f).OnComplete(() =>
                    {
                        PlayerPrefs.SetInt("__pp_accepted__", 1);
                        PlayerPrefs.Save();
                        Destroy(privacyPolicyCanvas.gameObject);
                        AnimationRoute();
                    });
                    
                });
                denyButton.onClick.AddListener(() =>
                {
                    Application.Quit(1);
                });
                return;
            }

            //设置动画
            AnimationRoute();
        }
    
        void Update()
        {
            if (_isReadingHelp)
            {
                if (Input.GetKeyDown(KeyCode.Escape)|| (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                {
                    ShowHelp(false);
                    PlayClip("退出界面.ogg");
                }

            }
            
            if ((Input.GetMouseButtonUp(0)||Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) && !_isClicked) //切换界面
            {
                if (!_isAnimOver)
                {
                    _nowTween?.Complete();//打断tween
                    return;
                }
                _isClicked = true;
                uiAnimator.SetBool(IsClicked, true);
                postProcess.gameObject.SetActive(true);
                postProcessLayer.enabled = true;
                DOTween.To(() => postProcess.weight, x => postProcess.weight = Mathf.Max(0, x - 1f), 2, 2f).onComplete += () => postProcessGlitch.enabled = true;
            }
        }

        public void ShowHelp()
        {
            ShowHelp(true);
        }

        void ShowHelp(bool isShow)
        {
            _isReadingHelp = isShow;
            helpImage.raycastTarget = isShow;
            helpImage.DOFade(isShow ? 1 : 0, .3f);
        }

        void AnimationRoute()
        {
            if (_isAnimOver)
            {
                return;
            }
            var tempVal = 0;
            _nowTween = DOTween.To(() => tempVal, x => tempVal = x, 1, 2f).OnComplete(() =>  //等两秒这麻烦
            { 
                _nowTween = loginInformationList[Mathf.Max(0, _pointer - 1)].DOFade(0, 1f).OnComplete(() =>  //逐渐离谱
                {
                    if (_pointer == 1)
                    {
                        bgmPlayer.enabled = true;
                    }
                    if (_pointer + 1 > loginInformationList.Count)
                    {
                        _nowTween = coverImage.DOFade(1, 1f).OnComplete(() =>
                        {
                            loginCanvasGroup.gameObject.SetActive(false);
                            _nowTween = coverImage.DOFade(0, 1f).OnComplete(() =>
                            {
                                
                                _isAnimOver = true;
                            });  //哈哈哈哈绑不住了这啥玩意儿
                        });
                    }
                    else
                    {
                        _nowTween = loginInformationList[_pointer++].DOFade(1, 1f).OnComplete(AnimationRoute);
                    }
                });
            });
        }
    }
}