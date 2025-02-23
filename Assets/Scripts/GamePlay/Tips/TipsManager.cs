using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Save;
using UnityEngine;
using Utils;

namespace GamePlay.Tips
{
    // public class TipsManager : MonoBehaviour
    // {
    //     public static TipsManager Instance { get; private set; }
    //
    //     private bool[] _resolvedTips = new bool[70];
    //
    //     void Awake()
    //     {
    //         if (Instance != null)
    //         {
    //             Destroy(Instance.gameObject);
    //         }
    //         Instance = this;
    //         
    //         LoadTipsFromSave();
    //     }
    //
    //     private void LoadTipsFromSave()
    //     {
    //         var data = GlobalSaveManager.CurrentSave.tips.Data;
    //         var resolved = data != null ? Encoding.Default.GetString(data) : GetResolvedTipsSave();
    //         _resolvedTips = resolved.Split(" ").ToList().ConvertAll(Convert.ToBoolean).ToArray();
    //     }
    //
    //     private void SaveTips()
    //     {
    //         GlobalSaveManager.CurrentSave.tips.Data = Encoding.Default.GetBytes(GetResolvedTipsSave());
    //         GlobalSaveManager.SaveFile();
    //     }
    //
    //     private string GetResolvedTipsSave()
    //     {
    //         return string.Join(" ", _resolvedTips.ToList());
    //     }
    //
    //     public void ResolveTip(int index)
    //     {
    //         _resolvedTips[index] = true;
    //         SaveTips();
    //     }
    //
    //     public bool IsResolved(int index)
    //     {
    //         return _resolvedTips[index];
    //     }
    // }
}
