using System;
using GamePlay.Story;
using UnityEngine;

namespace Utils.StoryScriptFunctions
{
    internal class Wait : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            if (!float.TryParse(data[0], out var sec))
            {
                LogInvalidArgument(data[0]);
            }
            else
            {
                Debug.Log($"Waiting for {sec} seconds...");
                ScriptResolver.WaitTime.Value = sec;
            }
        }
    }
}