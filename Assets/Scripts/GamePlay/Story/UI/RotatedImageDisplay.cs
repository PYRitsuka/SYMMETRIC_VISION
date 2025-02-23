using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Utils;
using DG.Tweening;
namespace GamePlay.Story.UI{
[ExecuteInEditMode]
public class RotatedImageDisplay : MonoBehaviour
{    
    public RectTransform canvasRectTransform;  // Reference to the Canvas RectTransform
    public RawImage imgObject;
    public enum FrameColor{
        Pink,
        Gray,
        Blue,
    }

    public List<Texture2D> FrameColorTexture;

    //public bool isLoading = true;  // Flag to check if an image is currently being loaded
    private float totalHeight = 0;  // Total height of all loaded images
    [Range(0.0f, 1.0f)]
    public float state = 0;  // Total height of all loaded images

    [Range(0.0f, 1.0f)]
    public float stateFrame = 0;  // Total height of all loaded images

    [Range(0.0f, 1.0f)]
    public float stateRotation = 0;  // Total height of all loaded images

    public float frameSizeFactor;  // Total height of all loaded images
    public float frameSizeDelta;  // Total height of all loaded images

    public float frameRotation;  // Total height of all loaded images


    public List<Material> materials;
    
    // public AnimationCurve FadeCurve;

    public AnimationCurve fadeInAnimation; 
    public AnimationCurve shapeAnimation;
    public AnimationCurve frameRotationScale;

    // public AnimationCurve blendAnimation; 
    private FrameColor _currentColor;
    public FrameColor current_color;

    public Vector4 skew;
    public Vector4 scale;

    public float mulScale;

    public float rotation;

    public float aspect;

    public List<RawImage> ManagedFade;

    public bool doExpandEditor;
    public bool doCloseEditor;

    private int target_state;

    public string GetPath(string file) {
        if (file.StartsWith("//")) {
            return file.Substring(2);
        } else {
            return $"UI/{file}";
        }
    }
    void OnValidate() {
        if (doExpandEditor) {
            DoExpand(0.75f);
            doExpandEditor = false;
        }
        if (doCloseEditor) {
            DoClose(0.75f);
            doCloseEditor = false;
        }
    }

    public void SetColor(string color) {
        switch (color) {
            case "pink":
                current_color = FrameColor.Pink;
                break;
            case "gray":
                current_color = FrameColor.Gray;
                break;
            case "blue":
                current_color = FrameColor.Blue;
                break;
        }
        updateColor();
    }


    void updateColor() {
        if (current_color != _currentColor) {
            switch (current_color) {
                case FrameColor.Pink: {
                    ManagedFade[0].texture = FrameColorTexture [0];
                }
                break;
                case FrameColor.Gray: {
                    ManagedFade[0].texture = FrameColorTexture [1];
                }
                break;
                case FrameColor.Blue: {
                    ManagedFade[0].texture = FrameColorTexture [2];
                }
                break;
            }
        }
        _currentColor = current_color;
    }

    public float GetState() {
        return state;
    }

    public void SetState(float v) {
        state = v;
    }

    public Tween DoExpand(float duration) {
        SetState(0);
        DoUpdate();
        stateFrame = 0;
        stateRotation = 1; // fade in only
        var Seq = DOTween.Sequence();
        Seq.Insert(0,
            DOTween.To(
                   GetState,SetState,1.0f,duration 
                )
        );
        Seq.Insert(0,
            DOTween.To(
                   ()=>stateFrame,(float v)=>{stateFrame = v;},1.0f,duration / 2 
                ).SetDelay(duration * 0.75f )
        );
        Seq.AllowMultipleCallback();
        Seq.OnComplete(
            CleanUpOnKill
        );
        Seq.OnUpdate(DoUpdate);
        Seq.OnKill(
            ()=>{Seq.Complete(true);}
        );
        Seq.Play();
        target_state = 1;
        return Seq;

    }

    public Tween DoClose(float duration) {
        if (duration == 0) {
            target_state = 0;
            CleanUpOnKill();
            return null;
        }
        var Seq = DOTween.Sequence();
        Seq.Insert(0,
            DOTween.To(
                   GetState,SetState,0.0f,duration 
            )
        );
        Seq.Insert(0,
            DOTween.To(
                   ()=>stateFrame,(float v)=>{stateFrame = v;},0.0f,duration 
                )
        );
        Seq.Insert(0,
            DOTween.To(
                   ()=>stateRotation,(float v)=>{stateRotation = v;},0.0f,duration  
                )
        );
        Seq.AllowMultipleCallback();
        Seq.OnComplete(
            CleanUpOnKill
        );
        Seq.OnKill(
            ()=>{Seq.Complete(true);}
        );
        Seq.OnUpdate(DoUpdate);
        Seq.Play();
        target_state = 0;
        return Seq;
    }

    public Tween SetTexture(string path ,float duration=0) {
        var texture = StoryUtils.LoadResource<Texture>(GetPath(path));
        return SetTexture(texture,duration);
    }
    public Tween SetTexture(Texture texture,float duration=0) {
        if (duration == 0) {
            imgObject.texture = texture;
            return null;
        }
        var newObjTmp = Instantiate(imgObject.gameObject,imgObject.transform.parent);
        newObjTmp.transform.SetSiblingIndex(imgObject.transform.GetSiblingIndex()+1);
        imgObject.texture = texture;
        Material newMaterial = new Material(newObjTmp.GetComponent<RawImage>().material);
        newObjTmp.GetComponent<RawImage>().material = newMaterial;
        var seq = newObjTmp.GetComponent<RawImage>().material.DOFloat(0,"_Fade",duration);
        seq.AllowMultipleCallback();
        seq.OnKill(
            ()=>{Destroy(newObjTmp);}
        );
        seq.OnKill(
            ()=>{seq.Complete(true);}
        );
        return seq;

    }

    void CleanUpOnKill() {
        if (target_state == 1) {
            stateFrame = 1;
            stateRotation = 1;
            SetState(1);

        } else {
            stateFrame = 0;
            stateRotation = 0;
            SetState(0);
        }
        DoUpdate();
    }
    void DoUpdate()
    {
        updateColor();
        float t = state;
        float t_shape = shapeAnimation.Evaluate(1.0f - state);
        float t_fade = fadeInAnimation.Evaluate(state);
        float t_frame = frameRotationScale.Evaluate(1.0f - stateRotation);
        // float t_fade = fadeInAnimation.Evaluate(state);
        // float t_blend = blendAnimation.Evaluate(state);
        // imgObject.material.SetFloat("_Brightness",Mathf.Lerp( 1.0f,0.0f,blendAnimation.Evaluate(stateImg) ));
        // imgObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Lerp(0.0f,imageObjectwidth,stateImg),Mathf.Lerp(0.0f,imageObjectHeight,stateImg));
        // var tagetScale = Mathf.Lerp(1.0f,targetLogoScale,t);
        // var baseScale = new Vector3(tagetScale, tagetScale,tagetScale);
        // topLeftLogoT.localScale = baseScale;
        // topLeftLogoT.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(targetLogoRotation0,targetLogoRotation1,t));
       
        foreach (var material in materials) {
            material.SetFloat("_Rotation", Mathf.Lerp( 0.0f,rotation,t_shape));
            material.SetFloat("_AspectRatio", Mathf.Lerp( 1.0f,aspect,t_shape));
            material.SetVector("_Skew", Vector4.Lerp( new Vector4(),skew,t_shape));
            material.SetVector("_Scale", Vector4.Lerp( new Vector4(1,1,0,0),scale,t_shape));
            material.SetFloat("_ScaleMul", Mathf.Lerp(1.0f,mulScale,t_shape));
            material.SetFloat("_Fade", Mathf.Lerp(0.0f,1.0f,t_fade));
            // material.SetFloat("_Blend", Mathf.Lerp( 0.0f,1.0f,t_blend ));
            // material.SetFloat("_Fade",Mathf.Lerp( 0.0f,1.0f, t_fade));
        }
        foreach (var img in ManagedFade) {
            img.color = new Color(1, 1, 1, Mathf.Lerp( 0.0f,1.0f, stateFrame));
            var tf = img.GetComponent<RectTransform>();
            // tf.sizeDelta = Vector2.Lerp(
            //     new Vector2(1241.362f*frameSizeDelta,698.00f*frameSizeDelta),
            //     new Vector2(1241.362f,698.00f),t_frame

            // )
            tf.localScale = Vector3.Lerp(new Vector3(frameSizeFactor,frameSizeFactor,frameSizeFactor),
            new Vector3(frameSizeDelta*frameSizeFactor,frameSizeDelta*frameSizeFactor,frameSizeDelta*frameSizeFactor),t_frame);
            tf.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(0,frameRotation,t_frame));
        }
        // Debug.Log("Editor causes this Update");
    }
    
    // Method to add an image using an addressable address
    
}
}