using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
namespace GamePlay.StoryV2.Record.Engine
{

    public class SetUIMode : Base
    {
        int mode;

        public SetUIMode(int mode)
        {
            this.mode = mode;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            environment.uIModeController.SetUIMode(mode);
            SetComplete();
        }

    }

    public class SetChapter : Base
    {
        string id;
        string title;

        public SetChapter(string id, string title)
        {
            this.id = id;
            this.title = title;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            environment.SetChapter(id, title);
            SetComplete();
        }

    }

    public class JumpToScript : Base
    {
        string script;

        public JumpToScript(string script)
        {
            this.script = script;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            environment.JumpToScriptRetainAuto(script);
            SetComplete();
        }

    }

    public class SetVisionTrigger : Base
    {
        int animationId;
        string script;

        public SetVisionTrigger(int animationId, string script)
        {
            this.animationId = animationId;
            this.script = script;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            environment.SetVisionTrigger(animationId, script);
            SetComplete();
        }

    }

    public class DisableVisionTrigger : Base
    {


        public override void Start(ScriptResolverV2 environment)
        {
            environment.DisableVisionTrigger();
            SetComplete();
        }

    }




    public class VisionChange : Base
    {
        int animationId;
        string script;

        bool StopBGM;

        public VisionChange(int animationId, string script, bool stopBGM)
        {
            this.animationId = animationId;
            this.script = script;
            StopBGM = stopBGM;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            environment.VisionChange(animationId, script, StopBGM);
            SetComplete();
        }

    }


    public class BackToTitle : Base
    {


        public override void Start(ScriptResolverV2 environment)
        {
            environment.BackToTitle();
            SetComplete();
        }

    }

    
    public class ClearScene : Base
    {


        public override void Start(ScriptResolverV2 environment)
        {
            environment.Reset();
            environment.PushCheckpoint();
            SetComplete();
        }

    }


    public class Select : Base
    {
        string key;
        List<string> selections;

        public Select(string key, string opt1, string opt2, string opt3, string opt4, string opt5)
        {
            this.key = key;
            this.selections = new();
            if (!string.IsNullOrEmpty(opt1))
            {
                selections.Add(opt1);
            }
            if (!string.IsNullOrEmpty(opt2))
            {
                selections.Add(opt2);
            }
            if (!string.IsNullOrEmpty(opt3))
            {
                selections.Add(opt3);
            }
            if (!string.IsNullOrEmpty(opt4))
            {
                selections.Add(opt4);
            }
            if (!string.IsNullOrEmpty(opt5))
            {
                selections.Add(opt5);
            }

        }

        public override void Start(ScriptResolverV2 environment)
        {
            var animation = environment.StartSelect(key,selections);
            
            if (animation != null)
            {
                animation.OnComplete(SetComplete);
                // selection cannot be skipped
            }
            else
            {
                SetComplete();
            }

        }

    }





}