using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
using Unity.VisualScripting;
namespace GamePlay.StoryV2.Record.Camera
{
    
    public class PlayFx : Base
    {
        string name;
        float duration;

        public PlayFx(string name, float duration)
        {
            this.name = name;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.cameraResolver;
            if (environment.isSkipping) {
                duration = 0;
            }
            manager.PlayFX(name,duration);
            SetComplete();
        }

    }

    public class KeepBumpy : Base
    {
        float strength;
        float duration;

        public KeepBumpy(float strength, float duration)
        {
            this.strength = strength;
            this.duration = duration;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.cameraResolver;
            manager.KeepBumpy(duration,strength);
            SetComplete();
        }

    }

    public class StopAction : Base
    {
        string action;

        public StopAction(string action)
        {
            this.action = action;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.cameraResolver;
            manager.StopAction(action);
            SetComplete();
        }

    }


}