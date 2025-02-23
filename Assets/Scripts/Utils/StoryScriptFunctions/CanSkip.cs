using System;
using System.Globalization;
using GamePlay.Story;
using UnityEngine;

namespace Utils.StoryScriptFunctions
{
    internal class CanSkip : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            data[0] = data[0].ToLower(CultureInfo.InvariantCulture); //谁叫剧本一定首字母大写呢（（
            
            if (data[0] != "true" && data[0] != "false")
            {
                LogInvalidArgument(data[0]);
            }
            else
            {
                Debug.Log($"Set can skip: {data[0]}");
                ScriptResolver.IsAutoPlay = false;
                ScriptResolver.IsSkipping = false;
                ScriptResolver.CanSkip.Value = data[0] == "true";
            }
        }
    }
}