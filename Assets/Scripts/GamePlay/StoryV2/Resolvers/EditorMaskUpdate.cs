using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using DG.Tweening;
using GamePlay.Story.Record;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using UnityEngine.Video;
namespace Utils {
    [ExecuteInEditMode]
    public class MaskUpdate : MonoBehaviour
    {
        public Mask mask;

        public static void UpdateMask(Mask m) {
            m.enabled = false;
            m.enabled = true;
        }
        void Update()
        {
           UpdateMask(mask);
        }
    }
}
