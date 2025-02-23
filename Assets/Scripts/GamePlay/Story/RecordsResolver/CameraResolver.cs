using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using UI.Story;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;
using Utils;

namespace GamePlay.Story.RecordsResolver
{
    public class CameraResolver : MonoBehaviourSingleton<CameraResolver>, IResolvable
    {
        [SerializeField] private RawImage blindImage;
        [SerializeField] private RectTransform parentTransform;
        [SerializeField] private UGUIVideoPlayer video;
        [SerializeField] private RawImage upperEye;
        [SerializeField] private RawImage lowerEye;
        
        private CameraFX _currentData;
        private UnityEvent _releaseAction = new();
        
        public void Resolve(object data)
        {
            _currentData = data as CameraFX;
            if (_currentData == null)
            {
                Debug.LogError("CameraFX操作数据读取失败");
                return;
            }
            
            ResolveFX(_currentData.EffectName);
        }


        void ResolveFX(string fx)
        {
            switch (fx.Split(';').FirstOrDefault())
            {
                case "恢复正常":
                    _releaseAction.Invoke();
                    _releaseAction = new UnityEvent();
                    break;
                case "屏幕闪白":
                    var d = fx.Split(';', StringSplitOptions.RemoveEmptyEntries).LastOrDefault().Trim().ToFloat();
                    blindImage.DOFade(1, d);
                    _releaseAction.AddListener(() => blindImage.color = new Color(0, 0, 0, 0));
                    ScriptResolver.WaitTime.Value = d;
                    break;
                case "闪白恢复":
                    d = fx.Split(';', StringSplitOptions.RemoveEmptyEntries).LastOrDefault().Trim().ToFloat();
                    blindImage.DOFade(0, d);
                    ScriptResolver.WaitTime.Value = d;
                    break;
                case "镜头抖动":
                    parentTransform.DOShakeAnchorPos(.5f, 10f, 10, 0, false, false);
                    ScriptResolver.WaitTime.Value = .5f;
                    break;
                case "镜头持续抖动":
                    var c = StartCoroutine(ShakeTransform());
                    _releaseAction.AddListener(() =>
                    {
                        StopCoroutine(c);
                        parentTransform.DOComplete();
                        parentTransform.anchoredPosition = Vector2.zero;
                    });
                    break;
                case "镜头持续缓慢抖动":
                    var f = StartCoroutine(ShakeTransformSlow());
                    _releaseAction.AddListener(() =>
                    {
                        StopCoroutine(f);
                        parentTransform.DOComplete();
                        parentTransform.anchoredPosition = Vector2.zero;
                    });
                    break;
                case "花屏":
                    video.SetAlpha(1);
                    video.PlayVideo();
                    video.JumpToFrame(0);
                    var t = (float)video.Length;
                    var noUse = 0;  
                    ScriptResolver.WaitTime.Value = t;
                    DOTween.To(() => noUse, (x) => noUse = x, 1, t).OnComplete(() =>
                    {
                        video.Reset();
                    });
                    break;
                case "闭眼效果":
                    upperEye.color = Color.white;
                    lowerEye.color = Color.white;
                    upperEye.rectTransform.anchoredPosition = new Vector2(0, 700);
                    lowerEye.rectTransform.anchoredPosition = new Vector2(0, -700);
                    upperEye.rectTransform.DOAnchorPosY(0, 1.5f);
                    lowerEye.rectTransform.DOAnchorPosY(0, 1.5f).OnComplete(delegate
                    {
                        upperEye.color = Color.clear;
                        lowerEye.color = Color.clear;
                    });
                    ScriptResolver.WaitTime.Value = 1.5f;
                    break;
                case "睁眼效果":
                    upperEye.color = Color.white;
                    lowerEye.color = Color.white;
                    upperEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                    lowerEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                    upperEye.rectTransform.DOAnchorPosY(700, 1.5f);
                    lowerEye.rectTransform.DOAnchorPosY(-700, 1.5f).OnComplete(delegate
                    {
                        upperEye.color = Color.clear;
                        lowerEye.color = Color.clear;
                    });
                    ScriptResolver.WaitTime.Value = 1.5f;
                    break;
            }
        }

        IEnumerator ShakeTransform()
        {
            const float v = 30f;
            const float d = 0.08f;
            while (true)
            {
                yield return parentTransform.DOAnchorPosY(-v, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(0, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(v, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(0, d).WaitForCompletion();
            }
        }
        IEnumerator ShakeTransformSlow()
        {
            const float v = 20f;
            const float d = 0.16f;
            while (true)
            {
                yield return parentTransform.DOAnchorPosY(-v, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(0, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(v, d).WaitForCompletion();
                yield return parentTransform.DOAnchorPosY(0, d).WaitForCompletion();
            }
        }
    }
}