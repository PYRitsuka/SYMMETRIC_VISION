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

namespace GamePlay.StoryV2.RecordsResolver
{
    
   public class ImageLayerResolverV2 : MonoBehaviour
    {
        [SerializeField] private RawImage archetype;
        [SerializeField] private RawImage scrollViewArchetype;
        [SerializeField] private string Resource;

        const int KEEP_Value = -9999;

        

        public Texture blank;
        
        private readonly Dictionary<string, RawImage> _images = new ();
        private readonly HashSet<string> _is_scrollView = new ();

        public string GetPath(string file) {
            if (file.StartsWith("//")) {
                return file.Substring(2);
            } else {
                return $"{Resource}{file}";
            }
        }
        public void AddKey(string name,string texture) {
            if (!_images.ContainsKey(name)) {
                var img = Instantiate(archetype, transform);
                // img.texture = StoryUtils.LoadResource<Texture>($"立绘/{backgroundPicture}");
                //img.texture = StoryUtils.LoadAddressable<Texture>($"立绘/{backgroundPicture}");
                if (texture == "") {
                    img.texture = blank;
                } else {
                    img.texture = StoryUtils.LoadResource<Texture>(GetPath(texture));
                }
                //img.texture = StoryUtils.LoadResource<Texture>($"{Resource}{texture}");
                img.material = new Material(Shader.Find("UI/OverlayFadeShader"));
                var manager = img.gameObject.AddComponent<ImageAnimationHandler>();
                manager.Init();
                img.gameObject.SetActive(true);
                img.SetNativeSize();
                _images.Add(name, img);
            } else {
                Debug.LogError($"{name} already in picture stack!");
            }
        }


        public void AddKeyScrollView(string name,string texture,string direction,int x=0,int y=0,int height=300,int width=800) {
            if (!_images.ContainsKey(name)) {
                var img = Instantiate(scrollViewArchetype, transform);
                // img.texture = StoryUtils.LoadResource<Texture>($"立绘/{backgroundPicture}");
                //img.texture = StoryUtils.LoadAddressable<Texture>($"立绘/{backgroundPicture}");
                img.transform.localPosition = new Vector3(x, y, 1);
                img.rectTransform.sizeDelta  = new Vector2(width,height);
                var manager = img.GetComponent<ImageAnimationHandlerScrollView>();
                var content = manager.content;
                if (texture == "") {
                    content.texture = blank;
                } else {
                    content.texture = StoryUtils.LoadResource<Texture>(GetPath(texture));
                }
                if (direction == "horizontal") {
                    manager.scrollRect.horizontal = true;
                    manager.scrollRect.vertical = false;
                } else if (direction == "vertical") {
                    manager.scrollRect.horizontal = false;
                    manager.scrollRect.vertical = true;
                } else {
                    manager.scrollRect.horizontal = true;
                    manager.scrollRect.vertical = true;
                }
                manager.Init();
                img.gameObject.SetActive(true);
                manager.content.SetNativeSize();
                _images.Add(name, img);
                _is_scrollView.Add(name);
            } else {
                Debug.LogError($"{name} already in picture stack!");
            }
        }

        public void RemoveKey(string name) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                Destroy(img.GameObject());
                _images.Remove(name);
                if (_is_scrollView.Contains(name)) {
                    _is_scrollView.Remove(name);
                }
            }   
        }

        public void Clear() {
            foreach (var k in _images.Keys.ToList()) {
                RemoveKey(k);
            }
        }

        public Tween SetTexture(string name,string texture,float duration) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                if (_is_scrollView.Contains(name)) {
                    img = img.GetComponent<ImageAnimationHandlerScrollView>().content; // set content
                }
               if (duration == 0) {
                img.texture = StoryUtils.LoadResource<Texture>(GetPath(texture));
                return null;
               } else {
                var newObjTmp = Instantiate(img.gameObject,img.transform.parent);
                newObjTmp.transform.SetSiblingIndex(img.transform.GetSiblingIndex()+1);
                img.texture = StoryUtils.LoadResource<Texture>(GetPath(texture));
                Material newMaterial = new Material(newObjTmp.GetComponent<RawImage>().material);
                newObjTmp.GetComponent<RawImage>().material = newMaterial;
                var seq = newObjTmp.GetComponent<RawImage>().material.DOFloat(0,"_Fade",duration);
                seq.OnKill(
                    ()=>{Destroy(newObjTmp);}
                );
                seq.OnComplete(
                    ()=>{Destroy(newObjTmp);}
                );
                return seq;
               }
            }
            return null;
        }
        
        public Tween SetLocation(string name,float x,float y,float duration = 0,string curve = "constant") {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                x = x==KEEP_Value? img.transform.localPosition.x :x;
                y = y==KEEP_Value? img.transform.localPosition.y :y;
                if (duration == 0) {
                    img.transform.localPosition = new Vector3(x, y, 1);
                    return null;
                } else {
                    var animation = SVAnimator.DoMoveCurve(
                        curve,img.transform,new Vector3(x, y, 1),duration
                    );
                    return animation;
                }
                
            }
            return null;
        }

        public Tween SetScale(string name,float scale,float duration = 0,string curve = "constant") {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                if (duration == 0) {
                    img.rectTransform.localScale = Vector3.one * scale;
                    return null;
                } else {
                    var animation = SVAnimator.DoScaleCurve(
                        curve,img.rectTransform,
                        Vector3.one * scale,
                        duration
                    );
                    return animation;
                }
                
            }
            return null;
        }

        public Tween SetRotation(string name,float angle,float duration = 0,string curve = "constant") {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                if (duration == 0) {
                    img.rectTransform.localRotation =Quaternion.Euler(0, 0,angle);
                    return null;
                } else {
                    var animation = SVAnimator.DoRotationCurve(
                        curve,img.rectTransform,
                        angle,
                        duration
                    );
                    return animation;
                }
                
            }
            return null;
        }

        public void SetKeepMove(
            string name,
            int x,int y,
            float scale,
            float angle,float duration,string curve ="uniform",
            float alpha = -1,float alphaTime =0
        ) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                img.GetComponent<ImageAnimationHandler>()?.SetKeepMove(
                    new Vector2(x,y),scale,angle,duration,curve,alpha,alphaTime
                );
                
            }

         }

        public void StopMove(
            string name
        ) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                img.GetComponent<ImageAnimationHandler>()?.StopMove();
            }
         }

        public Tween SetFade(string name,float alpha,float duration = 0) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                var manager = img.GetComponent<ImageAnimationHandler>();
                if (duration == 0) {
                    manager.SetAlpha(alpha);
                    return null;
                } else {
                    var animation = DOVirtual.Float(
                        manager.alpha,alpha,duration,(v)=>{
                            manager.SetAlpha(v);
                        }
                    );
                    animation.AllowMultipleCallback();
                    animation.OnComplete(
                        ()=>{manager.SetAlpha(alpha);}
                    );
                    animation.OnKill(
                        ()=>{animation.Complete(true);}
                    );
                    return animation;
                }
                
            }
            return null;
        }

        
        public Tween SetBlur(string name,float radius,float duration = 0) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                var manager = img.GetComponent<ImageAnimationHandler>();
                if (duration == 0) {
                    manager.GetContentImage().material.SetFloat(
                        "_BlurScale",radius
                    );
                    return null;
                } else {
                    var animation = DOVirtual.Float(
                       manager.GetContentImage().material.GetFloat("_BlurScale"),
                       radius,
                       duration,(v)=>{
                            manager.GetContentImage().material.SetFloat(
                                "_BlurScale",v
                            );
                        }
                    );
                    animation.AllowMultipleCallback();
                    animation.OnComplete(
                        ()=>{
                            manager.GetContentImage().material.SetFloat(
                                "_BlurScale",radius
                            );
                        }
                    );
                    animation.OnKill(
                        ()=>{animation.Complete(true);}
                    );
                    return animation;
                }
                
            }
            return null;
        }

        public void SetColor(string name,float r,float g,float b) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                var manager = img.GetComponent<ImageAnimationHandler>();
                manager.GetContentImage().material.SetColor(
                    "_RGBMultiplier",new Color(r, g, b, 1)
                );
            }

        }


        public void SetCall(string name,bool enabled) {
            RawImage img;
            _images.TryGetValue(name,out img);
            float target = Convert.ToSingle(enabled);
            if (img != null) {
                var manager = img.GetComponent<ImageAnimationHandler>();
                manager.GetContentImage().material.SetFloat(
                    "_CallEnable",target
                );
            }

        }

        
        public void SetColorByFactor(string name,float factor) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                var manager = img.GetComponent<ImageAnimationHandler>();
                var old_color = manager.GetContentImage().material.GetColor("_RGBMultiplier");
                var r = old_color.r * factor;
                var g = old_color.g * factor;
                var b = old_color.b * factor;
                manager.GetContentImage().material.SetColor(
                    "_RGBMultiplier",new Color(r, g, b, 1)
                );
            }

        }

        public void SetShakeState(string name,string state,bool loop) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                img.GetComponent<ImageAnimationHandler>()?.SetShakeState(state,loop);
                
            }
        }

        public Tween PlayVideo(string name,string video,bool loop,float volume = 1) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                // load video
                var clip = StoryUtils.LoadResource<VideoClip>(GetPath(video));
                if (clip == null)
                {
                    Debug.Log($"Invalid Clip {video}");
                    return null;
                }
                var manager = img.GetComponent<ImageAnimationHandler>();
                var animation = manager.PlayVideo(clip,loop,volume);
                if (!loop ) {
                    Debug.Assert(animation != null);
                    animation.OnComplete(
                        ()=>{
                            manager.GetContentImage().texture = blank;
                            RemoveKey(name);
                        }
                    );
                }
                return animation;
            }
            return null;
        }

         public Tween PlayImageSequence(string name,string framePatterns,int start,int end, string onComplete, float speed = 20) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                // load video
                bool loop = onComplete == "loop";
                List<string> paths = new List<string>();
                framePatterns = GetPath(framePatterns);
                for (int i = start; i <= end; i++)
                {
                    var path = framePatterns.Replace("{}", i.ToString());
                    paths.Add(path);
                }
                var textures = paths.ConvertAll(x => StoryUtils.LoadResource<Texture>(x));
                var manager = img.GetComponent<ImageAnimationHandler>();
                var animation = manager.PlayImageSequence(textures,loop,speed);
                Debug.Assert(!loop,"Debug: So far not Implemented Looping for Image Seq");
                if (onComplete == "kill" ) {
                    Debug.Assert(animation != null);
                    animation.OnComplete(
                        ()=>{
                            manager.GetContentImage().texture = blank;
                            RemoveKey(name);
                        }
                    );
                }
                return animation;
            }
            return null;
         }

        public Tween PlayEffect(string name,string type,float duration) {
            RawImage img;
            _images.TryGetValue(name,out img);
            if (img != null) {
                // load video
                var animation = img.GetComponent<ImageAnimationHandler>()?.PlayEffect(type,duration);
                return animation;
            }
            return null;
        }

    }
}