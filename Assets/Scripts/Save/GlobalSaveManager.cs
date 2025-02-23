using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using Utils;
using Random = System.Random;

namespace Save
{
    public static class GlobalSaveManager
    {
        private static string _savePath = "";
        
        private static readonly byte[] SavePassword = { 0x1D, 0x04, 0x85, 0x96 };

        public static GlobalSaveStruct CurrentSave { get; private set; }


        static void SetSavePath() {
            if (string.IsNullOrEmpty(_savePath)) {
                _savePath = Path.Combine(Application.persistentDataPath, "globalSave.json");
                Debug.Log($"Save Path is {_savePath}");
            }
        }
        public static void LoadSave()
        {
            SetSavePath();
            
            if (!File.Exists(_savePath))
            {
                CurrentSave = new GlobalSaveStruct();
                SaveFile();
            } 
            string saveData = File.ReadAllText(_savePath);
            CurrentSave = JsonConvert.DeserializeObject<GlobalSaveStruct>(saveData);
            EnsureNotNull();
            SaveFile();
        }

        private static void EnsureNotNull()
        {
            CurrentSave.SystemFlag ??= new Dictionary<string, bool>();
        }

        // query by internal key
        public static bool HasSystemFlag(string key)
        {
            bool value;
            Debug.Log($"Test System Flag {key} :{JsonConvert.SerializeObject(CurrentSave.SystemFlag)}");
            if (CurrentSave.SystemFlag.TryGetValue(key, out value))
            {
                Debug.Log($"System Flag Check Hit {key}:{value}");
                return value;
            }
            Debug.Log($"System Flag Check Miss {key},fallback is false by default");
            return false;
        }

        // query by name,id

        public static bool HasIndexedSystemFlag(string name,int id) {
            return HasSystemFlag($"SYSTEM__{name}_{id}");
        }


        // query by name
        public static bool HasNameddSystemFlag(string name) {
            return HasSystemFlag($"SYSTEM__{name}");
        }

        public static void SaveFile()
        {
            SetSavePath();
            string json_str = JsonConvert.SerializeObject(CurrentSave);
            File.WriteAllText(_savePath, json_str);
            PlayerPrefs.Save();
        }

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr handle, String message, String title, int type);
#endif

        public class GlobalSaveStruct //可扩展！
        {
            [JsonProperty("bl")] public Dictionary<string, bool> SystemFlag { get; set; } = new();
            // [JsonProperty("sa")] public Dictionary<int, bool> StoryArrowUnlockList { get; set; } = new();
            // [JsonProperty("sb")] public Dictionary<int, bool> StoryBlockUnlockList { get; set; } = new();
        }
    }
}