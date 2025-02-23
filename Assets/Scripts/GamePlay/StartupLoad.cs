using Save;
using UnityEngine;
using System.Globalization;
using System.Threading;
using System;

namespace GamePlay
{
    public class StartupLoad : MonoBehaviour
    {
        void Awake()
        {
        CultureInfo englishCulture = new CultureInfo("en-US"); // Very hacky fix, maybe fix in fututure

        // Set the culture for formatting numbers, dates, etc.
        CultureInfo.DefaultThreadCurrentCulture = englishCulture;

        // Set the culture for UI strings, such as resource lookups for strings.
        CultureInfo.DefaultThreadCurrentUICulture = englishCulture;

        // Optional: Set the culture for the current thread explicitly,
        // useful if you're dealing with threads directly.
        Thread.CurrentThread.CurrentCulture = englishCulture;
        Thread.CurrentThread.CurrentUICulture = englishCulture;

        // Test the setting by printing the current date
        Debug.Log($"Current date in English culture: {DateTime.Now.ToString("D", CultureInfo.CurrentCulture)}");

            Application.targetFrameRate = (int) Screen.currentResolution.refreshRateRatio.value;
            // Debug.LogError("Force the build console open...");
            if (Application.targetFrameRate >= 60)
            {
                Application.targetFrameRate = 60;
            }
            GlobalSaveManager.LoadSave();
            //Resources.LoadAll("");
        }
    }
}
