using System;
using UnityEngine;
using Utils;

namespace Common
{
    public class MobilePlatformScriptController : MonoBehaviourSingleton<MobilePlatformScriptController>
    {
        public static bool isMobile;
        public bool debugMobile;
        private void Start()
        {
            if (!Application.isMobilePlatform && !debugMobile) {
                Destroy(gameObject);
                return;
            }
                
            isMobile = true;
        }
    }
}