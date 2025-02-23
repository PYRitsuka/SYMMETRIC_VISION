using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Constants;
using CsvHelper;
using CsvHelper.Configuration;
using DG.Tweening;
using GamePlay.Story.Record;
using GamePlay.Story.RecordsResolver;
using UI.Common.ShaderProviders;
using UI.VisionTrigger;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Text = GamePlay.Story.Record.Text;
using GamePlay.Story.Backlog;
using System.ComponentModel;

namespace GamePlay.Story.Record
{
    public record ResourceRecord(string type, string path);
}

