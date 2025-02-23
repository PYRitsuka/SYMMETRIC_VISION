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

namespace GamePlay.Story.UI{
[ExecuteInEditMode]
public class ViewFrame : MonoBehaviour
{    
    public RectTransform canvasRectTransform;  // Reference to the Canvas RectTransform
    public RectTransform topLeftLogoT;  // Reference to the Canvas RectTransform
    public RawImage imgObject;
    public float imageObjectHeight;
    public float imageObjectwidth;
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
    public float stateImg = 0;  // Total height of all loaded images

    public List<Material> materials;
    
    public AnimationCurve SlideCurve;
    // public AnimationCurve FadeCurve;

    public float targetLogoScale; 
    public float targetLogoRotation0; 
    public float targetLogoRotation1; 
    public AnimationCurve fadeInAnimation; 

    public AnimationCurve blendAnimation; 
    private FrameColor _currentColor;
    public FrameColor current_color;

    public List<RawImage> ManagedFade;

    public bool doExpandEditor;
    public bool doCloseEditor;

    private int target_state;
    void OnValidate() {
        DoUpdate();
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
                    ManagedFade[0].texture = FrameColorTexture[3];
                    ManagedFade[1].texture = FrameColorTexture[3];
                    ManagedFade[2].texture = FrameColorTexture[0];
                    ManagedFade[3].texture = FrameColorTexture[0];
                }
                break;
                case FrameColor.Gray: {
                    ManagedFade[0].texture = FrameColorTexture[4];
                    ManagedFade[1].texture = FrameColorTexture[4];
                    ManagedFade[2].texture = FrameColorTexture[1];
                    ManagedFade[3].texture = FrameColorTexture[1];
                }
                break;
                case FrameColor.Blue: {
                    ManagedFade[0].texture = FrameColorTexture[5];
                    ManagedFade[1].texture = FrameColorTexture[5];
                    ManagedFade[2].texture = FrameColorTexture[2];
                    ManagedFade[3].texture = FrameColorTexture[2];
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

    public string GetPath(string file) {
        if (file.StartsWith("//")) {
            return file.Substring(2);
        } else {
            return $"UI/{file}";
        }
    }
    public Tween SetTexture(string path ,float duration=0) {
        var texture = StoryUtils.LoadResource<Texture>(GetPath(path));
        return SetTexture(texture,duration);
    }
    public Tween SetTexture(Texture texture,float duration = 0) {
        if (duration == 0) {
            imgObject.texture = texture;
            return null;
        }
        var newObjTmp = Instantiate(imgObject.gameObject,imgObject.transform.parent);
        newObjTmp.transform.SetSiblingIndex(imgObject.transform.GetSiblingIndex() + 1);
        imgObject.texture = texture;
        var seq = newObjTmp.GetComponent<RawImage>().DOFade(0,duration);
        seq.AllowMultipleCallback();
        seq.OnComplete(
            ()=>{Destroy(newObjTmp);}
        );
        seq.OnKill(
            ()=>{seq.Complete(true);}
        );
        return seq;
    }

    public Tween DoExpand(float duration) {
        canvasRectTransform.sizeDelta = new Vector2(400, 400);
        var Seq = DOTween.Sequence();
        gameObject.SetActive(true);
        
        Seq.Insert(0,
            canvasRectTransform.DOSizeDelta(new Vector2(1250, 720), duration)
        );
        Seq.Insert(0,
            DOTween.To(
                    GetState,SetState,1.0f,duration 
                )
        );
        Seq.Insert(0,
            DOTween.To(
                   ()=>stateImg,(float v)=>{stateImg = v;},1.0f,duration 
                ).SetDelay(duration / 2)
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

    void CleanUpOnKill() {
        if (target_state == 1) {
            canvasRectTransform.sizeDelta = new Vector2(1250, 720);
            stateImg = 1;
            SetState(1);

        } else {
            canvasRectTransform.sizeDelta = new Vector2(400, 400);
            stateImg = 0;
            SetState(0);
            gameObject.SetActive(false);
        }
        DoUpdate();
    }

    public Tween DoClose(float duration) {
        if (duration == 0) {
            target_state = 0;
            CleanUpOnKill();
            return null;
        }
        float delay = duration / 2;
        var Seq = DOTween.Sequence();
        Seq.Insert(0,
            canvasRectTransform.DOSizeDelta(new Vector2(400, 400), duration).SetDelay(delay));
        Seq.Insert(0,
            DOTween.To(
                        GetState,SetState,0.0f,duration 
                    ).SetDelay(delay)
        );
        Seq.Insert(0,
                        DOTween.To(
                   ()=>stateImg,(float v)=>{stateImg = v;},0.0f,duration 
                )
        );
        Seq.OnUpdate(DoUpdate);
        Seq.AllowMultipleCallback();
        Seq.OnComplete(
            CleanUpOnKill
        );
        Seq.Play();
        Seq.OnKill(
            ()=>{Seq.Complete(true);}
        );
        target_state = 0;
        return Seq;
    }
    void DoUpdate()
    {
        updateColor();
        float t = state;
        float t_fade = fadeInAnimation.Evaluate(state);
        float t_blend = blendAnimation.Evaluate(state);
        imgObject.material.SetFloat("_Brightness",Mathf.Lerp( 1.0f,0.0f,blendAnimation.Evaluate(stateImg) ));
        imgObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Lerp(0.0f,imageObjectwidth,stateImg),Mathf.Lerp(0.0f,imageObjectHeight,stateImg));
        var tagetScale = Mathf.Lerp(1.0f,targetLogoScale,t);
        var baseScale = new Vector3(tagetScale, tagetScale,tagetScale);
        topLeftLogoT.localScale = baseScale;
        topLeftLogoT.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(targetLogoRotation0,targetLogoRotation1,t));
       
        foreach (var material in materials) {
            material.SetFloat("_Blend", Mathf.Lerp( 0.0f,1.0f,t_blend ));
            material.SetFloat("_Fade",Mathf.Lerp( 0.0f,1.0f, t_fade));
        }
        foreach (var img in ManagedFade) {
            img.color = new Color(1, 1, 1, Mathf.Lerp( 0.0f,1.0f, t_fade));
        }
        if (t_fade > 0.5) {
            ManagedFade[5].color = new Color(1, 1, 1, Mathf.Lerp( 1.0f,0.0f, state));
        }
    
        // if (t_fade)
        // Debug.Log("Editor causes this Update");
    }
    
    // Method to add an image using an addressable address
    
}
}