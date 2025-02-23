// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Globalization;
// using System.IO;
// using System.Linq;
// using System.Reflection;
// using System.Threading;
// using System.Threading.Tasks;
// using Constants;
// using CsvHelper;
// using CsvHelper.Configuration;
// using DG.Tweening;
// using GamePlay.Story.Record;
// using GamePlay.Story.RecordsResolver;
// using UI.Common.ShaderProviders;
// using UI.VisionTrigger;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.Rendering.PostProcessing;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using Utils;
// using Text = GamePlay.Story.Record.Text;
// using GamePlay.Story.Backlog;
// using System.ComponentModel;
// using System.Globalization;
// using GamePlay.Story.UI;
// namespace System.Runtime.CompilerServices
// {
//     [EditorBrowsable(EditorBrowsableState.Never)]
//     internal class IsExternalInit { }
// }


// namespace GamePlay.Story
// {
//     public record CommandMeta(bool needClick, bool canContinue);
//     public record Command(string type, CommandMeta meta, object record);

//     public record ScriptContainer(string rawText, List<Command> program,  List<ResourceRecord> resources,List<string> jumps,string key);

//     public class ScriptResolver : MonoBehaviourSingleton<ScriptResolver>
//     {
//         private const float SkipTiming = .1f;

//         /// <summary>
//         ///     需等待的时间
//         /// </summary>
//         public static readonly WaitTime WaitTime = new(0);

//         /// <summary>
//         ///     用于结束所有等待时间的Task
//         /// </summary>
//         public static CancellationTokenSource CancellationTokenSource = new();

//         public static readonly StoryScriptParser ProgramParser = new();

//         [SerializeField] private BlurShaderProvider blurShaderProvider;
//         [SerializeField] private AudioClip nextAudioClip;
//         [SerializeField] private Image coverImage;
//         private bool _canContinue;

//         private static CsvReader _csv;
//         private string _currentField;
//         private bool _needClick = true;
//         private float _skipTimeCounter = SkipTiming;
        
//         private static string _script = StoryConstants.StartupScript;
//         private static int _targetScriptLine = 1;
//         private const string LOCAL_STR = "en-US";
//         [SerializeField] public TipGrid tipLoader;

//         /// <summary>
//         ///     当前是否在表演，每次遇到串行必须设为true
//         /// </summary>
//         public static bool IsPerforming { get; set; }

//         /// <summary>
//         ///     阻止执行
//         /// </summary>
//         public static NotifyProperty<int> BlockExecution { get; } = new();
        
//         /// <summary>
//         ///     在选项中吗？
//         /// </summary>
//         public static bool IsSelecting { get; set; }

//         /// <summary>
//         ///     可以跳过吗？
//         /// </summary>
//         public static NotifyProperty<bool> CanSkip { get; } = new(true);

//         /// <summary>
//         ///     是Auto中吗？
//         /// </summary>
//         public static bool IsAutoPlay { get; set; }

//         /// <summary>
//         ///     是Skip中吗？
//         /// </summary>
//         public static bool IsSkipping { get; set; }

//         /// <summary>
//         ///     鼠标在tips文本上吗？
//         /// </summary>
//         public static bool IsMouseOverTips { get; set; } = false;

//         /// <summary>
//         ///     等待文本的附加Auto时间
//         /// </summary>
//         public static float ExtraAutoWaitTime { get; set; } = -1f;

//         public static string ChapterNumber { get; set; } = "";
        
//         public static string ChapterName { get; set; } = "";

//         public static string ScriptFileName { get; set; } = "";

//         public static int ScriptLine { get; private set; } = 0;

//         public static float GlobalVolume { get; set; } = 1;

//         public static bool IsJumping { get; private set; } = true;

//         public static int SelectedNumber { get; set; }
        
//         public static Dictionary<int, int> UserSelections { get; set; } = new ();

//         public static UnityEvent OnLoad { get; set; } = new();

//         public static bool CanVisionTrigger { get; set; }

//         // New programing logic, need to gradually replace old one

//         public static List<Command> program = new();
//         public static HashSet<ResourceRecord> resourceStack = new();




//         private static Dictionary<string, Action<object>> recordExecutors = new Dictionary<string, Action<object>>
//         {
//             ["文本"] = o => Resolve(TextResolver.Instance, (Text)o),
//             ["镜头"] = o => Resolve(CameraResolver.Instance, (CameraFX)o),
//             ["UI"] = o => Resolve(UIResolver.Instance, (Record.UI)o),
//             ["滤镜"] = o => Resolve(FilterResolver.Instance, (Filter)o),
//             ["立绘"] = o => Resolve(TachieResolver.Instance, (Tachie)o),
//             ["图片"] = o => Resolve(PictureResolver.Instance, (Record.UI)o),
//             ["背景"] = o => Resolve(BackgroundResolver.Instance, (Background)o),
//             ["BGM"] = o => Resolve(BGMResolver.Instance, (BGM)o),
//             ["SE"] = o =>
//             {
//                 var se = (SE)o;
//                 if (!IsJumping) Resolve(SEResolver.Instance, se);
//             },
//             ["程序"] = o => ResolveProgram((Program)o),
//             ["特殊"] = o => Resolve(SpecialResolver.Instance, (Special)o),
//         };
//         private static Dictionary<string, Func< object,List<ResourceRecord>>> preLoader = new Dictionary<string, Func< object,List<ResourceRecord>>>
//         {
//             // ["文本"] = o => Resolve(TextResolver.Instance, (Text)o),
//             // ["镜头"] = o => Resolve(CameraResolver.Instance, (CameraFX)o),
//             ["UI"] = o => UIResolver.getResources((Record.UI) o),
//             //["滤镜"] = o => Resolve(FilterResolver.Instance, (Filter)o),
//             ["立绘"] = o => TachieResolver.getResources((Tachie)o),
//             ["图片"] = o => PictureResolver.getResources((Record.UI)o),
//             ["背景"] = o => BackgroundResolver.getResources((Background)o),
//             ["BGM"] = o => BGMResolver.getResources((BGM)o),
//             ["SE"] = o =>
//             {
//                 var se = (SE)o;
//                 return SEResolver.getResources(se);
//             },
//             // ["程序"] = o => ResolveProgram((Program)o),
//             // ["特殊"] = o => Resolve(SpecialResolver.Instance, (Special)o),
//         };

//         static Dictionary<string, Func<CsvReader, object>> recordResolvers = new Dictionary<string, Func<CsvReader, object>>
//         {
//             ["文本"] = (csv) => csv.GetRecord<Text>(),
//             ["镜头"] = (csv) => csv.GetRecord<CameraFX>(),
//             ["UI"] = (csv) => csv.GetRecord<Record.UI>(),
//             ["滤镜"] = (csv) => csv.GetRecord<Filter>(),
//             ["立绘"] = (csv) => csv.GetRecord<Tachie>(),
//             ["图片"] = (csv) => csv.GetRecord<Record.UI>(), // Assuming intentional duplication with "UI"
//             ["背景"] = (csv) => csv.GetRecord<Background>(),
//             ["BGM"] = (csv) => csv.GetRecord<BGM>(),
//             ["SE"] = (csv) => csv.GetRecord<SE>(),
//             ["程序"] = (csv) => csv.GetRecord<Program>(),
//             ["特殊"] = (csv) => csv.GetRecord<Special>(),
//         };

//         // Graph

//         private  static HashSet<string> visited = new(); // expanded node for constructor
//         private static int autoKey = 0;

//          [SerializeField] private bool debugMode = false;
//          [SerializeField] private string debugScript = "程序,,串行,JumpToScript(Startup.txt);,";
//         private static  SVGraph<string,ScriptContainer> storygraph;
//         private static SVGraphNode<ScriptContainer> currentNode;
//         private static bool isGraphInitialized = false;
//         public async static void InitGraph(){
//             if (isGraphInitialized) {
//                 return;
//             }
//             Debug.Log("INIT GRAPH!");
//             var result = BuildPlotGraph("程序,,串行,JumpToScript(Startup.txt);,");
//             await result;
//             storygraph = result.Result;
//             isGraphInitialized = true;
//             //SetCurrentNode("0");
//         }
        

//         public static void UpdateResourceCache(){
//             // if (!visited.Contains(key)) {
//             //     Debug.LogError($"Invalid Jump: {key}");
//             //     return;
//             // }
//             // var node = storygraph.GetNode(key);
//             // currentNode = key;
//             var newResourceStack = getNewResources(currentNode,PRELOAD_DEPTH);
//             var toAdd = newResourceStack.Except(resourceStack); // only in new set
//             var toDrop = resourceStack.Except(newResourceStack); //only in old set
//             int oldSize = StoryUtils.GetResourceCount();
//             int addC = BatchPreloadResources(toAdd);
//             int dropC = BatchDropResources(toDrop);
//             resourceStack = newResourceStack;
//             int newSize = StoryUtils.GetResourceCount();
//             Debug.Log($"Cache Update Begin: Old size {oldSize} New Size {newSize}, (+{addC}) (-{dropC})");
//         }
//         private const int PRELOAD_DEPTH = 1;
//         public static void SetCurrentNode(string key){
//             if (!visited.Contains(key)) {
//                 Debug.LogError($"Invalid Jump: {key}");
//                 return;
//             }
//             var node = storygraph.GetNode(key);
//             currentNode = node;
//             // BFS Search for required resources
//             Debug.Log($"Set current node to {key}");
//             UpdateResourceCache();

//         }


//         public static HashSet<ResourceRecord> getNewResources(SVGraphNode<ScriptContainer> node, int depth) {
//             HashSet<ResourceRecord> newResourceStack = new();
//             LinkedList<(SVGraphNode<ScriptContainer> node,int depth)> queue = new();
//             queue.AddFirst((node,depth));
//             HashSet<string> bfsVisited = new();
//             while (queue.First != null) {
//                 var thisEntry = queue.First;

//                 if (thisEntry.Value ==default) {
//                     break;
//                 }
//                 var thisNode = thisEntry.Value.node;
//                 var thisDepth = thisEntry.Value.depth;
//                 var container = thisNode.data;
//                 if (thisDepth < 0) {
//                     break;
//                 }
//                 queue.RemoveFirst();
//                 if (bfsVisited.Contains(container.key)){
//                     continue;
//                 }
//                 bfsVisited.Add(container.key);
//                 foreach (var res in container.resources) {
//                     if (res != null) {
//                         newResourceStack.Add(res);
//                     }               
//                 }
//                 Debug.Log($"BFS: Expanding {container.key} ");
//                 foreach (var next in node.children) {
//                     Debug.Log($"BFS: Queueing {next.data.key} ");
//                     if (next != null) {
//                         queue.AddLast((next,thisDepth-1));
//                     }
//                 }
//             };
//             return newResourceStack;
//         }
        



//         public async static Task<SVGraph<string,ScriptContainer>> BuildPlotGraph(string script,bool setNewRoot = false) {
//             SVGraph<string,ScriptContainer> graph = new SVGraph<string,ScriptContainer>();
//             var rootKey = $"{autoKey}";
//             autoKey++;
//             var root = PreloadAllData(_script,rootKey);
           
//             LinkedList<ScriptContainer> queue = new();
//             var rootNode = graph.AddNode(rootKey,root);
//             if (setNewRoot) {
//                 graph.root = rootNode;
//             }
//             queue.AddFirst(root);
//             while (queue.First != null) {
//                 var node = queue.First;
//                 if (node.Value == null) {
//                     break;
//                 }
//                 queue.RemoveFirst();
//                 if (visited.Contains(node.Value.key)){
//                     continue;
//                 }
//                 visited.Add(node.Value.key);
//                 Debug.Log($"DFS: Expanding {node.Value.key} ");
//                 foreach (var next in node.Value.jumps) {
//                     Debug.Log($"DFS: Loading {next} ");
//                     var handle =  StoryUtils.preloadResources<TextAsset>(next);
//                     if (!handle.HasValue) {
//                         continue;
//                     }
//                     await handle.Value.Task;
//                     var asset = handle.Value.Result;
//                     if (asset.Equals(null))
//                     {
//                     Debug.Log("Error DFS ");
//                     }
//                     var textData = asset.text;
//                     var child = PreloadAllData(textData,next);
//                     if (child != null) {
//                         queue.AddFirst(child);
//                         graph.AddNode(next,child);
//                         graph.AddEdge(node.Value.key,next);
//                     }
//                 }
//             }
//             return graph;
//         }
//         private void Start()
//         {
//             if (debugMode) {
//                 _script = "Startup.txt";
//             }
//             ScriptResolver.InitGraph(); // TODO: maybe move to async some time
//             IsJumping = true;
//             CanVisionTrigger = false;
//             GlobalVolume = PlayerPrefs.GetFloat("globalVolume", 1);
//             StoryUtils.UnloadUnusedAssets();
//             ReloadScript(_script, _targetScriptLine);            
//             ReloadCsv();
//             StartCoroutine(LoadScript(_targetScriptLine));
//         }

        

//         public static void ReloadCsv(){
//             _csv = new CsvReader(new StringReader(_script), new CsvConfiguration(CultureInfo.GetCultureInfo(LOCAL_STR)) { HasHeaderRecord = false });
//         }

//         /*TODO: Too complex code in Update function
//          Try to get cyclomatic complexity less than 10*/
//         private void Update()
//         {
//             if (BlockExecution.Value > 0) //如果被阻止执行就不执行（废话嘛这不是）
//                 return;
//             if (IsSelecting)
//                 return;
//             if (IsJumping)
//                 return;

//             if (IsPerforming)
//             {
//                 if (IsSkipping) InterruptPerforming();
//                 if (CanSkip.Value && CheckUserInput()) //演出时打断
//                     InterruptPerforming();

//                 return;
//             }

//             if (!_needClick)
//             {
//                 ResetPerforming();
//                 ResolveNext();
//                 return;
//             }

//             if (IsSkipping)
//             {
//                 _skipTimeCounter -= Time.deltaTime;
//                 if (_skipTimeCounter <= 0)
//                 {
//                     ResetPerforming();
//                     ResolveNext();
//                     _skipTimeCounter = SkipTiming;
//                 }

//                 return;
//             }

//             if (Input.GetKeyDown(KeyCode.T))
//             {
//                 SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
//                 return;
//             }

//             if (Input.GetKeyDown(KeyCode.M))
//             {
//                 SceneManager.LoadScene("StorylineScene", LoadSceneMode.Additive);
//                 return;
//             }

//             if (CheckUserInput())
//             {
//                 if (IsAutoPlay) ExtraAutoWaitTime = 0;

//                 ResetPerforming();
//                 ResolveNext();
//                 AudioSource.PlayClipAtPoint(nextAudioClip, new Vector3(0, 0, -10), 1);
//                 return;
//             }

//             if (StoryUtils.CheckVisionTriggerInput())
//             {
//                 TryTriggerVisionTrigger();
//             }
            
//             //下面是AutoPlay区域

//             if (!IsAutoPlay) return;

//             if (ExtraAutoWaitTime > 0)
//             {
//                 ExtraAutoWaitTime -= Time.deltaTime;
//             }
//             else
//             {
//                 ResetPerforming();
//                 ResolveNext();
//                 AudioSource.PlayClipAtPoint(nextAudioClip, new Vector3(0, 0, -10), 1);
//             }
//         }

//         public void TryTriggerVisionTrigger()
//         {
//             if (IsPerforming) return;
//             if (!CanSkip.Value) return;
//             if (BlockExecution.Value != 0) return;
//             if (BacklogManager.IsReadingLogs) return;
//             if (CanVisionTrigger) TriggerVision_external(true);
//             else
//                 AudioSource.PlayClipAtPoint(StoryUtils.LoadResource<AudioClip>("SE/错误.ogg"),
//                     Camera.main.transform.position);
//         }

//         /// <summary>
//         ///     获得当前主摄像机的<see cref="BlurShaderProvider" />
//         /// </summary>
//         /// <returns></returns>
//         public BlurShaderProvider GetBlurProvider()
//         {
//             return blurShaderProvider;
//         }

//         /// <summary>
//         ///     重新加载一个脚本
//         /// </summary>
//         /// <param name="scriptAsset">脚本</param>
//         /// <param name="userSelections">选项</param>
//         /// <param name="line">行数</param>
//         public static void ReloadScript(TextAsset scriptAsset, Dictionary<int, int> userSelections, int line = 1)
//         {
//             //StoryUtils.UnloadUnusedAssets();
//             // if (!_script.Contains("Startup.txt")) //hack
//             // {
//             //     PreloadAllData(_script);
//             // }
//             Debug.Log("Reload script !");

//             //BatchPreloadResources(resourceRecords);
            
//             UserSelections = userSelections ?? UserSelections;
//             SelectedNumber = 0;
//             ReloadScript(scriptAsset.text, line);
//         }

//         /// <summary>
//         ///     重新加载一个脚本
//         /// </summary>
//         /// <param name="scriptAsset">脚本</param>
//         /// <param name="line">行数</param>
//         public static void ReloadScript(string scriptAsset, int line)
//         {
//             // StoryUtils.UnloadUnusedAssets();
//             //DOTween.CompleteAll(true); //打断所有tween
//             // PreloadAllData(scriptAsset);
//             // BatchPreloadResources(resourceRecords);
//             CancellationTokenSource.Cancel(); //打断等待的tasks
//             ResetPerforming();
//             BlockExecution.Value = 0;
//             ScriptLine = 0;
//             CanSkip.Value = true;
//             _script = scriptAsset;
//             _targetScriptLine = line;
//         }

//         public void JumpToLine(int line, bool absolute)
//         {
//             if (!absolute) line += ScriptLine;
//             line--;
//             while (ScriptLine < line)
//             {
//                 NextRecord();
//             }
//             //ResetPerforming();
//             //ResolveNext();
//             //NextRecord();
//         }

//         IEnumerator LoadScript(int line)
//         {
//             while (!isGraphInitialized) {
//                 yield return new WaitForNextFrameUnit();
//             }
//             yield return new WaitForNextFrameUnit();
//             NextRecord();
//             while (ScriptLine < line)
//             {
//                 ResolveOneRecord();
//                 NextRecord();
//                 DOTween.CompleteAll(true); //打断所有tween
//                 CancellationTokenSource.Cancel(); //打断等待的tasks
//                 if (ScriptLine >= line - 1)
//                 {
//                     IsJumping = false;
//                 }
//             }
//             IsJumping = false;
//             coverImage.DOFade(0, 1f);
//             OnLoad.Invoke();
//         }

//         public void TriggerVision_external(bool stopBGM = true)
//         {
//             if (stopBGM) {
//                 BGMResolver.Instance.StopManually();
//             }
//             StartCoroutine(TriggerVision());
//         }

//         IEnumerator TriggerVision()
//         {
//             yield return new WaitForEndOfFrame();
//             var width = Screen.width;
//             var height = Screen.height;
//             var startX = 0;
//             var startY = 0;
//             if (1f * width / height > 1.7778f /* 9/16 */)
//             {
//                 width = height / 9 * 16;
//                 startX = (Screen.width - width) / 2;
//             }
//             else
//             {
//                 height = width / 16 * 9;
//                 startY = (Screen.height - height) / 2;
//             }
//             var screenImage = new Texture2D(width, height);
//             screenImage.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
//             screenImage.Apply();
//             VisionTriggerUIController.Screenshot = screenImage;
//             SceneManager.LoadScene("VisionTrigger");
//         }

//         /// <summary>
//         ///     读入下一行的信息，<see cref="ResolveOneRecord" />前必须调用
//         /// </summary>
//         private void NextRecord()
//         {
//             try
//             {
//                 _csv.Read();
//             }
//             catch
//             {
//                 Debug.Log("EOF reached.");
//                 return;
//             }

//             ScriptLine++;
//             var canRead = _csv.TryGetField<string>(0, out var field);
//             if (!canRead) return;

//             _canContinue = _csv.GetField<string>(2) == "并行";
//             _needClick = _csv.GetField<string>(1) == "点击触发";
//             _currentField = field;
//         }
//         /// <summary>
//         ///  Very bad idea, quick hack for now, need to full refractor code execution logic in future!!!!
//         /// </summary>
//         /// 
//         private static int BatchPreloadResources(IEnumerable<ResourceRecord> lst) {
//             int i = 0;
//             foreach (var resourceRecord in lst) {
//                 i++;
//                 StoryUtils.preloadResources(resourceRecord.type, resourceRecord.path);
//             }
//             return i;
//         }
//         private static int BatchDropResources(IEnumerable<ResourceRecord> lst) {
//             int i = 0;
//             foreach (var resourceRecord in lst) {
//                 i++;
//                 StoryUtils.ReleaseResources(resourceRecord.type, resourceRecord.path);
//             }
//             return i;
//         }
    
//         private static ScriptContainer  PreloadAllData(string _script,string key = null) {
//             if (_script == null) {
//                 return null;
//             }
//             Debug.Log("Preloading: Start");
//             var csv = new CsvReader(new StringReader(_script), new CsvConfiguration(CultureInfo.GetCultureInfo(LOCAL_STR)) { HasHeaderRecord = false });
//             int i = 0;
//             List<Command> program =  new();
//             List<ResourceRecord> resources =  new();
//             List<String> jumps =  new();
//             try {
//                 while (csv.Read()) {

                
//                     var canRead = csv.TryGetField<string>(0, out var field);
//                     if (!canRead) return null;

//                     var canContinue = csv.GetField<string>(2) == "并行";
//                     var needClick = csv.GetField<string>(1) == "点击触发";
//                     var currentField = field;
//                     if (field == "") {
//                         continue;
//                     }
//                     object record = ResolveOneCommand(field,csv);
//                     if ((object )record == null) {
//                         continue;
//                     }
//                     Func<object, System.Collections.Generic.List<GamePlay.Story.Record.ResourceRecord>> preload_handler;
//                     if (preLoader.TryGetValue(field, out preload_handler)) {
//                         var rowResources = preload_handler(record);
//                         foreach (var resource_row in rowResources) {
//                             resources.Add(resource_row);
//                             Debug.Log($"Queued {i}: {resource_row.type} {resource_row.path}");
//                         }
//                     }
//                     var progamData = record as Program;
//                     if (progamData != null ) {
//                         var jumpDest = StoryScriptParser.LoadPotentialJumpDestination(progamData.Command, progamData.Condition);
//                         if (jumpDest != null) {
//                             jumps.Add(jumpDest);
//                         }
//                     }
//                     CommandMeta meta = new CommandMeta(needClick, canContinue);
//                     Command row = new Command(currentField, meta,record);
//                     program.Add(row);
//                     i++;
//                     Debug.Log($"Preloading {i}: {currentField} ");
//                     //Debug.Log($"Preloading {i}: {currentField} ");
//                 } 
//                 var container = new ScriptContainer(_script,program,resources,jumps,key);
//                 return container;
//             } catch (Exception ex) {
//                      Debug.Log("EOF ");
//             } 
//             Debug.Log($"Preloading Done {i} ");
//             return null;
//         }

//         private static object ResolveOneCommand(string field, CsvReader csv)
//         {
//             object record = null; // Declare a single variable to hold the record.
//             Func<CsvReader, object> resolver = null;
//             if (recordResolvers.TryGetValue(field, out resolver))
//             {
//                 record = resolver(csv);
//             } else
//             {
//                 Debug.LogError("Unknown command type: " + field);
//                 return null; // Return null to indicate failure or an unknown command.
//             }
//             return record; // Return the obtained record.
//         }


//         /// <summary>
//         ///     解析一行
//         /// </summary>
//         private void ResolveOneRecord()
//         {
//             var field = _currentField;
//             switch (field)
//             {
//                 case "文本": //Fully Implemented
//                     var a = _csv.GetRecord<Text>();
//                     Resolve(TextResolver.Instance, a);
//                     break;
//                 case "镜头": //Fully Implemented
//                     var b = _csv.GetRecord<CameraFX>();
//                     Resolve(CameraResolver.Instance, b);
//                     break;
//                 case "UI": //Fully Implemented
//                     var c = _csv.GetRecord<Record.UI>();
//                     Resolve(UIResolver.Instance, c);
//                     break;
//                 case "滤镜": //Fully Implemented
//                     var d = _csv.GetRecord<Filter>();
//                     Resolve(FilterResolver.Instance, d);
//                     break;
//                 case "立绘": //Fully Implemented
//                     var e = _csv.GetRecord<Tachie>();
//                     Resolve(TachieResolver.Instance, e);
//                     break;
//                 case "图片": //Fully Implemented
//                     var f = _csv.GetRecord<Record.UI>();
//                     Resolve(PictureResolver.Instance, f);
//                     break;
//                 case "背景": //Fully Implemented
//                     var g = _csv.GetRecord<Background>();
//                     Resolve(BackgroundResolver.Instance, g);
//                     break;
//                 case "BGM": //Fully Implemented
//                     var h = _csv.GetRecord<BGM>();
//                     Resolve(BGMResolver.Instance, h);
//                     break;
//                 case "SE": //Fully Implemented
//                     var i = _csv.GetRecord<SE>();
//                     if (IsJumping) break;
//                     Resolve(SEResolver.Instance, i);
//                     break;
//                 case "程序": //Fully Implemented
//                     var j = _csv.GetRecord<Program>();
//                     ResolveProgram(j);
//                     break;
//                 case "特殊":
//                     var k = _csv.GetRecord<Special>();
//                     Resolve(SpecialResolver.Instance, k);
//                     break;
//                 default:
//                     IsPerforming = false;
//                     Debug.LogError("Unknown command type: " + field);
//                     return;
//             }
//         }

//         /// <summary>
//         ///     解析一串
//         /// </summary>
//         private void ResolveNext()
//         {
//             while (true)
//             {
//                 tipLoader.FadeAllImages();
//                 //解析一行
//                 ResolveOneRecord();

//                 if (BlockExecution.Value > 0)
//                 {
//                     break;
//                 }

//                 //如果重置了，直接退出
//                 if (IsJumping)
//                 {
//                     break;
//                 }

//                 //如果这是串行的话，就直接退出循环
//                 if (!_canContinue)
//                 {
//                     NextRecord();
//                     IsPerforming = true;
//                     WaitForPerforming();
//                     break;
//                 }

//                 //提前读取下一步信息
//                 NextRecord();

//                 //如果可以继续（并行）
//                 if (_canContinue && !_needClick) continue;

//                 //等待下一步演出
//                 IsPerforming = true;
//                 WaitForPerforming();
//                 break;
//             }
//         }

//         /// <summary>
//         ///     异步等待表演结束
//         /// </summary>
//         private static async void WaitForPerforming()
//         {
//             //Task.WhenAny 可以防止TaskCanceledException
//             await Task.WhenAny(Task.Delay((int)(1000 * WaitTime.Value), CancellationTokenSource.Token));
//             IsPerforming = false;
//         }

//         /// <summary>
//         ///     重置表演，每次表演前必须调用
//         /// </summary>
//         private static void ResetPerforming()
//         {
//             CancellationTokenSource = new CancellationTokenSource();
//             WaitTime.Reset();
//         }

//         /// <summary>
//         ///     打断表演
//         /// </summary>
//         /// 
//         public static async void CompleteTweennByFlagAsync(bool inclusive, string tag,float duration){
//             await Task.Delay((int)(duration * 1000 ));
//             CompleteTweennByFlag(inclusive,tag);
//         }

//         public void ShowTips(string linkID) {
//             tipLoader.AddImage(linkID);
//         }
//         public static void CompleteTweennByFlag(bool inclusive, string tag){
//             // Step 1: Pause tweens with the specific tag you want to exclude
//             var tweensToExclude = DOTween.TweensById(tag);
//             if (tweensToExclude == null) {
//                 if (!inclusive) {
//                     DOTween.CompleteAll(true);
//                 }
//                 return;
//             }
//             Debug.Log($"DEBUG INT: {tweensToExclude.Count}");
//             if (!inclusive) {
//                 foreach (var tween in tweensToExclude)
//                 {
//                     if (tween != null && tween.IsActive())
//                     {
//                         tween.Pause();
//                     }
//                 }

//                 // Step 2: Complete all tweens. Since the tweens you want to exclude are paused, they won't be completed.
//                 // DOTween.CompleteAll();
//                 var playingTweens = DOTween.PlayingTweens();
//                 if (playingTweens != null) {
//                         foreach (var tween in playingTweens )
//                         {
//                             if (tween != null && tween.IsActive())
//                             {
//                                 tween.Pause();
//                             }
//                         }     
//                 }



//                 // Step 3: Resume the paused tweens
//                 foreach (var tween in tweensToExclude)
//                 {
//                     if (tween != null && !tween.IsPlaying())
//                     {
//                         tween.Play();
//                     }
//                 }
//             } else {
//                 foreach (var tween in tweensToExclude) {
//                      if (tween != null && tween.IsActive()) {
//                         tween.Kill(complete: false);
//                      }
//                 }
//             }

//             // List<Tween> allTweens = DOTween.Tweens();

//             // // Loop through all active tweens
//             // foreach (var tween in allTweens)
//             // {   
//             //     bool match =  tween.tag == tag;
//             //     if (!inclusive) {
//             //         match = ! match; // exclude tags
//             //     }
//             //     // Check if the tween does not have the tag you want to exclude
//             //     if (tween != null && tween.IsActive() && match)
//             //     {
//             //         // Complete the tween
//             //         tween.Complete();
//             //     }
//             // }
//         }
//         public void InterruptPerforming()
//         {
//             //直到需要点击，一直跳过
//             // DOTween.CompleteAll(true); //打断所有tween
//             CompleteTweennByFlag(false,"Persistent");
//             CancellationTokenSource.Cancel(); //打断等待的tasks
//             while (!_needClick && !CanSkip.Value)
//             {
//                 ResolveOneRecord();
//                 NextRecord();
//                 DOTween.CompleteAll(true); //打断所有tween
//                 CancellationTokenSource.Cancel(); //打断等待的tasks
//             }
//         }

//         /// <summary>
//         ///     检测用户输入
//         /// </summary>
//         /// <returns><see langword="true" />: 用户操作下一步</returns>
//         private static bool CheckUserInput()
//         {
             
//             if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) return true;
//             if (Input.GetMouseButtonUp(0) || 
//                 Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) return !IsMouseOverTips;

//             return false;
//         }

//         #region 废话

//         private static void Resolve(IResolvable resolver, object data)
//         {
//             resolver.Resolve(data);
//         }
        
//         private static void ResolveProgram(Program data)
//         {
//             ProgramParser.ParseScript(data.Command, data.Condition);
//         }
        
//         #endregion
//     }
// }