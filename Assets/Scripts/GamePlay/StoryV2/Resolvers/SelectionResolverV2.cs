using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamePlay.Story.Backlog;
using Lean.Gui;
using TMPro;
using UnityEngine;
using Utils;
using UnityEngine.UI;
namespace GamePlay.StoryV2.RecordsResolver
{
    public class SelectionResolverV2 : MonoBehaviourSingleton<SelectionResolverV2>
    {
        [SerializeField] private List<LeanButton> selectButtons;
        [SerializeField] private LeanWindow selectionWindow;

        public void StartSelect(List<string> selections,Action<int> callback)
        {

            var cnt = selections.Count;

            for (var i = 0; i < selectButtons.Count; i++)
            {
                selectButtons[i].gameObject.SetActive(i < cnt);
                if (i >= cnt) continue;
                selectButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = selections[i];
                var i1 = i;
                selectButtons[i].OnClick.RemoveAllListeners(); // clear
                selectButtons[i].OnClick.AddListener(
                    ()=>{
                        Debug.Log("Selection Clicked!");
                        selectionWindow.TurnOff();
                        callback(i1);
                    }
                );
            }
            
            selectionWindow.TurnOn();
            return;
        }
        

    }
}