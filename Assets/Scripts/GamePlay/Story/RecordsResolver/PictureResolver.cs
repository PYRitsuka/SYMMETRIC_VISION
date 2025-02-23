using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.UI;
using GamePlay.Story.Record;
using UI.Story;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils;

namespace GamePlay.Story.RecordsResolver
{
    public class PictureResolver : MonoBehaviourSingleton<PictureResolver>, IResolvable
    {
        [SerializeField] private RawImage pictureArchetype;
        [SerializeField] private UGUIVideoPlayer videoArchetype;
        [SerializeField] private CustomScrollView scrollViewArchetype;
        [SerializeField] private Image mask;
        
        private Record.UI _currentData;
        private string _selectedName;
        private bool _isSelectedPictureFrame;
        private Transform _selectedTransform;
        private readonly Dictionary<string, RawImage> _uiImages = new ();
        private readonly Dictionary<string, UGUIVideoPlayer> _uiVideos = new ();
        private readonly Dictionary<string, CustomScrollView> _uiFrames = new ();
        
        private const float AnimationDurationPerFrame = .05f;
        
        
        public static List<ResourceRecord> getResources(object data)
        {

            var resources = new List<ResourceRecord> ();
            var currData = data as Record.UI;
            if (currData == null)
            {
                Debug.LogError("Error Preloading Background");
                return resources;
            }
            if (currData.Operation== "创建图片") {
                var pat = currData.Pattern;
                var list = pat.SplitSemicolon();
                if (list.Count < 2)
                {
                    Debug.LogError($"Invalid create {GetFolderName()} command: " + pat);
                    return resources;
                }
                var uiPicture = list[0];
                var uiName = list[1];
                if (list[0].EndsWith(".mp4")) {
                    resources.Add( new ResourceRecord("VideoClip",$"{GetFolderName()}/{uiPicture}"));
                } else {
                    resources.Add( new ResourceRecord("Texture",$"{GetFolderName()}/{uiPicture}"));
                }
            } else if (currData.Operation == "播放动画") {
                var pat = currData.Pattern;
                var seq = pat.SplitSemicolon().FirstOrDefault()?.TrimStart('{').TrimEnd('}').Split(',')
                .Select(x => x.Trim()).ToList();
                if (seq == null)
                {
                    return resources;
                }
                var imageSequence = seq.ConvertAll(x => new ResourceRecord("Texture",$"{GetFolderName()}/{x}"));
                foreach (var q in imageSequence) {
                    resources.Add(q);
                }
            }
            
            return resources;
            
        }
        public void Resolve(object data)
        {
            _currentData = data as Record.UI;
            if (_currentData == null)
            {
                Debug.LogError($"{GetFolderName()}操作数据读取失败");
                return;
            }
            switch (_currentData.Operation)
            {
                case "创建图片":
                    CreateUI(_currentData.Pattern);
                    break;
                case "播放动画":
                    PlayAnimationSequence(_currentData.Pattern);
                    break;
                case "选中图片":
                    var n = _currentData.Pattern.SplitSemicolon().FirstOrDefault();
                    _selectedName = n;
                    _selectedTransform = _uiVideos.ContainsKey(n) ? _uiVideos[n].transform : (_uiImages.TryGetValue(n, out var image) ? image.transform : _uiFrames[n].transform);
                    //if (_uiFrames.ContainsKey(n))
                    //{
                    //    _isSelectedPictureFrame = true;
                    //}
                    _isSelectedPictureFrame = _uiFrames.ContainsKey(n);
                    break;
                case "删除图片":
                    DestroyUI(_currentData.Pattern.SplitSemicolon().FirstOrDefault());
                    break;
                case "创建可滚动图片":
                    CreateFrame(_currentData.Pattern);
                    break;
                default:
                    Debug.LogError("Unknown UI command: " + _currentData.Operation);
                    break;
            }
            
            TransitScale();
            TransitMove();
            TransitAlpha();
            CutInOut();
        }
        
        void TransitScale()
        {
            if (string.IsNullOrEmpty(_currentData.ScaleTransition))
            {
                return;
            }
            var list = _currentData.ScaleTransition.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError($"Invalid scale {GetFolderName()} command: " + _currentData.ScaleTransition);
                return;
            }

            var duration = list[2].ToFloat();
            if (duration == 0)
            {
                if (_isSelectedPictureFrame)
                {
                    _uiFrames[_selectedName].DOScale(list[0].ToFloat(), list[1].ToFloat(), duration);
                }
                else
                {
                    _selectedTransform.parent.localScale = Vector3.one * list[1].ToFloat();
                }
            }
            else
            {
                if (_isSelectedPictureFrame)
                {
                    _uiFrames[_selectedName].DOScale(list[0].ToFloat(), list[1].ToFloat(), duration);
                }
                else
                {
                    _selectedTransform.parent.localScale = Vector3.one * list[0].ToFloat();
                    _selectedTransform.parent.DOScale(Vector3.one * list[1].ToFloat(), duration);
                }
            }
                
            ScriptResolver.WaitTime.Value = duration;
        }
        
        void TransitMove()
        {
            if (string.IsNullOrEmpty(_currentData.MoveTransition))
            {
                return;
            }
            var list = _currentData.MoveTransition.SplitSemicolon();
            if (list.Count < 5)
            {
                Debug.LogError($"Invalid move {GetFolderName()} command: " + _currentData.MoveTransition);
                return;
            }

            var duration = list[4].ToFloat();
            if (duration == 0)
            {
                _selectedTransform.parent.localPosition = new Vector3(list[2].ToFloat(), list[3].ToFloat(), 1);
            }
            else
            {
                _selectedTransform.parent.localPosition = new Vector3(list[0].ToFloat(), list[1].ToFloat(), 1);
                _selectedTransform.parent.DOLocalMove(new Vector3(list[2].ToFloat(), list[3].ToFloat(), 1), duration);
            }
                
            ScriptResolver.WaitTime.Value = duration;
        }

        void TransitAlpha()
        {
            if (string.IsNullOrEmpty(_currentData.AlphaTransition))
            {
                return;
            }
            var img = _isSelectedPictureFrame ? _selectedTransform.GetComponent<CustomScrollView>().GetRawImageComponent() : _selectedTransform.GetComponent<RawImage>();
            var list = _currentData.AlphaTransition.SplitSemicolon();
            if (list.Count < 3)
            {
                Debug.LogError($"Invalid alpha {GetFolderName()} command: " + _currentData.AlphaTransition);
                return;
            }
            
            var duration = list[2].ToFloat();
            if (duration == 0)
            {
                img.color = new Color(1, 1, 1, list[1].ToFloat());
            }
            else
            {
                img.color = new Color(1, 1, 1, list[0].ToFloat());
                img.DOFade(list[1].ToFloat(), duration);
            }

            ScriptResolver.WaitTime.Value = duration;
        }

        void CutInOut()
        {
            if (string.IsNullOrEmpty(_currentData.CutInOutMode))
            {
                return;
            }
            
            var maskGo = _selectedTransform.transform.parent.GetComponent<RectTransform>();
            var pat = _currentData.CutInOutMode;
            var duration = pat.Split(';', StringSplitOptions.RemoveEmptyEntries).LastOrDefault().ToFloat();
            if (pat.Contains("纵向"))
            {
                if (pat.Contains("展开"))
                {
                    maskGo.sizeDelta = new Vector2(1920, 0);
                    maskGo.DOSizeDelta(new Vector2(1920, 1080), duration);
                }
                else
                {
                    maskGo.sizeDelta = new Vector2(1920, 1080);
                    maskGo.DOSizeDelta(new Vector2(1920, 0), duration);
                }
            }
            else
            {
                if (pat.Contains("展开"))
                {
                    maskGo.sizeDelta = new Vector2(0, 1080);
                    maskGo.DOSizeDelta(new Vector2(1920, 1080), duration);
                }
                else
                {
                    maskGo.sizeDelta = new Vector2(1920, 1080);
                    maskGo.DOSizeDelta(new Vector2(0, 1080), duration);
                }
            }
            ScriptResolver.WaitTime.Value = duration;
        }

        void PlayAnimationSequence(string pat)
        {
            var seq = pat.SplitSemicolon().FirstOrDefault()?.TrimStart('{').TrimEnd('}').Split(',')
                .Select(x => x.Trim()).ToList();
            if (seq == null)
            {
                return;
            }
            var imageSequence = seq.ConvertAll(x => StoryUtils.LoadResource<Texture>($"{GetFolderName()}/{x}"));
            var img = Instantiate(pictureArchetype, transform);
            _selectedTransform = img.transform;
            img.gameObject.SetActive(true);
            img.texture = imageSequence[0];
            var index = 0;
            var cnt = imageSequence.Count - 1;
            var duration = cnt * AnimationDurationPerFrame;
            ScriptResolver.WaitTime.Value = duration - 2 * AnimationDurationPerFrame; //为什么是2呢？小编也很好奇。   magic number罢了（（（
            DOTween.To(() => index, (x) =>
            {
                index = x;
                img.texture = imageSequence[index];
            }, cnt, duration).OnComplete(() => Destroy(img.gameObject));
        }
        
        void CreateUI(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 2)
            {
                Debug.LogError($"Invalid create {GetFolderName()} command: " + pat);
                return;
            }
            var uiPicture = list[0];
            var uiName = list[1];
            if (list[0].EndsWith(".mp4"))
            {
                if (_uiVideos.ContainsKey(uiName))
                {
                    return;
                }
                var videoPlayer = Instantiate(videoArchetype, transform);
                var maskGo = Instantiate(mask, transform);
                videoPlayer.transform.SetParent(maskGo.transform);
                videoPlayer.gameObject.SetActive(true);
                videoPlayer.PlayVideo(StoryUtils.LoadResource<VideoClip>($"{GetFolderName()}/{uiPicture}"));
                videoPlayer.SetLoop(list[2] == "循环");
                _selectedName = uiName;
                _selectedTransform = videoPlayer.transform;
                _uiVideos.Add(uiName, videoPlayer);
            }
            else
            {
                if (_uiImages.ContainsKey(uiName))
                {
                    return;
                }
                var img = Instantiate(pictureArchetype, transform);
                var maskGo = Instantiate(mask, transform);
                img.transform.SetParent(maskGo.transform);
                img.texture = StoryUtils.LoadResource<Texture>($"{GetFolderName()}/{uiPicture}");
                img.gameObject.SetActive(true);
                _selectedTransform = img.transform;
                _selectedName = uiName;
                _uiImages.Add(uiName, img);
            }
        }

        void CreateFrame(string pat)
        {
            var list = pat.SplitSemicolon();
            if (list.Count < 4)
            {
                Debug.LogError($"Invalid create {GetFolderName()} command: " + pat);
                return;
            }

            var uiPicture = list[0];
            var uiName = list[1];
            if (_uiFrames.ContainsKey(uiName))
            {
                return;
            }

            var scrollView = Instantiate(scrollViewArchetype, transform);
            var maskGo = Instantiate(mask, transform);
            scrollView.transform.SetParent(maskGo.transform);
            scrollView.gameObject.SetActive(true);
            scrollView.Setup(StoryUtils.LoadResource<Texture>($"{GetFolderName()}/{uiPicture}"), list[2].ToInt(), list[3].ToInt());
            _selectedName = uiName;
            _selectedTransform = scrollView.transform;
            _uiFrames.Add(uiName, scrollView);
            _isSelectedPictureFrame = true;
        }

        void DestroyUI(string destroyingName)
        {
            if (_uiVideos.ContainsKey(destroyingName))
            {
                _uiVideos[destroyingName].DestroyVideo();
                _uiVideos.Remove(destroyingName);
            }
            else if (_uiImages.ContainsKey(destroyingName))
            {
                Destroy(_uiImages[destroyingName].gameObject.transform.parent.gameObject);
                _uiImages.Remove(destroyingName);
            }
            else
            {
                Destroy(_uiFrames[destroyingName].gameObject.transform.parent.gameObject);
                _uiFrames.Remove(destroyingName);
            }
        }
        
        protected static string GetFolderName() => "图片";
    }
}

