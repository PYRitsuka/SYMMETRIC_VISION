using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.ResourceManagement.AsyncOperations;

#if UNITY_EDITOR
using GamePlay.Story;
using UnityEditor;
#endif
using UnityEngine.AddressableAssets;
using UnityEngine.Video;
using UnityEngine.Audio;

namespace Utils
{
    public static class StoryUtils
    {
        private static Dictionary<string, object> loadedResource = new Dictionary<string, object> ();
        public static T LoadResource<T>(string path) where T : Object
        {
            // #if UNITY_EDITOR
            //             if (path.LastIndexOf(".", StringComparison.Ordinal) == -1)
            //             {
            //                 EditorUtility.DisplayDialog("Warning: No extension", 
            //                     $"No extension specified for file at path {path}!" +
            //                     $"\nThis is okay in editor but will cause serious problems in a built game." +
            //                     $"\nPlease fix it at script {ScriptResolver.ScriptFileName}, line {ScriptResolver.ScriptLine}" + 
            //                     $"\n文件路径 {path} 没有指定文件扩展名！" +
            //                     $"\n在编辑器中这是可以的，但在构建的游戏中会引发严重问题。" +
            //                     $"\n请在脚本 {ScriptResolver.ScriptFileName} 的第 {ScriptResolver.ScriptLine} 行进行修复。", 
            //                     "Got it");
            //             }
            // #endif
            //             return Resources.Load<T>(path.WithoutExtension());            // #if UNITY_EDITOR
            if (loadedResource.ContainsKey(path)){
                object hit = loadedResource[path];
                try
                {
                    var result = (AsyncOperationHandle<T>)hit;
                        Debug.Log($"Load from cache {path}");
                        return result.WaitForCompletion();
                }
                catch (InvalidCastException)
                {
                    Debug.LogError("Failed to convert AsyncOperationHandle to AsyncOperationHandle<T> due to an invalid cast.");
                    return null;
                }

            }
            Debug.Log($"Load from disk {path}");
            var operation = Addressables.LoadAssetAsync<T>($"Assets/Addressables/{path}");
            Debug.Log($"Success!,Load from disk {path}");
            // if (!operation.IsValid())
            // {
            //     return null;
            // }
            loadedResource[path] = operation;
            return operation.WaitForCompletion();

        }

        public static int GetResourceCount()  {
            return loadedResource.Count;
        }


        public static void preloadResources(string type,string path) {
            switch (type){
                case "Texture":
                    preloadResources<Texture>(path);
                    break;
                case "AudioClip":
                    preloadResources<AudioClip>(path);
                    break;
                case "VideoClip":
                    preloadResources<VideoClip>(path);
                    break;
                default:
                    Debug.Log("Preload: Unknown Resources {type} {path}");
                    break;
            }
        }

        public static void ReleaseResources(string type, string path)
        {
            switch (type)
            {
                case "Texture":
                    ReleaseResources<Texture>(path);
                    break;
                case "AudioClip":
                    ReleaseResources<AudioClip>(path);
                    break;
                case "VideoClip":
                    ReleaseResources<VideoClip>(path);
                    break;
                default:
                    Debug.Log("Preload: Unknown Resources {type} {path}");
                    break;
            }
        }

        public static void ReleaseResources<T>(string path)  {
            if (!loadedResource.ContainsKey(path)) {
                return;
            }

            object hit = loadedResource[path];
            try
            {
                var result = (AsyncOperationHandle < T > ) hit;
                Debug.Log($"Try Delete {path}");
                result.WaitForCompletion();
                loadedResource.Remove(path);
                while (result.IsValid())
                {
                    Addressables.Release(result);
                }
            }
            catch (InvalidCastException)
            {
                Debug.LogError("Failed to convert AsyncOperationHandle in releasing");
                return;
            }

            

            // foreach (var asset in AssetHandles.Where(asset => asset.IsDone))
            // {
            //     while (asset.IsValid())
            //     {
            //         Addressables.Release(asset);
            //     }
            // }

        }

        public static AsyncOperationHandle<T>? preloadResources<T>(string path) where T : Object
        {
            // #if UNITY_EDITOR
            //             if (path.LastIndexOf(".", StringComparison.Ordinal) == -1)
            //             {
            //                 EditorUtility.DisplayDialog("Warning: No extension", 
            //                     $"No extension specified for file at path {path}!" +
            //                     $"\nThis is okay in editor but will cause serious problems in a built game." +
            //                     $"\nPlease fix it at script {ScriptResolver.ScriptFileName}, line {ScriptResolver.ScriptLine}" + 
            //                     $"\n文件路径 {path} 没有指定文件扩展名！" +
            //                     $"\n在编辑器中这是可以的，但在构建的游戏中会引发严重问题。" +
            //                     $"\n请在脚本 {ScriptResolver.ScriptFileName} 的第 {ScriptResolver.ScriptLine} 行进行修复。", 
            //                     "Got it");
            //             }
            // #endif
            //             return Resources.Load<T>(path.WithoutExtension());            // #if UNITY_EDITOR
            if (loadedResource.TryGetValue(path, out var hit))
            {
                Debug.Log($"PreLoad from cache {path}");
                try
                {
                    var result = (AsyncOperationHandle<T>)hit;
                        Debug.Log($"Load from cache {path}");
                        return result;
                }
                catch (InvalidCastException)
                {
                    Debug.LogError("Failed to convert AsyncOperationHandle to AsyncOperationHandle<T> due to an invalid cast.");
                }
            }
            Debug.Log($"PreLoad from disk {path}");
            var operation = Addressables.LoadAssetAsync<T>($"Assets/Addressables/{path}");
            if (!operation.IsValid())
            {
                Debug.Log("Invalid Operation!");
                return null;
            }
            loadedResource[path] = operation;
            return operation;
        }

        public static void UnloadUnusedAssets()
        {
            Resources.UnloadUnusedAssets();
        }

        public static List<string> SplitSemicolon(this string org)
        {
            var a = org.Split(";").ToList();
            a = a.Select(s => s.Trim()).ToList();
            return a;
        }

        public static float ToFloat(this string s)
        {
            return Convert.ToSingle(s);
        }

        public static int ToInt(this string s)
        {
            return Convert.ToInt32(s);
        }

        public static bool CheckUserCancelInput()
        {
            return Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape);
        }

        public static bool CheckVisionTriggerInput()
        {
            return Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(2);
        }

        private static string WithoutExtension(this string s)
        {
            var dotIndex = s.LastIndexOf(".", StringComparison.Ordinal);
            return s.Substring(0, dotIndex == -1 ? s.Length : dotIndex);
        }

        public static Texture2D ResizeTexture(this Texture2D sourceTexture, int newWidth, int newHeight)
        {
            // Create a new destination texture with the desired size
            Texture2D resizedTexture = new Texture2D(newWidth, newHeight);

            // Loop through each pixel in the resized texture
            for (int y = 0; y < newHeight; y++)
            {
                for (int x = 0; x < newWidth; x++)
                {
                    // Calculate the corresponding UV coordinates in the source texture
                    float u = x / (float)newWidth;
                    float v = y / (float)newHeight;

                    // Sample the color from the source texture at the calculated UV coordinates
                    Color color = sourceTexture.GetPixelBilinear(u, v);

                    // Set the color of the pixel in the resized texture
                    resizedTexture.SetPixel(x, y, color);
                }
            }

            // Apply the changes to the resized texture
            resizedTexture.Apply();

            return resizedTexture;
        }
    }
}