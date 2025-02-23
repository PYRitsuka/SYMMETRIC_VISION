using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
namespace GamePlay.StoryV2.Record
{
    public abstract class Base
    {
        public abstract void Start(ScriptResolverV2 environment);
        public virtual bool IsComplete()
        {
            return isComplete;
        }

        public bool isComplete;

        public void SetComplete()
        {
            isComplete = true;
        }

        public virtual void HandleAnimationDefault(Tween animation, ScriptResolverV2 environment)
        {
            if (animation != null)
            {
                animation.OnComplete(SetComplete);
                environment.OnUserClick.Subscribe(
                    (x) =>
                    {
                        if (!animation.IsComplete() && animation.IsPlaying() && !IsComplete())
                        {
                            //Debug.Log($"CanSkipAnimation? {environment.CanSkipAnimation()}");
                            if (!environment.CanSkipAnimation())
                            {
                                x.StopPropagation = true;
                                x.KeepOnComplete = true;
                                return;
                            }
                            animation.Kill(true);

                        }
                    }, 99 // before 100 which is waitfor click
                );
            }
            else
            {
                SetComplete();
            }

        }
    }



}