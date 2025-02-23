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
using System.Runtime.InteropServices;
using UnityEngine.AI;

namespace GamePlay.Story.UI{
[ExecuteInEditMode]
public class BMIInterface : MonoBehaviour
{    
    // public RectTransform canvasRectTransform;  // Reference to the Canvas RectTransform
    public RectTransform mainLogo;  // Reference to the Canvas RectTransform
    public RawImage hexEffect;  // Reference to the Canvas RectTransform
    public RawImage contrastFilter;  // Reference to the Canvas RectTransform

    public enum FrameColor{
        Pink,
        Gray,
        Blue,
    }

    public List<Texture2D> FrameColorTexture;

    //public bool isLoading = true;  // Flag to check if an image is currently being loaded
    private float totalHeight = 0;  // Total height of all loaded images
        
    public bool syncState;  // Total height of all loaded images
    [Range(0.0f, 1.0f)]
    public float state = 0;  // Total height of all loaded images
    [Range(0.0f, 1.0f)]
    public float stateLogo = 0;  // Total height of all loaded images
    [Range(0.0f, 1.0f)]
    public float stateHex = 0;  // Total height of all loaded images


    [Range(0.0f, 1.0f)]
    public float stateContrast = 0;  // Total height of all loaded images

    public List<Material> materials;
    
    public AnimationCurve SlideCurve;
    // public AnimationCurve FadeCurve;

    public float targetLogoScale; 
    public float targetLogoRotation0; 
    public float targetLogoRotation1; 
    // public AnimationCurve fadeInAnimation; 
    public AnimationCurve xScaleAnimation;
    public AnimationCurve scaleUpAnimation;

    // public AnimationCurve blendAnimation; 
    private FrameColor _currentColor;
    public FrameColor current_color;

    public List<RawImage> ManagedFade;

    public bool doExpandEditor;
    public bool doCloseEditor;

    private int target_state;
    void OnValidate() {
        DoUpdate();
        if (doExpandEditor) {
            DoExpand(2f);
            doExpandEditor = false;
        }
        if (doCloseEditor) {
            DoClose(2f);
            doCloseEditor = false;
        }
        
    }

    void UpdateLogo(float t){
        float t_blend;
        float x_scale = 1.0f;
        float scale_up = 1.0f;
        float cutoff_1 = 9.0f/22;
        float cutoff_2 = 14.0f/22;
        float t_fade = 1;
        if (t <= cutoff_1) {
            t_blend = Mathf.Lerp(1,0,t/cutoff_1);
            x_scale = xScaleAnimation.Evaluate(t/cutoff_1);
        } else if ( t <= cutoff_2 ) {
            t_blend =0;
        } else {
            float t_local = (t-cutoff_2) /(1-cutoff_2);
            t_blend = Mathf.Lerp(0,1,t_local);
            scale_up = 1 + scaleUpAnimation.Evaluate(t_local);
            t_fade =  Mathf.Lerp(1,0,t_local);
        }
        foreach (var material in materials) {
            material.SetFloat("_Blend", Mathf.Lerp( 0.0f,1.0f,t_blend ));
            material.SetFloat("_Fade",Mathf.Lerp( 0.0f,1.0f, t_fade));
        }
        var baseScale = new Vector3(x_scale, 1,1)*scale_up;
        mainLogo.localScale = baseScale;
    }

    void UpdateHex(float t){
        float expand = 0;
        float fade = 0;
        float flip = 0;
        if (t == 0) {
           
        } else if (t <= 0.5) {
            float t_local = t / 0.5f;
            fade = 0.4f;
            expand = Mathf.Lerp(0.3f,1.2f,t_local);
        } else {
            float t_local = (t - 0.5f) / 0.5f;
            flip = 1;
            fade = 0.4f;
            expand = Mathf.Lerp(0.0f,1.5f,t_local);
        }

        hexEffect.material.SetFloat("_Fade",fade);
        hexEffect.material.SetFloat("_MaskFlip",flip);
        hexEffect.material.SetFloat("_MaskRadius",expand);
        

    }

    void UpdateContrast(float t){
        float expand = 0;
        float flip = 0;
        if (t == 0) {
           
        } else if (t <= 0.4) {
            float t_local = t / 0.3f;
            expand = Mathf.Lerp(0.0f,0.37f,t_local);
        } else if (t <= 0.7) {
            float t_local = (t - 0.4f) / 0.3f;
            flip = 0;
            expand = Mathf.Lerp(0.37f,1.2f,t_local);
        } else {
            float t_local = (t - 0.7f) / 0.3f;
            flip = 1;
            expand = Mathf.Lerp(0.0f,1.5f,t_local);
        }

        contrastFilter.material.SetFloat("_MaskFlip",flip);
        contrastFilter.material.SetFloat("_MaskRadius",expand);

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
                    ManagedFade[0].texture = FrameColorTexture[0];
                }
                break;
                case FrameColor.Gray: {
                    ManagedFade[0].texture = FrameColorTexture[1];
                }
                break;
                case FrameColor.Blue: {
                    ManagedFade[0].texture = FrameColorTexture[2];
                }
                break;
            }
        }
        _currentColor = current_color;
    }



    void UpdateState(float t) {
        float cutoff_1 = 14.0f / 30 ;
        float cutoff_2 = 22.0f / 30 ;
        // Logo
        stateLogo = Mathf.Clamp(t / cutoff_2,0,1);
        // Hex
        stateHex = Mathf.Clamp(
            (t-cutoff_1) / (1-cutoff_1),0,1
        );
        //Contrast
        if (t <= cutoff_1) {
            var local_t = t / cutoff_1;
            stateContrast = Mathf.Lerp(0,0.4f,local_t);
        } else {
            stateContrast = Mathf.Lerp(0.4f,1,stateHex);
        }
    }
    public Tween DoExpand(float duration) {
       
        var Seq = DOTween.Sequence();
        gameObject.SetActive(true);
        SetState(0);
        Seq.Insert(0,
            DOTween.To(
                   ()=>state,(float v)=>{state = v;},1.0f,duration 
                )
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
        SetState(0);
        gameObject.SetActive(false);
    }

    public Tween DoClose(float duration) {
        gameObject.SetActive(true);
        SetState(1);
        if (duration == 0) {
            target_state = 0;
            CleanUpOnKill();
            return null;
        }
        var Seq = DOTween.Sequence();
        Seq.Insert(0,
                DOTween.To(
                   ()=>state,(float v)=>{state = v;},0.0f,duration 
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
        if (syncState) {
            UpdateState(state);
        }
        UpdateLogo(stateLogo);
        UpdateHex(stateHex);
        UpdateContrast(stateContrast);
    }

    void SetState(float t) {
        state = t;
        DoUpdate();
    }
    
    
}
}