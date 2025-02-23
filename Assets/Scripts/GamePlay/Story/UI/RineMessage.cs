using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Utils;
using DG.Tweening;
using Unity.VisualScripting;
using System;

namespace GamePlay.Story.UI
{
    [ExecuteInEditMode]
    public class RineMessage: MonoBehaviour {
        public RawImage imgObject;

        [Range(0.0f, 1.0f)]
        public float state = 0;  // Total height of all loaded images

        public float initOffset = -10;

        float cutoff = 0.7f;

        void OnValidate() {
            DoUpdate();
        }
        // FIXME: Removee Duplicate Code
        float ResizeT(float begin,float end,float t) {
            var v = (t - begin) / (end - begin);
            return Math.Clamp(v,0,1);
        }

        void DoUpdate() {
            var t_alpha = ResizeT(0,cutoff,state);
            imgObject.color = new Color(1,1,1,t_alpha);
            //
            imgObject.rectTransform.localPosition = new Vector3(0,
             Mathf.Lerp(initOffset,0,state), 1);
        }

        public void DoFadeIn(float duration) {
            state = 0;  
            DoUpdate();
            DOTween.To(()=>state,(v)=>{state = v;DoUpdate();},1,duration);
        }

    }

}