using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Serializable;
using UnityEngine;
using Utils;

namespace Save
{
    public static class SaveManager
    {
        private static List<StorySave> _cachedSaves;
        private static bool _isDirty = true;

        private static readonly string SavePath = Path.Combine(Application.persistentDataPath, "saves");

        public const string NullSaveIndicator = "NULL_SAVE";
        public const string QuickSaveIndicator = "QUICK_SAVE";
        private const string TemporaryScreenshotName = "temporary_screenshot.png";

        private static readonly byte[] SavePassword = { 0x1D, 0x04, 0x85, 0x96 };

        public static List<StorySave> LoadSaves()
        {
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            if (_isDirty)
            {
                var cnt = Directory
                    .GetFiles(Path.Combine(Application.persistentDataPath, "saves"))
                    .Where(s => Path.GetFileName(s).StartsWith("save")).ToList().Count;
                var f = 1;
                for (var i = 1; i <= 1000; i++)
                {
                    if (File.Exists(Path.Combine(SavePath, $"save{i:D3}")))
                    {
                        if (i != f)
                        {
                            File.Move(Path.Combine(SavePath, $"save{i:D3}"), Path.Combine(SavePath, $"save{f:D3}"));
                        }
                        f++;
                    }

                    if (cnt + 1 == f)
                    {
                        break;
                    }
                }
                _cachedSaves = Directory
                    .GetFiles(Path.Combine(Application.persistentDataPath, "saves"))
                    .Where(s => Path.GetFileName(s).StartsWith("save"))
                    .Select(i =>
                    {
                        try
                        {
                            var save = LoadSave(i);
                            if (save == null) return null;
                            var bytes = Convert.FromBase64String(save.screenshot);
                            var t2d = new Texture2D(282, 158);
                            t2d.LoadImage(bytes);
                            save.previewSprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height),
                                Vector2.one / 2f);
                            save.fileName = Path.GetFileName(i);
                            return save;
                        }
                        catch
                        {
                            Debug.LogError($"Corrupted save file: {i}");
                            return null;
                        }
                    }).ToList();
            }
            return _cachedSaves;
        }

        public static StorySave LoadSave(string path)
        {
            if (path == QuickSaveIndicator)
            {
                path = Path.Combine(Application.persistentDataPath, "qsave");
            }
            if (!File.Exists(path))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<StorySave>(ShikiCrypto
                .Decrypt(File.ReadAllBytes(path), SavePassword).StringResult);
        }

        public static void Save(StorySave save, string fileName)
        {
            if (fileName == NullSaveIndicator)
            {
                fileName = $"save{_cachedSaves.Count + 1:D3}";
            }

            File.WriteAllBytes(
                fileName == QuickSaveIndicator
                    ? Path.Combine(Application.persistentDataPath, "qsave")
                    : Path.Combine(SavePath, fileName),
                ShikiCrypto.Encrypt(JsonConvert.SerializeObject(save), SavePassword).Result);
            SetDirty();
        }

        private static void SetDirty()
        {
            _isDirty = true;
        }
    }
}