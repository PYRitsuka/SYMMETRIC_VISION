using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Utils {
    public class SVAnimator {
        private float value;

        private Func<float, float> mapper;
        public Action<float> onNewValue;


        public SVAnimator(Func<float, float> mapper) {
            this.mapper = mapper;
        }

        public SVAnimator(Func<float, float> mapper,Action<float> callback): this(mapper) {
            this.onNewValue = callback;
        }


        public SVAnimator(Func<float, float> mapper,int x0,int x1, int y0, int y1,Action<int,int> callback): this(mapper) {
            onNewValue = (t) => {
                var x = (int)Mathf.Lerp (x0, x1, t);
                var y = (int)Mathf.Lerp (y0, y1, t);
                callback(x,y);
            };
        }

        public SVAnimator(Func<float, float> mapper,Vector2 pos0, Vector2 pos1,Action<Vector2> callback): this(mapper) {
            pos0 = pos0 + Vector2.zero;
            onNewValue = (t) => {
                var pos = Vector2.Lerp (pos0, pos1, t);
                callback(pos);
            };
        }

        public static Tween DoMoveCurve(Func<float, float> mapper,Transform targetTransform, Vector2 targetPos,
                float target, float duration,bool autoKill = true) 
        {
            
            if(mapper == null) {
                Debug.LogError($"Constructor Error: Mapper of an animator is none: ");
            }
            var animator = new SVAnimator(
                        mapper,targetTransform.localPosition,targetPos,
                        (pos)=>{targetTransform.localPosition = new Vector3(pos.x, pos.y, 1);}
            );
            if(animator.mapper == null) {
                Debug.LogError($"Constructor Error: Mapper of an animator is none:");
            }

            return  animator.DoFloat(target,duration,autoKill);
        }


        public static Tween DoMoveCurve(string curve,Transform targetTransform, Vector2 targetPos,
                 float duration,float target=1,bool autoKill = true) 
        {
            Func<float, float> map = GetMap(curve);
            if(map == null) {
                Debug.LogError($"Constructor Error: Mapper of an animator is none: curve {curve}");
            }
            return DoMoveCurve(map, targetTransform,  targetPos, target, duration,autoKill);

        }

        public static Tween DoScaleCurve(string curve,RectTransform targetTransform, Vector3 targetScale,
                 float duration,float target=1,bool autoKill = true) 
        {
            Func<float, float> map = GetMap(curve);
            var scale0 = targetTransform.localScale + Vector3.zero;
            var animator =  new SVAnimator(map, (v)=>{
                targetTransform.localScale = Vector3.Lerp(scale0,targetScale,v);
            }); 
            return  animator.DoFloat(target,duration,autoKill);

        }


        public static Tween DoRotationCurve(string curve,RectTransform targetTransform, float targetAngle,
                 float duration,float target=1,bool autoKill = true) 
        {
            Func<float, float> map = GetMap(curve);
            float rot0 = targetTransform.localEulerAngles.z;
            var animator =  new SVAnimator(map, (v)=>{
                targetTransform.localRotation = Quaternion.Euler(0, 0,Mathf.Lerp(rot0,targetAngle,v));
            }); 
            return  animator.DoFloat(target,duration,autoKill);

        }

        static Func<float, float> GetMap (string curve) {
            switch (curve) {
                case "ease_in": 
                    return (t)=>MathF.Sin((t * MathF.PI) / 2);
                case "ease_out":
                    return (t)=>MathF.Cos(( (1-t) * MathF.PI) / 2);
                case "uniform":
                case "constant":
                default:
                    return (t)=>t;
                
            } 
        }



        public Tween DoFloat(float target, float duration,bool autoKill = true) {
            var animation = DOTween.To(GetValue,SetValue,target,duration);
            animation.OnComplete(
                ()=>{SetValue(target);}
            );
            if (autoKill) {
                animation.OnKill(
                    ()=>{animation.Complete(true);}
                );
            }
            return animation;
        }


        public float GetValue() {
            return value;
        }

        public void SetValue(float x) {
            value = x;
            if(mapper == null) {
                Debug.LogError("Mapper of an animator is none, check what happens!");
            }
            var value_transformed = mapper(x);
            if (onNewValue != null) {
                onNewValue(value_transformed);
            }
        }

    }


}