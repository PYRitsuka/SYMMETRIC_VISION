using System;
using Save;

namespace Utils.StoryScriptFunctions
{
    public class Trigger : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 2;
        
        protected override void FunctionMain(string[] data)
        {
            var variableName = data[0];
            var result = data[1].ToLower() == "true";

            // if (!GlobalSaveManager.CurrentSave.BoolProperties.TryAdd(variableName, result))
            //     GlobalSaveManager.CurrentSave.BoolProperties[variableName] = result;
            // GlobalSaveManager.SaveFile();
        }
    }
}