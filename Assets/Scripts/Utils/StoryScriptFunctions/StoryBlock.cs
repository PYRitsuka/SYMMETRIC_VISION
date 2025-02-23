using System;
using Save;

namespace Utils.StoryScriptFunctions
{
    public class StoryBlock : StoryScriptFunction
    {
        protected override Func<int, bool> CheckArgumentCountFunction => x => x == 2;
        
        protected override void FunctionMain(string[] data)
        {
            if (!int.TryParse(data[0], out var id))
            {
                return;
            }
            
            var result = data[1].ToLower() == "true";

            // if (!GlobalSaveManager.CurrentSave.StoryBlockUnlockList.TryAdd(id, result))
            //     GlobalSaveManager.CurrentSave.StoryBlockUnlockList[id] = result;
            // GlobalSaveManager.SaveFile();
        }
    }
}