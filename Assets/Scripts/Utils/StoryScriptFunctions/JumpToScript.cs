using System;
using Common;
using GamePlay.Story;
using UnityEngine;
using GamePlay.Story.RecordsResolver;

namespace Utils.StoryScriptFunctions
{
    internal class JumpToScript : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            var key = $"脚本/{data[0]}";
            GamePlay.Story.ScriptResolver.SetCurrentNode(key);
            var asset = StoryUtils.LoadResource<TextAsset>(key);
            
            if (asset.Equals(null))
            {
                LogInvalidArgument(data[0]);
            }
            else
            {
                BGMResolver.Instance.StopManually();
                Debug.Log($"Jump to script: {data[0]}");
                //ScriptResolver.Instance.ResetStoryCanvas();
                ScriptResolver.ScriptFileName = data[0];
                ScriptResolver.ReloadScript(asset, null);
                _ = SceneTransit.Instance.TransitTo("StoryScene");
            }
        }
    }
}