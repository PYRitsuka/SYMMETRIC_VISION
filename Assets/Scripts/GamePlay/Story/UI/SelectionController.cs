using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamePlay.Story.Backlog;
using Lean.Gui;
using TMPro;
using UnityEngine;
using Utils;

namespace GamePlay.Story.UI
{
    public class SelectionController : MonoBehaviourSingleton<SelectionController>
    {
        [SerializeField] private List<LeanButton> selectButtons;
        [SerializeField] private LeanWindow selectionWindow;

        //public async Task<int> StartSelectAsync(string content)
        //{
            // var selections = content.Split(new[] {'{', '}'}, StringSplitOptions.RemoveEmptyEntries).Where(x => x != ";")
            //     .Select(x => x.TrimStart('{').TrimEnd('}')).ToList();
            // var selectionContents = selections.Select(x => x.Split(';').FirstOrDefault()).ToList();
            // var selectionResults = selections.Select(x => x.Split(';').LastOrDefault().ToInt()).ToList();
            
            // var hashCode = ScriptResolver.ScriptFileName.GetHashCode() ^ (ScriptResolver.SelectedNumber + 0x15).GetHashCode();
            // if (ScriptResolver.IsJumping ||  && ScriptResolver.UserSelections.ContainsKey(hashCode))
            // {
            //     return selectionResults[ScriptResolver.UserSelections[hashCode]];
            // }
            
            // ScriptResolver.IsSelecting = true;

            // var cnt = selections.Count;

            // var chosenSelection = -1;

            // List<Task<bool>> tasks = new();

            // for (var i = 0; i < selectButtons.Count; i++)
            // {
            //     selectButtons[i].gameObject.SetActive(i < cnt);
            //     if (i >= cnt) continue;
            //     selectButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = selectionContents[i];
            //     var i1 = i;
            //     var buttonClickedTask = new TaskCompletionSource<bool>();
            //     tasks.Add(buttonClickedTask.Task);
            //     selectButtons[i].OnClick.AddListener(delegate
            //     {
            //         chosenSelection = i1;
            //         buttonClickedTask.SetResult(true);
            //     });
            // }
            
            // selectionWindow.TurnOn();
            // await Task.WhenAny(tasks.ToArray());
            // selectionWindow.TurnOff();
            // ScriptResolver.IsSelecting = false;
            // hashCode = ScriptResolver.ScriptFileName.GetHashCode() ^ (ScriptResolver.SelectedNumber + 0x15).GetHashCode();
            // if (!ScriptResolver.UserSelections.TryAdd(hashCode, chosenSelection))
            // {
            //     ScriptResolver.UserSelections[hashCode] = chosenSelection;
            // }
            // BacklogManager.Instance.AppendLog("", $"<style=selection>{selectionContents[chosenSelection]}</style>");
            // ScriptResolver.SelectedNumber++;
            // return selectionResults[chosenSelection];
        //}
        
        public int StartSelect(string content)
        {
            var selections = content.Split(new[] {'{', '}'}, StringSplitOptions.RemoveEmptyEntries).Where(x => x != ";")
                .Select(x => x.TrimStart('{').TrimEnd('}')).ToList();
            var selectionContents = selections.Select(x => x.Split(';').FirstOrDefault()).ToList();
            var selectionResults = selections.Select(x => x.Split(';').LastOrDefault().ToInt()).ToList();
            
            var hashCode = ScriptResolver.ScriptFileName.GetHashCode() ^ (ScriptResolver.SelectedNumber + 0x15).GetHashCode();
            if (ScriptResolver.UserSelections.ContainsKey(hashCode))
            {
                ScriptResolver.SelectedNumber++;
                BacklogManager.Instance.AppendLog("", $"<style=selection>{selectionContents[ScriptResolver.UserSelections[hashCode]]}</style>");
                return selectionResults[ScriptResolver.UserSelections[hashCode]];
            }
            return -1;
        }
    }
}