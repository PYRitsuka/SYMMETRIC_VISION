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
    public class Rine : MonoBehaviour
    {
        public RectTransform canvasRectTransform;  // Reference to the Canvas RectTransfor
        public RectTransform topLeftLogoT;  // Reference to the Canvas RectTransform
        public RawImage Frame;

        // public RawImage Logo;

        public CanvasGroup BGCanvas;
        [Range(0.0f, 1.0f)]
        public float state = 0;  // Total height of all loaded images

        [Range(0.0f, 2.0f)]
        public float stateBG = 0;  // Total height of all loaded images

        public float LogoRotationScale = 20;  // Total height of all loaded images
        public bool doExpandEditor;
        public bool doCloseEditor;

        public bool doInsertTest;

        public bool doClearEditor;

        private int target_state;

        public float cutoff_1 = 0.1f;
        public float cutoff_2 = 0.5f;
        public float cutoff_3 = 0.6f;

        public RineMessage imgObject;

        public RectTransform content;

        public List<RineMessage> messages = new();
        public Texture blank;

        public float currentHeight = 0;

        public float pad = 15;

        public float alphaMultiplier = 1.0f;

        public float screenHeight = 648;

        public Tween SetTexture(Texture texture,float duration = 0) {
            // if (duration == 0) {
            //     imgObject.texture = texture;
            //     return null;
            // }
            // var newObjTmp = Instantiate(imgObject.gameObject,imgObject.transform.parent);
            // newObjTmp.transform.SetSiblingIndex(imgObject.transform.GetSiblingIndex() + 1);
            // imgObject.texture = texture;
            // var seq = newObjTmp.GetComponent<RawImage>().DOFade(0,duration);
            // seq.AllowMultipleCallback();
            // seq.OnComplete(
            //     ()=>{Destroy(newObjTmp);}
            // );
            // seq.OnKill(
            //     ()=>{seq.Complete(true);}
            // );
            // return seq;
            return null;
        }

        public string GetPath(string file) {
            if (file.StartsWith("//")) {
                return file.Substring(2);
            } else {
                return $"Rine/{file}";
            }
        }

        public Tween InsertImage(string tex) {
            var img = Instantiate(imgObject, transform);
            Texture texture;
            
            if (tex == "") {
                  texture   = blank;
            } else {
                    texture  = StoryUtils.LoadResource<Texture>(GetPath(tex));
            }
            img.imgObject.texture  = texture;
            float aspectRatio = (float )texture.width / texture.height;
            var rect = img.GetComponent<RectTransform>();
            float currentWidth = rect.rect.width;
            float newHeight = currentWidth / aspectRatio;
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
            img.transform.SetParent(imgObject.transform.parent, false);

            // Set the position of the instance to be the same as the prototype
            img.transform.position = imgObject.transform.position;
            currentHeight -= pad;
            img.transform.localPosition =  new Vector3(img.transform.localPosition.x,currentHeight,1);
            currentHeight -= newHeight;
            Debug.Log($"Rine Content Offset: {content.localPosition.y + currentHeight + pad}");
            if (content.localPosition.y + currentHeight + pad < -screenHeight) {
                // content.localPosition.y + currentHeight + pad == screenHeight
                var target_pos_y = screenHeight - pad - (-currentHeight);
                Debug.Log($"Rine target_pos_y Offset: {target_pos_y}");
                content.DOLocalMoveY(-target_pos_y,0.5f);
                // content.localPosition = new Vector3(
                //     content.localPosition.x,
                //     -target_pos_y,1
                // );
            }
            img.gameObject.SetActive(true);
            messages.Add(img);
            img.DoFadeIn(0.5f);
            return null;
        }

        void Clear(){
            foreach (var message in messages) {
                Destroy(message.GameObject());
            }
            currentHeight = 0;
            content.localPosition = new Vector3(
                    content.localPosition.x,
                    0,1
            );
            messages = new();
        }

        void OnValidate() {
            DoUpdate();
            if (doExpandEditor) {
                DoExpand(1.5f);
                doExpandEditor = false;
            }
            if (doCloseEditor) {
                DoClose(1.0f);
                doCloseEditor = false;
            }
            if (doInsertTest) {
                InsertImage("消息1.png");
                doInsertTest = false;
            }
            if (doClearEditor) {
                Clear();
                doClearEditor = false;
            }
        }
        float ResizeT(float begin,float end,float t) {
            var v = (t - begin) / (end - begin);
            return Math.Clamp(v,0,1);
        }

        public Tween DoExpand(float duration) {
            Clear();
            var Seq = DOTween.Sequence();
            gameObject.SetActive(true);
            stateBG = 0;
            DoUpdate();
            Seq.Insert(0,
            DOTween.To(
                   ()=>stateBG,(float v)=>{stateBG = v;BGUpDate();},1.0f,duration 
                )
            );
            Seq.AllowMultipleCallback();
            Seq.OnComplete(
                CleanUpOnKill
            );
            Seq.OnKill(
            ()=>{Seq.Complete(true);}
            );
            target_state = 1;
            return Seq;
        }

        public Tween DoClose(float duration) {
            var Seq = DOTween.Sequence();
            stateBG = 1;
            DoUpdate();
            Seq.Insert(0,
            DOTween.To(
                   ()=>stateBG,(float v)=>{stateBG = v;BGUpDate();},2.0f,duration 
                )
            );
            Seq.AllowMultipleCallback();
            Seq.OnComplete(
                CleanUpOnKill
            );
            Seq.OnKill(
            ()=>{Seq.Complete(true);}
            );
            target_state = 0;
            return Seq;
        }

        void CleanUpOnKill() {
        if (target_state == 1) {
            stateBG = 1;
            DoUpdate();

        } else {
            stateBG = 0;
            Clear();
            DoUpdate();
            gameObject.SetActive(false);
        }
        DoUpdate();
    }

        public void SetAlpha(float alpha) {
            alphaMultiplier = alpha;
            DoUpdate();
        }

        public Tween ChangeAlpha(float begin, float end, float duration) {
            if (duration == 0 ){
                SetAlpha(end);
                return null;
            }
            SetAlpha(begin);
            var animation = DOTween.To(()=>alphaMultiplier,SetAlpha,end,duration);
            return animation;
        }
        float GetLogoAlpha(){
            if (stateBG < cutoff_1) {
                return ResizeT(0,cutoff_1,stateBG);
            } else if (stateBG < cutoff_2) {
                return 1;
            } else if (stateBG < cutoff_3) {
                return 1- ResizeT(cutoff_2,cutoff_3,stateBG);
            } else {
                return 0;
            }
        }
        void BGUpDate() {
            BGCanvas.alpha = ResizeT(cutoff_2,cutoff_3,stateBG) * alphaMultiplier;
            var t_scaleContainer = ResizeT(cutoff_2,1.0f,stateBG);
            var tagetScale = Mathf.Lerp(0.2f,1.0f,t_scaleContainer);
            Frame.material.SetFloat("_Blend",Mathf.Lerp(1.0f,0.0f,t_scaleContainer));
            var baseScale = new Vector3(tagetScale, tagetScale,tagetScale);
            canvasRectTransform.localScale = baseScale;
            // LogoRotation
            var rotation = Math.Abs((stateBG * 5 % 1) * 2 -1);
            topLeftLogoT.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(-LogoRotationScale,LogoRotationScale,rotation));
            // log visibility
            topLeftLogoT.GetComponent<RawImage>().color = new Color(1,1,1,GetLogoAlpha());
            // mask
            var t_mask = ResizeT(1.0f,2.0f,stateBG);
            Frame.material.SetFloat("_CropYMin",Mathf.Lerp(0.0f,0.55f,t_mask));
            Frame.material.SetFloat("_CropYMax",Mathf.Lerp(1.0f,0.45f,t_mask));
        }
        void DoUpdate() {
            BGUpDate();
            
            // Logo 
            // size
            // var StartSize = new Vector2(400, 400);
            // var EndSize = new Vector2()
            // canvasRectTransform.sizeDelta =
        }

    }
}