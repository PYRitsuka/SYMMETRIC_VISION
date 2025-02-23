using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using UnityEngine.Video;
using System.Runtime.InteropServices;
using Constants;
using UI.Story;
namespace GamePlay.StoryV2.RecordsResolver
{
    public class CameraResolverV2 : MonoBehaviourSingleton<CameraResolverV2>
    {
        [SerializeField] private RawImage blindImage;
        [SerializeField] private RectTransform parentTransform;
        [SerializeField] private UGUIVideoPlayer video;
        [SerializeField] private RawImage upperEye;
        [SerializeField] private RawImage lowerEye;
        [SerializeField] private UGUIVideoPlayer speedLine;

        private ShakeManager shakeManager;
        Tween keepBumpy;

        void Start()
        {
            shakeManager = gameObject.AddComponent<ShakeManager>();
            shakeManager.rectTransform = parentTransform;
        }


        public Tween KeepBumpy(float duration, float strength)
        {
            var seq = DOTween.Sequence();
            var d = duration / 2.0f;
            var v = strength / 2.0f;
            seq.Append(parentTransform.DOAnchorPosY(-v, d));
            seq.Append(parentTransform.DOAnchorPosY(0, d));
            seq.Append(parentTransform.DOAnchorPosY(v, d));
            seq.Append(parentTransform.DOAnchorPosY(0, d));
            seq.SetAutoKill(false);
            seq.AllowMultipleCallback();
            seq.OnComplete(
                () => seq.Restart()
            );
            seq.OnKill(
                () => {parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, 0, parentTransform.localPosition.z);}
            );
            keepBumpy = seq;
            return seq;
        }

        public void StopBumpy()
        {
            if (keepBumpy != null)
            {
                keepBumpy.Kill(true);
                keepBumpy = null;
                Debug.Log("Í£Ö¹Õñ¶¯");
            }
        }

        public void StopAllActions()
        {
           StopBumpy();
        }

        public void  StopAction(string action) {
            switch (action) {
                case "ALL":
                case "":
                    StopAllActions();
                    break;
                case "Bumpy":
                    StopBumpy();
                    break;
                default:
                    break;
            }
        }

        public void Clear() {
            speedLine.SetAlpha(0);
            blindImage.color = new Color(1,1,1,0);
            shakeManager.SetShakeState(ShakeManager.ShakeState.None, false);
            upperEye.color = Color.clear;
            lowerEye.color = Color.clear;
        }
        public Tween PlayFX(string fx, float duration)
        {
            Tween animation;
            DG.Tweening.Sequence seq;
            switch (fx)
            {
                case "SpeedLineOn":
                    speedLine.SetAlpha(1);
                    return null;
                case "SpeedLineOff":
                    speedLine.SetAlpha(0);
                    return null;
                case "SparkingWhite":
                    if (duration > 0) {
                        animation = blindImage.DOFade(1, duration);
                        animation.OnKill(() => { animation.Complete(); });
                        return animation;
                    } else {
                        blindImage.color = new Color(1,1,1,1);
                        return null;
                    }
                case "WhiteRestore":
                    if (duration > 0) {
                        animation = blindImage.DOFade(0, duration);
                        animation.OnKill(() => { animation.Complete(); });
                        return animation;
                    } else {
                        blindImage.color = new Color(1,1,1,0);
                        return null;
                    }
                case "Shake_weak":
                    shakeManager.SetShakeState(ShakeManager.ShakeState.Weak, false);
                    return null;
                case "Shake_medium":
                    shakeManager.SetShakeState(ShakeManager.ShakeState.Medium, false);
                    return null;
                case "Shake_strong":
                    shakeManager.SetShakeState(ShakeManager.ShakeState.Strong, false);
                    return null;
                case "CloseEyes":
                    upperEye.color = Color.white;
                    lowerEye.color = Color.white;
                    upperEye.rectTransform.anchoredPosition = new Vector2(0, 700);
                    lowerEye.rectTransform.anchoredPosition = new Vector2(0, -700);
                    if (duration > 0) { 
                        seq = DOTween.Sequence();
                        seq.Insert(0, upperEye.rectTransform.DOAnchorPosY(0, duration));
                        seq.Insert(0, lowerEye.rectTransform.DOAnchorPosY(0, duration).OnComplete(delegate
                        {
                            upperEye.color = Color.clear;
                            lowerEye.color = Color.clear;
                        }));
                        seq.AllowMultipleCallback();
                        seq.OnKill(() => { seq.Complete(true); });
                        return seq;
                    } else {
                        upperEye.color = Color.clear;
                        lowerEye.color = Color.clear;
                        upperEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                        lowerEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                        return null;
                    }
                case "OpenEyes":
                    upperEye.color = Color.white;
                    lowerEye.color = Color.white;
                    upperEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                    lowerEye.rectTransform.anchoredPosition = new Vector2(0, 0);
                    if (duration > 0) {
                        seq = DOTween.Sequence();
                        seq.Insert(0, upperEye.rectTransform.DOAnchorPosY(700, duration));
                        seq.Insert(0, lowerEye.rectTransform.DOAnchorPosY(-700, duration).OnComplete(delegate
                        {
                            upperEye.color = Color.clear;
                            lowerEye.color = Color.clear;
                        }));
                        seq.AllowMultipleCallback();
                        seq.OnKill(() => { seq.Complete(true); });
                        return seq;
                    } else {
                        upperEye.color = Color.clear;
                        lowerEye.color = Color.clear;
                        upperEye.rectTransform.anchoredPosition = new Vector2(0, 700);
                        lowerEye.rectTransform.anchoredPosition = new Vector2(0, -700);
                        return null;
                    }


            }
            return null;
        }


    }
}