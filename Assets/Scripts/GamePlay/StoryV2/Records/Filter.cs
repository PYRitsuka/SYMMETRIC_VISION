using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Record;
namespace GamePlay.StoryV2.Record.Filter
{
    
    public class SetFilter : Base
    {
        string name;
        bool enabled;

        public SetFilter(string name, bool enabled)
        {
            this.name = name;
            this.enabled = enabled;
        }

        public override void Start(ScriptResolverV2 environment)
        {
            var manager = environment.filterResolver;
            manager.SetEnabled(name,enabled);
            SetComplete();
        }

    }


}