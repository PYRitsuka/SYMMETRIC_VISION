using System;
using System.Collections.Generic;

using DG.Tweening;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;
using Utils;

namespace GamePlay.StoryV2.RecordsResolver
{
    public class ImageAnimationHandler : MonoBehaviour
    {
        
        private Tween keepMove;

        public Mask mask;

        public ShakeManager shakeManager;
        

        public RawImage contentImage;

        public static bool scrollable = false;
        [Range(0.0f, 1.0f)]
        public float alpha;

        // public Tween imageSeqAnimation;

        public virtual void Init() {
            contentImage = this.GameObject().GetComponent<RawImage>();
            if (contentImage == null) {
                Debug.LogError("Warning: Content is Null");
            }
            shakeManager = this.GameObject().AddComponent<ShakeManager>();
            shakeManager.rectTransform =  GetFrameImage().rectTransform;
        }
        public virtual RawImage GetContentImage() {
            return contentImage;
        }
        public virtual RawImage GetFrameImage() {
            return contentImage;
        }

        public virtual Material GetEffectMaterial() {
            return contentImage.material;
        }

        public virtual void SetAlpha(float x) {
            alpha= x;
            GetContentImage()?.material.SetFloat("_Fade", x);
        }

        public void SetShakeState(string state, bool loop) {
             shakeManager.SetShakeState(state,loop);
        }

        public void SetKeepMove(
            Vector2 pos1,
            float scale1,
            float angle1, float duration, string curve = "uniform",
            float alpha1 = -1,
            float alphaTime = 0
         )
        {
            StopMove();
            pos1 = pos1 + Vector2.zero; // copy vectors
            var img = GetFrameImage();
            if (img != null)
            {
                var seq = DOTween.Sequence();
                var hasAnimation = false;
                if (duration > 0) {
                    var animationPos = SVAnimator.DoMoveCurve(
                            curve, img.rectTransform,
                            pos1,
                            duration,
                            autoKill: false
                    );
                    var animationScale = SVAnimator.DoScaleCurve(
                            curve, img.rectTransform,
                            Vector3.one * scale1,
                            duration,
                            autoKill: false
                    );
                    var animationRotation = SVAnimator.DoRotationCurve(
                        curve, img.rectTransform,
                        angle1,
                        duration,
                        autoKill: false
                    );
                    seq.Insert(0, animationPos);
                    seq.Insert(0, animationScale);
                    seq.Insert(0, animationRotation);
                    hasAnimation = true;
                } else {
                    img.rectTransform.localPosition =  new Vector3(pos1.x,pos1.y,1);
                    img.rectTransform.localScale = Vector3.one * scale1;
                    img.rectTransform.localRotation = Quaternion.Euler(0, 0,angle1);
                }


                if (alpha1 >= 0) {
                    if (alphaTime > 0) {
                        var animationAlpha = DOVirtual.Float(alpha,alpha1,alphaTime,(v)=>SetAlpha(v));
                        seq.Insert(0, animationAlpha);
                        hasAnimation = true;
                    } else {
                        SetAlpha(alpha1);
                    }
                }
                if (hasAnimation) {
                    keepMove = seq;
                }
                

            }

        }
        public void StopMove()
        {
            if (keepMove != null)
            {
                keepMove.Pause();
                keepMove.Kill();

            }

        }

        public Tween PlayVideo(VideoClip clip, bool loop = false, float volume = 1)
        {
            var img = GetContentImage();
            if (img == null)
            {
                return null;
            }
            var videoPlayer = this.GameObject().GetComponent<VideoPlayer>();

            if (videoPlayer == null)
            {
                videoPlayer = this.GameObject().AddComponent<VideoPlayer>();

            }
            videoPlayer.clip = clip;
            videoPlayer.renderMode = VideoRenderMode.APIOnly;
            videoPlayer.isLooping = loop;
            videoPlayer.Prepare();
            videoPlayer.SetDirectAudioVolume(0,
            volume * PlayerPrefs.GetFloat("videoVolume", Constants.SettingsConstants.VideoVolume));
            videoPlayer.Play();
            videoPlayer.prepareCompleted += delegate
            {
                img.color = Color.white;
                img.texture = videoPlayer.texture;
            };

            // blocking
            if (!loop)
            {
                var videoLength = videoPlayer.clip.length;
                var dummyTween = DOVirtual.DelayedCall((float)videoLength, () => { });
                dummyTween.Pause(); // never do anything untill
                videoPlayer.prepareCompleted += delegate
                {
                    dummyTween.Play();
                };
                dummyTween.AllowMultipleCallback();
                dummyTween.OnComplete(
                    () =>
                    {
                        Debug.Log("OnCompleteCallBack!");
                        videoPlayer.Stop();
                    }
                );
                dummyTween.OnKill(
                    () =>
                    {
                        dummyTween.Complete(true);
                    }
                );
                return dummyTween;
            }

            return null;
        }

        public Tween PlayImageSequence(List<Texture> frames, bool loop = false, float speed = 20)
        {
            //
            var img = GetContentImage();
            if (img == null)
            {
                return null;
            }
            var time_per_frame = 1.0f / speed;
            var cnt = frames.Count - 1;
            var duration = cnt * time_per_frame;
            var animation = DOVirtual.Int(0, cnt, duration, (index) =>
            {
                img.texture = frames[index];
            });
            animation.AllowMultipleCallback();
            if (!loop)
            {
                animation.OnKill(
                    () => { animation.Complete(true); }
                );
                return animation;
            }
            else
            {
                animation.OnComplete(
                    () => { PlayImageSequence(frames, loop, speed); } // Not Tested!
                );
                return null;

            }


        }

        public static void SetMaterialEffect(Material material,
        float[] parms
        )
        {
            material.SetFloat("_CropXMin", parms[0]);
            material.SetFloat("_CropXMax", parms[1]);
            material.SetFloat("_CropYMin", parms[2]);
            material.SetFloat("_CropYMax", parms[3]);
            material.SetFloat("_CropAngleMin", parms[4]);
            material.SetFloat("_CropAngleMax", parms[5]);
            material.SetFloat("_InvertMask", parms[6]);
        }

        public static void ResetMaterialEffect(Material material)
        {
            var start = new float[7] { 0, 1, 0, 1, 0, 360, 0 };
            SetMaterialEffect(material, start);
        }

        static float[] InterpolateArrays(float[] array1, float[] array2, float t)
        {
            if (array1.Length != 7 || array2.Length != 7)
            {
                throw new ArgumentException("Arrays must have exactly 6 elements.");
            }

            float[] result = new float[7];

            for (int i = 0; i < 7; i++)
            {
                result[i] = Mathf.Lerp(array1[i], array2[i], t);
            }

            return result;
        }

        public Tween PlayMaterialEffect(Material material, string type, float duration,Action onUpdate = null )
        {
            SetAlpha(1);
            if (onUpdate == null) {
                onUpdate = ()=>{};
            } // on update may be used to fix a material bug of scrollview where we need to notify maskutility
            Tween animation;
            float[] start;
            float[] end;
            float[] stateOpen = new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 0, 360, 0 };
            string final_callback;
            float edge_softness = 0.15f;
            switch (type)
            {
                case "ExpandIn_horizontal":
                    start = new float[7] { 0.5f+edge_softness, 0.5f-edge_softness, 0.0f, 1.0f, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "ExpandIn_vertical":
                    start = new float[7] { 0.0f, 1.0f, 0.5f+edge_softness, 0.5f-edge_softness, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "ExpandOut_horizontal":
                    end = new float[7] { 0.5f+edge_softness, 0.5f-edge_softness, 0.0f, 1.0f, 0, 360, 0 };
                    start = stateOpen;
                    final_callback = "out";
                    break;
                case "ExpandOut_vertical":
                    end = new float[7] { 0.0f, 1.0f, 0.5f+edge_softness, 0.5f-edge_softness, 0, 360, 0 };
                    start = stateOpen;
                    final_callback = "out";
                    break;
                case "CoveringIn_up":
                    start = new float[7] { 0.0f, 1.0f, 1.0f, 1.0f, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "CoveringIn_down":
                    start = new float[7] { 0.0f, 1.0f, 0.0f, 0.0f, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "CoveringIn_left":
                    start = new float[7] { 0.0f, 0.0f, 0.0f, 1.0f, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "CoveringIn_right":
                    start = new float[7] { 1.0f, 1.0f, 0.0f, 1.0f, 0, 360, 0 };
                    end = stateOpen;
                    final_callback = "in";
                    break;
                case "CoveringOut_up":
                    start = stateOpen;
                    end = new float[7] { 0.0f, 1.0f, 1.0f, 1.0f, 0, 360, 0 };
                    final_callback = "out";
                    break;
                case "CoveringOut_down":
                    start = stateOpen;
                    end = new float[7] { 0.0f, 1.0f, 0.0f, 0.0f, 0, 360, 0 };
                    final_callback = "out";
                    break;
                case "CoveringOut_left":
                    end = new float[7] { 0.0f, 0.0f, 0.0f, 1.0f, 0, 360, 0 };
                    start = stateOpen;
                    final_callback = "out";
                    break;
                case "CoveringOut_right":
                    end = new float[7] { 1.0f, 1.0f, 0.0f, 1.0f, 0, 360, 0 };
                    start = stateOpen;
                    final_callback = "out";
                    break;
                case "GateIn":
                edge_softness = 0;
                    start = new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 0, 360, 1 };
                    end = new float[7] { 0.5f, 0.5f, 0.0f, 1.0f, 0, 360, 1 };
                    final_callback = "in";
                    break;
                case "GateOut":
                edge_softness = 0;
                    start = new float[7] { 0.5f, 0.5f, 0.0f, 1.0f, 0, 360, 1 };
                    end = new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 0, 360, 1 };
                    final_callback = "out";
                    break;
                case "ClockIn":
                edge_softness = 0;
                    start = new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 360, 360, 0 };
                    end = stateOpen;
                    
                    final_callback = "in";
                    break;
                case "ClockOut":
                edge_softness = 0;
                    start = new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 360, 360, 1 };
                    end =  new float[7] { 0.0f, 1.0f, 0.0f, 1.0f, 0, 360, 1 };
                    final_callback = "out";
                    break;
                default:
                    start = stateOpen;
                    end = stateOpen;
                    final_callback = "in";
                    Debug.Log($"Unknown Effect {type}");
                    break;
            }
            material.SetFloat("_EdgeSoftness",edge_softness);
            SetMaterialEffect(material, start);
            onUpdate();
            animation = DOVirtual.Float(0, 1, duration, (v) =>
            {
                var state = InterpolateArrays(start, end, v);
                SetMaterialEffect(material, state);
                onUpdate();
            });
            animation.AllowMultipleCallback();
            switch (final_callback)
            {
                case "in":
                    animation.OnComplete(() =>
                    {
                        ResetMaterialEffect(material);
                        onUpdate();
                        material.SetFloat("_EdgeSoftness",0);
                    });
                    break;
                case "out":
                    animation.OnComplete(() =>
                    {
                        ResetMaterialEffect(material);
                        onUpdate();
                        SetAlpha(0);
                        material.SetFloat("_EdgeSoftness",0);
                    });
                    break;
                default:
                    break;
            }
            animation.OnKill(
                () =>
                {
                    animation.Complete(true);
                }
            );
            return animation;
        }

        public Tween PlayEffect(string type, float duration)
        {
            var material = GetEffectMaterial();
            if (material == null)
            {
                return null;
            }
            Action callback = null;
            if (mask != null) {
                callback = ()=>Utils.MaskUpdate.UpdateMask(mask); // notify mask utils to recalculate cl
            }
            return PlayMaterialEffect(material,type,duration);
        }
    }

}