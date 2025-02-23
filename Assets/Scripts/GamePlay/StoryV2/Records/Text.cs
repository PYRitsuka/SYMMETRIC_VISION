using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
namespace GamePlay.StoryV2.Record.TextCommand
{
    public class ChangeAlpha : Base
    {
        public float alphaBegin = 0;
        public float alphaEnd = 1;
        public float time = 0.5f;

        public ChangeAlpha(float alphaBegin, float alphaEnd, float time)
        {
            this.alphaBegin = alphaBegin;
            this.alphaEnd = alphaEnd;
            this.time = time;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            // Assuming method to find UI elements exists
            Debug.Log($"{environment==null} {environment?.textResolver==null}");
            var animation = environment.textResolver.TransitAlpha(
                alphaBegin, alphaEnd, time
            );
            HandleAnimationDefault(animation, environment);
        }

    }

    public class ShowText : Base
    {

        public string mode = "";
        public string name = "";
        public string dialogue = "";
        public string avater = "";
        public float speed = -1;
        public ShowText() { }
        public ShowText(string mode, string name, string dialogue, string avater, float speed)
        {
            this.mode = mode;
            this.name = name;
            this.dialogue = dialogue;
            this.avater = avater;
            this.speed = speed;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            if (mode != "")
            {
                environment.textResolver.ChangeFrameType(mode);
            }
            environment.textResolver.ChangeContent(
                name, dialogue, avater
            );
            if (environment.isSkipping) {
                environment.textResolver.Display(9999);
                DOVirtual.DelayedCall(0.1f,SetComplete);
                return;
            } else if(environment.IsFastForwarding()) {
               environment.textResolver.Display(9999);
               SetComplete();
                return;
            }
            var animation = environment.textResolver.Display(speed);
            //TODO: interrupt by click
            if (animation != null)
            {
                animation.OnComplete(SetComplete);
                environment.OnUserClick.Subscribe(
                (x) =>
                {
                    Debug.Log($"Callback #1 {animation.IsComplete()}");
                    if (animation.IsPlaying() && !IsComplete())
                    {
                        if (!environment.CanSkipAnimation() ) {
                            x.StopPropagation = true;
                            return;
                        }
                        animation.Kill(true);
                        x.StopPropagation = true;
                    }
                }, 90
            );
            }
            else
            {
                SetComplete();
            }

        }

    }

    public class SetTextSpeed : Base
    {
        public float speed = -1;

        public SetTextSpeed(float speed)
        {
            this.speed = speed;
        }
        public override void Start(ScriptResolverV2 environment)
        {
            environment.textResolver.currSpeed = speed;
            SetComplete();
        }
    }

    public class SetFontSize : Base
    {
        public int size = 32;

        public SetFontSize(int size)
        {
            this.size = size;
        }
        public override void Start(ScriptResolverV2 environment)
        {
            environment.textResolver.fontSize = size;
            SetComplete();
        }
    }
}