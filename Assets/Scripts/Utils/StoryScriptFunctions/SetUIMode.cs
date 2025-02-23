using System;
using GamePlay.Story;
using GamePlay.Story.UI;
using UnityEngine;

namespace Utils.StoryScriptFunctions
{
    internal class SetUIMode : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 1;
        
        protected override void FunctionMain(string[] data)
        {
            if (!int.TryParse(data[0], out var m))
            {
                LogInvalidArgument(data[0]);
            }
            else
            {
                if (m is < 0 or > 5)
                {
                    LogInvalidArgument(data[0]);
                }
                else
                {
                    UIModeController.Instance.SetUIMode(m);
                    Debug.Log($"Set UI Mode {m}");
                }
            }
        }
    }
}