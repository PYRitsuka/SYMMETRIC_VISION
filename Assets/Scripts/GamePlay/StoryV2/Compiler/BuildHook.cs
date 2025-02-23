
// using System.Diagnostics;
// using UnityEditor.Build;
// using UnityEditor.Build.Reporting;
// using UnityEngine;
// using UnityEditor;
// using System.IO;


// Disabled, Please use manual compiling!!!!!!!!!!!!!!!!!!

// public class PreBuildRunner : IPreprocessBuildWithReport
// {
//     public int callbackOrder { get { return 0; } }  // This defines the order in the build process

//     public void OnPreprocessBuild(BuildReport report)
//     {
//         UnityEngine.Debug.Log("Python script Callback!");
//         RunPythonScript();
//     }

//     [InitializeOnLoadMethod]
//     static void OnEditorLoad()
//     {
//         RunPythonScript();
//     }

//     static void RunPythonScript()
//     {
//         ProcessStartInfo start = new ProcessStartInfo();
//         start.FileName = "python"; // Make sure python is in your PATH or specify the exact path
//         start.Arguments = "Assets/Scripts/GamePlay/StoryV2/Compiler/hook.py"; // Path to your Python script
//         start.UseShellExecute = false;
//         start.RedirectStandardOutput = true;
//         start.RedirectStandardError = true; // Also consider capturing standard error
//         start.CreateNoWindow = true;

//         using (Process process = Process.Start(start))
//         {
//             // Read the standard output of the app and log it in Unity.
//             using (StreamReader reader = process.StandardOutput)
//             {
//                 string result = reader.ReadToEnd();
//                 UnityEngine.Debug.Log("Python script output: " + result);
//             }

//             // Optionally, also capture and log any error output
//             using (StreamReader reader = process.StandardError)
//             {
//                 string errors = reader.ReadToEnd();
//                 if (!string.IsNullOrEmpty(errors))
//                 {
//                     UnityEngine.Debug.LogError("Python script error output: " + errors);
//                 }
//             }
//         }
//     }
// }
