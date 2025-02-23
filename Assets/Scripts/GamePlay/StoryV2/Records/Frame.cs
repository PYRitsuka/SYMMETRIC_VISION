using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
namespace GamePlay.StoryV2.Record.Frame
{
    public class BMIOn : Base
    {
        string color;

        float duration;

        public BMIOn(string color, float duration)
        {
            this.color = color;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.bmi;
            frame.SetColor(color);
            var animation = frame.DoExpand(duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class BMIOff : Base
    {
        string color;

        float duration;

        public BMIOff(string color, float duration)
        {
            this.color = color;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.bmi;
            frame.SetColor(color);
            var animation = frame.DoClose(duration);
            HandleAnimationDefault(animation, environment);
        }
    }


    public class ViewOn : Base
    {
        public string image;
        string color;

        float duration;

        public ViewOn(string image, string color, float duration)
        {
            this.image = image;
            this.color = color;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.viewFrame;
            frame.SetColor(color);
            frame.SetTexture(image);
            var animation = frame.DoExpand(duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class ViewChange : Base
    {
        public string image;

        float duration;

        public ViewChange(string image, float duration)
        {
            this.image = image;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.viewFrame;
            var animation = frame.SetTexture(image,duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class ViewOff : Base
    {

        float duration;

        public ViewOff( float duration)
        {
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.viewFrame;
            var animation = frame.DoClose(duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class PictureOn : Base
    {
        public string image;
        string color;

        float duration;

        public PictureOn(string image, string color, float duration)
        {
            this.image = image;
            this.color = color;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            
            var frame = environment.imageDisplay;
            frame.SetColor(color);
            frame.SetTexture(image);
            var animation = frame.DoExpand(duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class PictureChange : Base
    {
        public string image;

        float duration;

        public PictureChange(string image, float duration)
        {
            this.image = image;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var animation = frame.SetTexture(image,duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class PictureOff : Base
    {

        float duration;

        public PictureOff( float duration)
        {
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var animation = frame.DoClose(duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class RineOn : Base
    {
        public string title;

        float duration;

        public RineOn(string title)
        {
            this.title = title;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var rine = environment.rineFrame;
            var animation = rine.DoExpand(1.5f);
            // var animation = frame.SetTexture(image,duration);
            HandleAnimationDefault(animation, environment);
        }

    }
    public class RineOff : Base
    {

        float duration;

        public RineOff()
        {
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var rine = environment.rineFrame;
            var animation = rine.DoClose(1.0f);
            // var animation = frame.SetTexture(image,duration);
            HandleAnimationDefault(animation, environment);
        }

    }

    public class RineSpeak : Base
    {
        public string image;


        public RineSpeak(string image)
        {
            this.image = image;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var rine = environment.rineFrame;
            var animation = rine.InsertImage(image);
            SetComplete();
            // var animation = frame.SetTexture(image,duration);
            // HandleAnimationDefault(animation, environment);
        }

    }

    public class RineChangeAlpha : Base
    {
        public float alpha_began;
        public float alpha_ended;
         
        public float duration;

        public RineChangeAlpha(float alpha_began, float alpha_ended, float duration)
        {
            this.alpha_began = alpha_began;
            this.alpha_ended = alpha_ended;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var frame = environment.imageDisplay;
            var rine = environment.rineFrame;
            var animation = rine.ChangeAlpha(alpha_began,alpha_ended,duration);
            HandleAnimationDefault(animation, environment);
            // var animation = frame.SetTexture(image,duration);
            // HandleAnimationDefault(animation, environment);
        }

    }

}