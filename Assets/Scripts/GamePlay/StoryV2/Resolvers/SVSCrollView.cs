using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;
using Utils;

namespace GamePlay.StoryV2.RecordsResolver
{
    [ExecuteInEditMode]
    public class ImageAnimationHandlerScrollView : ImageAnimationHandler
    {
        // no methods here, mostly just pointers for quick access
        public static new bool scrollable = true;

        public RawImage content;
        public List<Texture2D> FrameColorTexture;

        public RawImage ScrollBarH;
        public RawImage ScrollBarV;
        public RawImage ScrollHandleH;
        public RawImage ScrollHandleV;

        public ScrollRect scrollRect;
        public UnityEngine.UI.Image viewPort;
         
        


        public enum FrameColor
        {
            Pink,
            Gray,
            Blue,
        }

        public void OnValidate() {
            SetFrameColor(currColor);
            SetAlpha(alpha);
        }

        public FrameColor currColor;

        public override void Init() {
            // set material
            var material = new Material(ScrollBarV.material);
            ScrollBarV.material = material;
            ScrollHandleV.material = material;
            content.material =  new Material(Shader.Find("UI/OverlayFadeShader"));
            viewPort.material =  new Material(Shader.Find("UI/OverlayFadeShader"));
            shakeManager = this.GameObject().AddComponent<ShakeManager>();
            Debug.Log($"HHHHH {contentImage==null}");
            shakeManager.rectTransform =  GetFrameImage().rectTransform;
        }

        public override RawImage GetContentImage() {
            return content;
        }
        public override RawImage GetFrameImage() {
            return contentImage;
        }

        public override Material GetEffectMaterial() {
            return viewPort.material;
        }

        public override void SetAlpha(float x){
            alpha = x; 
            SetBarAlpha(x);
            SetContentAlpha(x);
        }

        public void SetBarAlpha(float x) {
            ScrollBarV.material.SetFloat("_Fade",x);
            ScrollBarH.color = new Color(1,1,1,x);
            ScrollHandleH.color = new Color(1,1,1,x);
        }

        public void SetContentAlpha(float x) {
            content.color = new Color(1,1,1,x);
        }

        public void SetFrameColor(FrameColor color) {
            Texture tex = null;
            switch (color) {
                case FrameColor.Pink:
                    tex = FrameColorTexture[0];
                    break;
                case FrameColor.Gray:
                    tex = FrameColorTexture[1];
                    break;
                case FrameColor.Blue:
                    tex = FrameColorTexture[2];
                    break;
            }
            // cannot be null
            ScrollHandleH.texture = tex;
            ScrollHandleV.texture = tex;
            
        }

    }

}