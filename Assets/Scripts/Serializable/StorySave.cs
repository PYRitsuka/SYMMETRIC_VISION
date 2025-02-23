using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Serializable
{
    public class StorySave
    {
        [JsonProperty("cnb")] public string chapterNumber { get; set; }
        [JsonProperty("cna")] public string chapterName { get; set; }
        [JsonProperty("ss")] public string screenshot { get; set; }
        [JsonProperty("tt")] public string text { get; set; }
        [JsonProperty("st")] public string saveTime { get; set; }
        [JsonProperty("sn")] public string scriptName { get; set; }
        [JsonProperty("sl")] public int scriptLine { get; set; }
        [JsonProperty("s2")] public int lastCheckpoint { get; set; }
        [JsonProperty("um")] public int uiMode { get; set; }
        
        [JsonProperty("us")] public Dictionary<string, bool> globalFlag { get; set; }
        
        [JsonIgnore] public Sprite previewSprite { get; set; }
        [JsonIgnore] public string fileName { get; set; }
    }
}