// using UnityEngine;
// using UnityEditor;
// using Utils.StoryScriptFunctions;
// Do not delete!!!!!, used for editor hacks !!!!!
// public class StoryLineRenamer : EditorWindow
// {
//     private GameObject selectedObject;

//     [MenuItem("Tools/SV/Storyline-Rename Jump Targets to JSON")]
//     public static void ShowWindow()
//     {
//         GetWindow<StoryLineRenamer>("Storyline-Rename Jump Target");
//     }

//     private void OnGUI()
//     {
//         GUILayout.Label("Select a GameObject", EditorStyles.boldLabel);

//         selectedObject = (GameObject)EditorGUILayout.ObjectField("GameObject", selectedObject, typeof(GameObject), true);

//         if (GUILayout.Button("OK"))
//         {
//             if (selectedObject != null)
//             {
//                 PerformOperation(selectedObject);
//             }
//             else
//             {
//                 EditorUtility.DisplayDialog("Error", "Please select a GameObject first.", "OK");
//             }
//         }
//     }

//     private void PerformOperation(GameObject obj)
//     {
//         // Your custom operation on the selected object
//         Debug.Log($"Performing operation on: {obj.name}");
//         var blocks = obj.GetComponentsInChildren<StoryBlockUIController>();
//         foreach (var block in blocks) {
//             Debug.Log($"{block.jumpToStory}");
//             if (!string.IsNullOrEmpty(block.jumpToStory)){
//                 var old_tgt = block.jumpToStory;
//                 var new_tgt = old_tgt;
//                 if (new_tgt.EndsWith(".txt")) {
//                     new_tgt = block.jumpToStory.Replace(".txt",".json");
//                 }
//                 if (!new_tgt.StartsWith("脚本/V2/")) { 
//                     new_tgt ="脚本/V2/" + new_tgt;
//                 }
//                 block.jumpToStory = new_tgt;
//                 Debug.Log($"{old_tgt}->{new_tgt}");
//             }
//         }
//     }
// }