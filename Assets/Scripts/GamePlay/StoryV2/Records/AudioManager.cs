using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
namespace GamePlay.StoryV2.Record.AudioManager
{

    public class SetBGM : Base
    {
        string audio;
        float volume;
        bool loop;

        float begin = 0;
        float end = 0;

        public SetBGM(string audio, float volume, bool loop, float begin, float end)
        {
            this.audio = audio;
            this.volume = volume;
            this.loop = loop;
            this.begin = begin;
            this.end = end;
        }
        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.audioResolver;
            manager.PlayBGM(audio, volume, loop, begin, end);
            SetComplete();
        }

    }

    public class VolumeChange : Base
    {
        float duration;
        float begin = 0;
        float end = 0;

        public VolumeChange(float duration, float begin, float end)
        {
            this.duration = duration;
            this.begin = begin;
            this.end = end;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.audioResolver;
            if (environment.isSkipping || environment.IsFastForwarding()) {
                duration = 0; // skip changes
            }
            manager.VolumeChange(begin, end, duration);
            SetComplete();
        }

    }

    public class SetSE : Base
    {
        string audio;
        float volume;
        bool loop;

        public SetSE(string audio, float volume, bool loop)
        {
            this.audio = audio;
            this.volume = volume;
            this.loop = loop;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.audioResolver;
            if (environment.IsFastForwarding() && !loop)
            {
                SetComplete();
                return;
            } // Dont play SE if loading saves and SE is not looping
            manager.PlaySE(audio, volume, loop);
            SetComplete();
        }

    }

    public class StopSE : Base
    {


        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.audioResolver;
            manager.StopSE();
            SetComplete();
        }

    }

}