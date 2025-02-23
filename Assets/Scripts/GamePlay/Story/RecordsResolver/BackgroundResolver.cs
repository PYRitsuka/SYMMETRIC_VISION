using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using GamePlay.Story.Record;
using UI.Story;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;
// using GamePlay.Story.Records.ResourceRecord;

namespace GamePlay.Story.RecordsResolver
{
    public class BackgroundResolver : MonoBehaviourSingleton<BackgroundResolver>, IResolvable
    {
        [SerializeField] private RawImage archetype;
        [SerializeField] private RawImage leftCover;
        [SerializeField] private RawImage rightCover;
        [SerializeField] private RawImage upCover;
        [SerializeField] private RawImage downCover;
        [SerializeField] private Image clockCover;
        [SerializeField] private UGUIVideoPlayer speedLine;

        private Background _currentData;
        private RawImage _selectedImage;
        private string _selectedImageName;
        private UnityEvent _disableFilterEvent = new();
        private readonly Dictionary<string, RawImage> _backgrounds = new();
        private static readonly int TransitTex = Shader.PropertyToID("_TransitTex");
        private static readonly int Progress = Shader.PropertyToID("_Progress");
        private static readonly int Alpha = Shader.PropertyToID("_Alpha");

        public static List<ResourceRecord> getResources(object data)
        {

            var resources = new List<ResourceRecord> ();
            var currData = data as Background;
            int idx = 0;
            if (currData.Operation == "创建图片") {
                idx  = 0;
            } else if (currData.Operation == "切换图片")  {
                idx  = 1;
            }
            else {
                return resources;
            }
            if (currData == null)
            {
                Debug.LogError("Error Preloading Background");
                return resources;
            }
            var list = currData.Pattern.SplitSemicolon();
            if (list.Count < 2)
            {
                Debug.LogError("Invalid create background command: " + currData.Pattern);
                return resources;
            }
            var backgroundPicture = list[idx];
            resources.Add( new ResourceRecord("Texture",$"背景/{backgroundPicture}"));
            return resources;
            
        }
        public void Resolve(object data)
        {
            _currentData = data as Background;
            if (_currentData == null)
            {
                Debug.LogError("背景操作数据读取失败");
                return;
            }

            switch (_currentData.Operation)
            {
                case "创建图片":
                    CreateBackground(_currentData.Pattern);
                    break;
                case "切换图片":
                    ChangeBackground(_currentData.Pattern);
                    break;
                case "选中图片":
                    _selectedImageName = _currentData.Pattern.SplitSemicolon().FirstOrDefault();
                    System.Diagnostics.Debug.Assert(_selectedImageName != null, nameof(_selectedImageName) + " != null");
                    _selectedImage = _backgrounds[_selectedImageName];
                    break;
                case "删除图片":
                    _selectedImageName = _currentData.Pattern.SplitSemicolon().FirstOrDefault();
                    _selectedImage = _backgrounds[_selectedImageName];
                    _backgrounds.Remove(_selectedImageName);
                    Destroy(_selectedImage.gameObject);
                    break;
                default:
                    Debug.LogError("Unknown background command: " + _currentData.Operation);
                    break;
            }

            TransitScale();
            TransitMove();
            Transition();
            Animate();
            ApplyFilter();
        }


        /// <summary>
        /// 十分生草的渐入渐出动画
        /// </summary>
        void Transition()
        {
            switch (_currentData.Transition)
            {
                case "淡入":
                    clockCover.fillAmount = 0;
                    _selectedImage.material.SetFloat(Alpha, 0);
                    _selectedImage.material.DOFloat(1, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 1;
                    break;
                case "淡出":
                    clockCover.fillAmount = 0;
                    _selectedImage.material.DOFloat(0, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 1;
                    break;
                case "快速淡入":
                    clockCover.fillAmount = 0;
                    _selectedImage.material.SetFloat(Alpha, 0);
                    _selectedImage.material.DOFloat(1, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0;
                    break;
                case "快速淡出":
                    clockCover.fillAmount = 0;
                    _selectedImage.material.DOFloat(0, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0;
                    break;
                case "上方推入":
                    _selectedImage.rectTransform.anchoredPosition = new Vector2(0, 200);
                    _selectedImage.rectTransform.DOAnchorPosY(0, 0.75f);
                    _selectedImage.material.DOFloat(1, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0.75f;
                    break;
                case "下方推入":
                    _selectedImage.rectTransform.anchoredPosition = new Vector2(0, -200);
                    _selectedImage.rectTransform.DOAnchorPosY(0, 0.75f);
                    _selectedImage.material.DOFloat(1, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0.75f;
                    break;
                case "上方推出":
                    _selectedImage.rectTransform.DOAnchorPosY(200, 0.75f);
                    _selectedImage.material.DOFloat(0, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0.75f;
                    break;
                case "上方快速推出":
                    _selectedImage.rectTransform.DOAnchorPosY(200, 0.3f);
                    _selectedImage.material.DOFloat(0, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0.3f;
                    break;
                case "下方推出":
                    _selectedImage.rectTransform.DOAnchorPosY(-200, 0.75f);
                    _selectedImage.material.DOFloat(0, Alpha, 1);
                    ScriptResolver.WaitTime.Value = 0.75f;
                    break;
                case "上方擦入":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    upCover.rectTransform.DOAnchorPosY(-1400, 0.5f);
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "下方擦入":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    downCover.rectTransform.DOAnchorPosY(1400, 0.5f);
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "上方擦除":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.DOAnchorPosY(0, 0.5f).OnComplete(() =>
                    {
                        upCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "下方擦除":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.DOAnchorPosY(-0, 0.5f).OnComplete(() =>
                    {
                        downCover.rectTransform.anchoredPosition = new Vector2(-2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "上方快速擦入":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    upCover.rectTransform.DOAnchorPosY(-1400, 0.25f);
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "上方瞬间擦入":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    upCover.rectTransform.DOAnchorPosY(-1400, 0.00f);
                    ScriptResolver.WaitTime.Value = 0.00f;
                    break;
                case "下方快速擦入":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    downCover.rectTransform.DOAnchorPosY(1400, 0.25f);
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "下方瞬间擦入":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                    downCover.rectTransform.DOAnchorPosY(1400, 0.00f);
                    ScriptResolver.WaitTime.Value = 0.00f;
                    break;
                case "上方快速擦除":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.DOAnchorPosY(0, 0.25f).OnComplete(() =>
                    {
                        upCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "上方瞬间擦除":
                    clockCover.fillAmount = 0;
                    upCover.rectTransform.DOAnchorPosY(0, 0.00f).OnComplete(() =>
                    {
                        upCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.00f;
                    break;
                case "下方快速擦除":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.DOAnchorPosY(-0, 0.25f).OnComplete(() =>
                    {
                        downCover.rectTransform.anchoredPosition = new Vector2(-2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "下方瞬间擦除":
                    clockCover.fillAmount = 0;
                    downCover.rectTransform.DOAnchorPosY(-0, 0.00f).OnComplete(() =>
                    {
                        downCover.rectTransform.anchoredPosition = new Vector2(-2200, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.00f;
                    break;
                case "左侧擦入":
                    clockCover.fillAmount = 0;
                    rightCover.rectTransform.anchoredPosition = new Vector2(-2200, 0);
                    rightCover.rectTransform.DOAnchorPosX(0, 0.5f);
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "右侧擦入":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                    leftCover.rectTransform.DOAnchorPosX(0, 0.5f);
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "左侧擦除":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.DOAnchorPosX(2200, 0.5f).OnComplete(() =>
                    {
                        leftCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "右侧擦除":
                    clockCover.fillAmount = 0;
                    rightCover.rectTransform.DOAnchorPosX(-2200, 0.5f).OnComplete(() =>
                    {
                        rightCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.5f;
                    break;
                case "左侧快速擦入":
                    clockCover.fillAmount = 0;
                    rightCover.rectTransform.anchoredPosition = new Vector2(-2200, 0);
                    rightCover.rectTransform.DOAnchorPosX(0, 0.25f);
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "右侧快速擦入":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                    leftCover.rectTransform.DOAnchorPosX(0, 0.25f);
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "右侧瞬间擦入":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.anchoredPosition = new Vector2(2200, 0);
                    leftCover.rectTransform.DOAnchorPosX(0, 0.01f);
                    ScriptResolver.WaitTime.Value = 0.01f;
                    break;
                case "左侧快速擦除":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.DOAnchorPosX(2200, 0.25f).OnComplete(() =>
                    {
                        leftCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "右侧快速擦除":
                    clockCover.fillAmount = 0;
                    rightCover.rectTransform.DOAnchorPosX(-2200, 0.25f).OnComplete(() =>
                    {
                        rightCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.25f;
                    break;
                case "右侧瞬间擦除":
                    clockCover.fillAmount = 0;
                    rightCover.rectTransform.DOAnchorPosX(-2200, 0.01f).OnComplete(() =>
                    {
                        rightCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 0.01f;
                    break;
                case "开门效果":
                    clockCover.fillAmount = 0;
                    leftCover.rectTransform.anchoredPosition = new Vector2(1200, 0);
                    rightCover.rectTransform.anchoredPosition = new Vector2(-1200, 0);
                    leftCover.rectTransform.DOAnchorPosX(0, 1.5f);
                    rightCover.rectTransform.DOAnchorPosX(0, 1.5f);
                    ScriptResolver.WaitTime.Value = 1.5f;
                    break;
                case "关门效果":
                    leftCover.rectTransform.DOAnchorPosX(1200, 1.5f);
                    rightCover.rectTransform.DOAnchorPosX(-1200, 1.5f).OnComplete(() =>
                    {
                        leftCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        rightCover.rectTransform.anchoredPosition = new Vector2(0, 0);
                        clockCover.fillAmount = 1;
                    });
                    ScriptResolver.WaitTime.Value = 1.5f;
                    break;
                case "时钟入场":
                    clockCover.fillAmount = 1;
                    clockCover.fillClockwise = false;
                    clockCover.DOFillAmount(0, 1);
                    ScriptResolver.WaitTime.Value = 1;
                    break;
                case "时钟离场":
                    clockCover.fillAmount = 0;
                    clockCover.fillClockwise = true;
                    clockCover.DOFillAmount(1, 1);
                    ScriptResolver.WaitTime.Value = 1;
                    break;
                case "":
                    break;
                default:
                    Debug.LogError("Invalid transition: " + _currentData.Transition);
                    break;
            }
        }

        void TransitScale()
        {
            if (!string.IsNullOrEmpty(_currentData.ScaleTransition))
            {
                var list = _currentData.ScaleTransition.SplitSemicolon();
                if (list.Count < 3)
                {
                    Debug.LogError("Invalid scale background command: " + _currentData.ScaleTransition);
                    return;
                }

                var duration = list[2].ToFloat();
                if (duration == 0)
                {
                    _selectedImage.rectTransform.localScale = Vector3.one * list[1].ToFloat();
                }
                else
                {
                    _selectedImage.rectTransform.localScale = Vector3.one * list[0].ToFloat();
                    var animation = _selectedImage.rectTransform.DOScale(Vector3.one * list[1].ToFloat(), duration);
                    DoNotInterruptIfNeeded(animation);
                }

                ScriptResolver.WaitTime.Value = duration;
            }
        }

        void TransitMove()
        {
            if (!string.IsNullOrEmpty(_currentData.MoveTransition))
            {
                var list = _currentData.MoveTransition.SplitSemicolon();
                if (list.Count < 5)
                {
                    Debug.LogError("Invalid move background command: " + _currentData.MoveTransition);
                    return;
                }

                var duration = list[4].ToFloat();
                if (duration == 0)
                {
                    _selectedImage.transform.localPosition = new Vector3(list[2].ToInt(), list[3].ToInt(), 1);
                }
                else
                {
                    _selectedImage.transform.localPosition = new Vector3(list[0].ToInt(), list[1].ToInt(), 1);
                    var animation = _selectedImage.transform.DOLocalMove(new Vector3(list[2].ToInt(), list[3].ToInt(), 1), duration);
                    DoNotInterruptIfNeeded(animation);
                }

                ScriptResolver.WaitTime.Value = duration;
            }
        }

        void DoNotInterruptIfNeeded(Tween animation) {
            if (!string.IsNullOrEmpty(_currentData.Animation))
            {
                if (_currentData.Animation =="持续运动" ) {
                    animation.SetId("Persistent");
                }
                
            }
        }

        void Animate()
        {
            if (!string.IsNullOrEmpty(_currentData.Animation))
            {
                if (_currentData.Animation=="抖动") {
                     _selectedImage.rectTransform.DOShakeAnchorPos(.5f, 20f, 20, 90f, false, false);
                    ScriptResolver.WaitTime.Value = .5f;
                } else if (_currentData.Animation.StartsWith("打断持续运动")) {
                        var args = _currentData.Animation.SplitSemicolon();
                        if (args.Count == 2) {
                            var duration = args[1].ToFloat();
                            ScriptResolver.CompleteTweennByFlagAsync(true,"Persistent",duration);
                            ScriptResolver.WaitTime.Value = duration;
                        } else {
                            Debug.Log("Invalid Format");
                        }
                        
                } else
                {
                  
                }
            }
        }

        void ApplyFilter()
        {
            switch (_currentData.Filter)
            {
                case "速度线":
                    speedLine.SetAlpha(1);
                    _disableFilterEvent.AddListener(() =>
                    {
                        speedLine.SetAlpha(0);
                    });
                    break;
                default:
                    _disableFilterEvent.Invoke();
                    _disableFilterEvent = new UnityEvent();
                    break;
            }
        }

        void CreateBackground(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 2)
            {
                Debug.LogError("Invalid create background command: " + pat);
                return;
            }
            var backgroundPicture = list[0];
            var backgroundName = list[1];
            if (!_backgrounds.ContainsKey(backgroundName))
            {
                var img = Instantiate(archetype, transform);
                img.texture = StoryUtils.LoadResource<Texture>($"背景/{backgroundPicture}");
                img.material = new Material(Shader.Find("Unlit/AlphaTransit"));
                img.gameObject.SetActive(true);
                _selectedImage = img;
                _selectedImageName = backgroundName;
                _backgrounds.Add(backgroundName, img);
            }
        }

        async void ChangeBackground(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError("Invalid change background command: " + pat);
                return;
            }
            var backgroundPicture = list[1];
            var backgroundName = list[0];
            if (!_backgrounds.ContainsKey(backgroundName))
            {
                Debug.LogError("Invalid picture indicator: " + backgroundName);
                return;
            }

            var img = _backgrounds[backgroundName];

            var tex = StoryUtils.LoadResource<Texture>($"背景/{backgroundPicture}");
            var duration = list[2].ToFloat();
            ScriptResolver.WaitTime.Value = duration;

            img.material.SetTexture(TransitTex, tex);
            await img.material.DOFloat(1, Progress, duration).AsyncWaitForCompletion();
            img.texture = tex;
            img.material.SetFloat(Progress, 0);
        }
    }
}
