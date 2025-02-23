using System;
using System.Globalization;
using GamePlay.Story;
using UI.VisionTrigger;

namespace Utils.StoryScriptFunctions
{
    public class VisionTrigger : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x is 1 or 3;
        
        protected override void FunctionMain(string[] data)
        {
            data[0] = data[0].ToLower(CultureInfo.InvariantCulture);
            if (data[0] != "true" && data[0] != "false")
            {
                LogInvalidArgument(data[0]);
            }
            else
            {
                if (data[0] == "true")
                {
                    ScriptResolver.CanVisionTrigger = true;
                    VisionTriggerUIController.AnimationId = data[1].ToInt();
                    VisionTriggerUIController.NextScript = data[2];
                }
                else
                {
                    ScriptResolver.CanVisionTrigger = false;
                }
            }
        }
    }
}