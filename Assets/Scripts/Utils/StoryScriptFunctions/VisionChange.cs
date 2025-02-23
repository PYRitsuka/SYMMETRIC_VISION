using System;
using GamePlay.Story;
using UnityEngine;
using UI.VisionTrigger;

namespace Utils.StoryScriptFunctions
{
    public class VisionChange : StoryScriptFunction
    {
        private bool stopBGM = true;
        public VisionChange(bool stopBGMFlag = true) {
            stopBGM = stopBGMFlag;
            Debug.Log($"init Stop BGM:{stopBGM}");
        }
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 2;
        
        protected override void FunctionMain(string[] data)
        {
            VisionTriggerUIController.AnimationId = data[0].ToInt();
            VisionTriggerUIController.NextScript = data[1];
            Debug.Log($"Stop BGM:{stopBGM}");
            ScriptResolver.Instance.TriggerVision_external(stopBGM);
        }
    }
}