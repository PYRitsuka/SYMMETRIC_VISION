using System;
using Save;

namespace Utils.StoryScriptFunctions
{
    public class StoryArrow : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 2;
        
        protected override void FunctionMain(string[] data)
        {
            if (!int.TryParse(data[0], out var id))
            {
                return;
            }
            
            var result = data[1].ToLower() == "true";

            // if (!GlobalSaveManager.CurrentSave.StoryArrowUnlockList.TryAdd(id, result))
            //     GlobalSaveManager.CurrentSave.StoryArrowUnlockList[id] = result;
            // GlobalSaveManager.SaveFile();
        }
    }
}