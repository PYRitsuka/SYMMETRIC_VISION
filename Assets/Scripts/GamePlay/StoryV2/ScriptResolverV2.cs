using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Utils;
using System.Linq;
using GamePlay.StoryV2.Record.Factory;
using GamePlay.StoryV2.Record.Serializable;
using GamePlay.StoryV2.RecordsResolver;
using GamePlay.StoryV2.Event;
using GamePlay.Story.UI;
using GamePlay.Story.Backlog;
using Common;
using UI.VisionTrigger;
using UnityEngine.Events;
using Newtonsoft.Json;
using UnityEngine.AI;
using UnityEngine.UI;
using GamePlay.Story.Record;
using Unity.VisualScripting;
using Save;
using GamePlay.Story.RecordsResolver;
namespace GamePlay.StoryV2
{
    public class Controller
    {
        public int programCounter = 0;
        private List<Record.Base> instructions;
        private bool isCurrentCommandComplete = true;

        public Controller(List<Record.Base> newInstructions)
        {
            instructions = newInstructions;

        }

        public void Update()
        {
            //Debug.Log($"Check Command isCurrentCommandComplete {instructions[programCounter]} {instructions[programCounter].IsComplete()}");
            if (isCurrentCommandComplete && programCounter < instructions.Count)
            {
                ExecuteNext();
            }
        }

        private void ExecuteNext()
        {
            if (programCounter < instructions.Count)
            {
                isCurrentCommandComplete = false;
                instructions[programCounter].Start(ScriptResolverV2.Instance);
            }
        }

        public void CheckCommandCompletion()
        {
            if (!isCurrentCommandComplete && instructions[programCounter].IsComplete())
            {
                isCurrentCommandComplete = true;
                programCounter++;
                Debug.Log($"PC+1: {programCounter}");
            }
        }
    }

    public class ScriptResolverV2 : MonoBehaviourSingleton<ScriptResolverV2>
    {
        public Controller controller;

        public TextResolverV2 textResolver;
        public EventManager OnUserClick; // Define an event for user clicks

        [SerializeField] public TipGrid tipLoader;

        [SerializeField] public TipPresenter tipPresenter;

        [SerializeField] public TipTrigger tipTrigger;

        public string EditorScriptFile;

        public bool hasClick;

        public static UnityEvent OnLoad { get; set; } = new();


        public ImageLayerResolverV2 tachieResolver;

        public ImageLayerResolverV2 imageResolver;



        public ImageLayerResolverV2 uIResolver;

        public AudioResolverV2 audioResolver;

        public FilterResolverV2 filterResolver;

        public CameraResolverV2 cameraResolver;

        public SelectionResolverV2 selectionResolver;

        [SerializeField] public ViewFrame viewFrame;
        [SerializeField] public BMIInterface bmi;

        [SerializeField] public RotatedImageDisplay imageDisplay;

        [SerializeField] public Rine rineFrame;

        public UIModeController uIModeController;

        public static string ChapterNumber;
        public static string ChapterName;

        public static int ScriptLine;
        public static int TargetLine = -1;

        public static bool AutoOnLoad;

        public static string ScriptFileName;

        public static Dictionary<string, bool> loadedState;

        public bool isSkipping;

        public bool isAutoPlay;

        public bool isSelecting;
        public int BlockExecution = 0;

        public bool CanSkip;
        public bool CanAuto;

        public (int AnimationId, string NextScript) VisionTriggerTarget;
        public bool VisionTriggerOn;

        public RightMenuManager rightMenuManager;

        public Dictionary<string, bool> globalState;

        public AutoPlayPresenter autoPlayPresenter;
        public SkipPresenter skipPresenter;

        public UnityEvent onAutoStart = new();

        public RawImage loadMask;

        public bool debugLoadSave; // dont mask 
        [SerializeField] private AudioClip nextAudioClip;

        public static Dictionary<string,HashSet<ResourceRecord>> preloadDatabase;

        public static HashSet<ResourceRecord> resourceStack = new();

        public static int lastCheckpoint;

        public static int loadLastCheckpoint;

        public void Reset(){
            imageDisplay.DoClose(0);
            viewFrame.DoClose(0);
            imageResolver.Clear();
            uIResolver.Clear();
            tachieResolver.Clear();
            filterResolver.Clear();
            cameraResolver.Clear();
            uIModeController.SetUIMode(0);      
        }

        public void PushCheckpoint() {
            lastCheckpoint =controller.programCounter;
        }

        private void Start()
        {


            // List<Record.Base> sequence = new List<Record.Base>
            // {
            //     new Record.PrintCommand("Hello"),   // Print "Hello" to the console
            //     //new Record.WaitCommand(1.0f),        // Wait for 1 second
            //     new Record.PrintCommand("Hello"),   // Print "Hello" to the console
            //     //new Record.WaitCommand(2.0f),        // Wait for 2 more seconds
            //     new Record.PrintCommand("World!")   // Print "World!" to the console
            // };
            // var asset = StoryUtils.LoadResource<TextAsset>(ScriptFileName);
            // string script_json = asset.ToString();
            // var sequence = SerializableCommand.DeserializeCommands(script_json);
            // controller = new Controller(sequence);
            // CanSkip = true;
            imageDisplay.DoClose(0);
            viewFrame.DoClose(0);
            Debug.Log("ScriptResolver V2 Start");
            LoadScript(ScriptFileName);
            Debug.Log($"ScriptResolver V2 Target Line {TargetLine}");
            
            if (TargetLine != -1 && !debugLoadSave)
            {
                loadMask.gameObject.SetActive(true);
                loadMask.color = new Color(0, 0, 0, 1);
                
            }

            OnUserClick = new EventManager();
            // OnUserClick.Subscribe(
            //     CloseTipPresenterIfNeeded,10
            // );

            // OnUserClick.Subscribe(
            //     (x) =>
            //     {
            //         Debug.Log("TriggeredFade");
            //         tipLoader.FadeAllImages();
            //         x.KeepOnComplete = true;
            //     }, 8
            // );
            // OnUserClick.Subscribe(
            //     (x)=>{
            //         x.KeepOnComplete = true;
            //        if (tipLoader.hasClick) {
            //             tipLoader.hasClick = false;
            //             x.StopPropagation = true;
            //        }
            //     },0
            // );
            OnUserClick.Subscribe(
                (x) =>
                {
                    x.KeepOnComplete = true;
                    if (hasClick && !isSkipping && !IsFastForwarding())
                    {
                        hasClick = false;
                        x.StopPropagation = true;
                        return;
                    }
                    if (isAutoPlay)
                    {
                        StopAuto();
                    }
                    if (tipPresenter.IsOpened)
                    {
                        tipPresenter.Hide();
                        x.StopPropagation = true;
                        return;
                    }
                    if (BlockExecution > 0)
                    {
                        x.StopPropagation = true;
                        return;
                    }
                    if (isSelecting)
                    {
                        x.StopPropagation = true;
                    }
                }, 0
            );
            OnUserClick.Subscribe(textResolver.OnPointerClick, 0); // Check Link Click 
            OnUserClick.DebugLog("INIT: ");
            Debug.Log("ScriptResolver Instinated? {ScriptResolverV2.Instance==null}");
            OnLoad.Invoke();
            Debug.Log("ScriptResolver Loading Games, Reset Audio Resolver");
            var objs = GameObject.FindObjectsOfType<AudioResolverV2>();
            if (objs.Length > 0) {
                Debug.Log("ScriptResolver Loading Games, Reset Audio Resolver: Object Found");
                audioResolver = objs[0];
            } else {
                Debug.Log("ScriptResolver Loading Games, Reset Audio Resolver: Object NOT Found ");
            }
            if (TargetLine != -1) {
                audioResolver.SetVolMul(0);
            }
        }

        public bool CanSkipAnimation() {
            return CanSkip || IsFastForwarding();
        }




        private static int BatchPreloadResources(IEnumerable<ResourceRecord> lst) {
            int i = 0;
            foreach (var resourceRecord in lst) {
                i++;
                StoryUtils.preloadResources(resourceRecord.type, resourceRecord.path);
            }
            return i;
        }

        private static int BatchDropResources(IEnumerable<ResourceRecord> lst) {
            int i = 0;
            foreach (var resourceRecord in lst) {
                i++;
                StoryUtils.ReleaseResources(resourceRecord.type, resourceRecord.path);
            }
            return i;
        }

        public static void UpdateResourceCache(string newScript){
            if (preloadDatabase == null) {
                Debug.Log($"Preload: Database Not initialized!!!");
                return;
            }
            if (!preloadDatabase.ContainsKey(newScript)) {
                Debug.Log($"Preload: Script {newScript} not in calculated database!!!");
                return;
            }
            var newResourceStack = preloadDatabase[newScript];
            var toAdd = newResourceStack.Except(resourceStack); // only in new set
            var toDrop = resourceStack.Except(newResourceStack); //only in old set
            int oldSize = StoryUtils.GetResourceCount();
            int addC = BatchPreloadResources(toAdd);
            int dropC = BatchDropResources(toDrop);
            resourceStack = newResourceStack;
            int newSize = StoryUtils.GetResourceCount();
            Debug.Log($"Preload: Cache Update finished for Scene {newScript}: Old size {oldSize} New Size {newSize}, (+{addC}) (-{dropC})");
        }
        public static void buildPreloadDatabase() {
            var asset = StoryUtils.LoadResource<TextAsset>("脚本/V2_Preload/preload.json").ToString();
            var dict = JsonConvert.DeserializeObject<Dictionary<string,List<List<string>>>>(asset);
            preloadDatabase = new();
            Debug.Log("Preload: Building Database!!!");
            foreach (var kv in dict) {
                var script_file = kv.Key;
                var records = kv.Value.Select((x)=>new ResourceRecord(x[0],x[1])).ToList();
                preloadDatabase[script_file] = new (records);
                Debug.Log($"Preload: Register {records.Count} Resources of the scene {script_file} and its neighbors for preload!!!");
            }
        }
        void TryOpenBackLog()
        {
            if (!BacklogManager.Instance.gameObject.activeSelf && BacklogManager.Instance.ShouldOpen() )
            {
                BacklogManager.Instance.gameObject.SetActive(true);
                BacklogManager.Instance.Show();
            }
        }
        void Awake()
        {
            ScriptLine = 0;
            Debug.Log("ScriptResolver V2 Awake");
            Instance = this;
            if (!string.IsNullOrEmpty(EditorScriptFile) && string.IsNullOrEmpty(ScriptFileName))
            {
                ScriptFileName = EditorScriptFile;
                EditorScriptFile = "";
            }
            if (loadedState != null)
            {
                globalState = new(loadedState);
                loadedState = null;
            }
            else
            {
                globalState = new();
            }
            if (preloadDatabase == null) {
                buildPreloadDatabase();
            }
            UpdateResourceCache(ScriptFileName);
        }

        public void StopAuto()
        {
            if (!isAutoPlay) return;
            isAutoPlay = false;
            autoPlayPresenter.ToggleAutoPlay();
        }

        public void StartAuto()
        {
            if (!CanAuto) return;
            if (isSkipping) StopSkip();
            if (isAutoPlay) return;
            isAutoPlay = true;
            autoPlayPresenter.ToggleAutoPlay();
            onAutoStart.Invoke();
        }

        public void ToggleAuto()
        {
            hasClick = true;
            if (!isAutoPlay) { StartAuto(); } else { StopAuto(); };
        }

        public void ToggleSkip()
        {
            hasClick = true;
            if (!isSkipping) { StartSkip(); } else { StopSkip(); };
        }



        public void StopSkip()
        {
            if (!isSkipping) return;
            isSkipping = false;
            // TODO>
            skipPresenter.ToggleSkip();

        }

        public void StartSkip()
        {
            if (!CanSkip) return;
            if (isAutoPlay) StopAuto();
            if (isSkipping) StopSkip();
            isSkipping = true;
            skipPresenter.ToggleSkip();
        }

        // public bool CanJump() {
        //     return !isSelecting;
        // }

        public static void JumpToScript(string script)
        {
            ScriptFileName = script;
            _ = SceneTransit.Instance.TransitTo("StoryScene");
        }

        public void JumpToScriptRetainAuto(string script)
        {
            ScriptFileName = script;
            AutoOnLoad = isAutoPlay;
            _ = SceneTransit.Instance.TransitTo("StoryScene");
        }

        public void LoadScript(string key)
        {
            // GamePlay.Story.ScriptResolver.SetCurrentNode(key);
            var asset = StoryUtils.LoadResource<TextAsset>(key);
            string script_json = asset.ToString();
            var sequence = SerializableCommand.DeserializeCommands(script_json);
            controller = new Controller(sequence);
            if (loadLastCheckpoint> 0) {
                controller.programCounter = loadLastCheckpoint;
                loadLastCheckpoint = 0;
            } // Maybe Convert to Static Checking from precomputation in future

        }
        void DisableLoadMask()
        {
            var animation = loadMask.DOFade(0, 0.2f).OnComplete(
                () =>
                {
                    if (TargetLine != -1)
                    {
                        loadMask.gameObject.SetActive(false);
                    }

                }
            );
        }
        void Update()
        {

            SetState();
            // Debug.Log($"Target Line: {TargetLine} || {ScriptLine}");
            if (IsFastForwarding() && ScriptLine == TargetLine && !(BlockExecution > 0) )
            {
                Debug.Log($"Target Line Reached: {TargetLine} || {ScriptLine}, End Jump");
                TargetLine = -1;
                audioResolver.SetVolMul(1);
                DisableLoadMask();
            }
            TryOpenBackLog();
            controller.Update();
            controller.CheckCommandCompletion();
            handleInputEvents();
        }

        public void SetFlag(string key, bool value)
        {
            if (key.StartsWith("SYSTEM__")){
                SetSystemFlag(key,value);
            }
            if (key == "CanSkip")
            {
                CanSkip = value;
                if (value == false && isSkipping) {
                    StopSkip();
                }
                return;
            }
            if (key == "CanAuto")
            {
                CanAuto = value;
                if (value == false && isAutoPlay) {
                    StopAuto();
                }
                if (AutoOnLoad) {
                    StartAuto();
                    autoPlayPresenter.SetVisible(true); // Force enable, ignore text box visibility check 
                }
                AutoOnLoad = false;
                return;
            }
            Debug.Log($"Set Global Flag {key}:{value}");
            globalState[key] = value;
        }

        public void SetSystemFlag(string key, bool value)
        {
            Debug.Log($"Set System Flag {key}:{value}");
            GlobalSaveManager.CurrentSave.SystemFlag[key] = value;
            GlobalSaveManager.SaveFile();
        }

        public bool HasSystemFlag(string key)
        {
            return GlobalSaveManager.HasSystemFlag(key);
        }

        public static bool IsBlocked() {
            return Instance != null && Instance.BlockExecution > 0;
        }
        public bool HasFlag(string key)
        {
            if (key.StartsWith("SYSTEM__")){
                return HasSystemFlag(key);
            }
            if (key.StartsWith("PLATFORM__IsMobile")){
                return MobilePlatformScriptController.isMobile;
            }
            bool value;
            if (key == "CanSkip")
            {
                return CanSkip;
            }
            if (key == "CanAuto")
            {
                return CanAuto;
            }
            if (globalState.TryGetValue(key, out value))
            {
                Debug.Log($"Global Flag Check Hit {key}:{value}");
                return value;
            }
            Debug.Log($"Global Flag Check Miss {key},fallback is false by default");
            return false;
        }

        public void SetState()
        {
            ScriptLine = controller.programCounter;
        }

        public bool IsFastForwarding()
        {
            return TargetLine != -1;
        }

        private bool CheckUserInput()
        {
            if (isSkipping || IsFastForwarding()) return true;
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetAxis("Mouse ScrollWheel") < 0f) return true;
            if (Input.GetMouseButtonUp(0) ||
                Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) return true;

            return false;
        }

        public void TryTriggerVisionTrigger()
        {
            if (VisionTriggerOn) VisionChange(true);
            else
                AudioSource.PlayClipAtPoint(StoryUtils.LoadResource<AudioClip>("SE/错误.ogg"),
                    Camera.main.transform.position);
        }

        public void TryToggleAuto(){
            if (Input.GetKeyDown(KeyCode.LeftShift) ||Input.GetKeyDown(KeyCode.RightShift) ) {
                ToggleAuto();
            }
        }

        public void handleInputEvents()
        {
            if (StoryUtils.CheckVisionTriggerInput())
            {
                TryTriggerVisionTrigger();
            }
            TryToggleAuto();
            if (CheckUserInput()) // 0 is the button number for the left mouse click
            {
                TriggerClickEvent();
            }
            HandleSkipTrigger();
            TryToggleSetting();
            TryToggleStoryTree();
        }

        void HandleSkipTrigger()
        {
            if (!CanSkip)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                StartSkip();
                return;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
            {
                StopSkip();
                return;
            }
        }


        public void TryToggleSetting()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (ScriptResolverV2.Instance.BlockExecution != 0)
                    return;
                ScriptResolverV2.Instance.hasClick = true;
                SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
            }
        }
        public void TryToggleStoryTree()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (ScriptResolverV2.Instance.BlockExecution != 0)
                    return;
                ScriptResolverV2.Instance.hasClick = true;
                SceneManager.LoadScene("StorylineScene", LoadSceneMode.Additive);
            }
        }

        private void CloseTipPresenterIfNeeded(EventData x)
        {
            if (tipPresenter.IsOpened)
            {
                x.StopPropagation = true;
                // tipPresenter.Hide();
            }
            x.KeepOnComplete = true;
        }

        private void TriggerClickEvent()
        {
            Debug.Log("Click!");
            if (!isAutoPlay && !isSkipping && nextAudioClip != null)
            {
                AudioSource.PlayClipAtPoint(nextAudioClip, new Vector3(0, 0, -10), 1);
            }
            OnUserClick.Trigger(); // Invoke the event, will be null if no subscribers
        }
        public void BackToTitle()
        {
            audioResolver.StopManually();
            SceneManager.UnloadSceneAsync("StoryScene");
            _ = SceneTransit.Instance.TransitTo("TitleScene");
        }

        public void SetChapter(string id, string title)
        {
            ChapterNumber = id;
            ChapterName = title;
        }

        public Tween StartSelect(string key, List<string> selections)
        {
            if (isSkipping)
            {
                StopSkip();
            }
            else if (isSkipping || TargetLine != -1)
            {
                Debug.Log($"all states! {JsonConvert.SerializeObject(globalState)} ");
                for (int i = 0; i < selections.Count; i++)
                {
                    if (HasFlag($"{key}_{i + 1}"))
                    {
                        // do nothing
                        BacklogManager.Instance.AppendLog("", $"<style=selection>{selections[i]}</style>");
                        return null;
                    }
                }
                Debug.Log($"Error, Failed {key} {JsonConvert.SerializeObject(globalState)} ");

            }
            else if (isAutoPlay)
            {
                StopAuto();
            }
            isSelecting = true;
            CanAuto = false;
            CanSkip = false;
            var animation = DOVirtual.DelayedCall(100000, () => { });
            animation.Pause();
            animation.AllowMultipleCallback();
            selectionResolver.StartSelect(
                selections, (i) =>
                {
                    Debug.Log($"Selected {i + 1}!!");
                    isSelecting = false;
                    SetFlag($"{key}_chosen", true);
                    SetFlag($"{key}_{i + 1}", true);
                    animation.Play();
                    animation.Complete();
                    BacklogManager.Instance.AppendLog("", $"<style=selection>{selections[i]}</style>");
                    CanAuto = true;
                    CanSkip = true;

                }
            );

            return animation;
        }

        public void SetVisionTrigger(int AnimationId, string NextScript)
        {
            VisionTriggerOn = true;
            VisionTriggerTarget = (AnimationId, NextScript);
        }

        public void DisableVisionTrigger()
        {
            VisionTriggerOn = false;
        }

        public void VisionChange(bool stopBGM)
        {
            VisionChange(VisionTriggerTarget.AnimationId, VisionTriggerTarget.NextScript, stopBGM);
        }

        public void VisionChange(int AnimationId, string NextScript, bool stopBGM)
        {
            VisionTriggerUIController.AnimationId = AnimationId;
            VisionTriggerUIController.NextScript = NextScript;
            VisionTriggerUIController.AutoOnLoad = isAutoPlay;
            if (stopBGM)
            {
                audioResolver.StopManually();
            }
            StartCoroutine(TriggerVision());
        }

        IEnumerator TriggerVision()
        {
            yield return new WaitForEndOfFrame();
            var width = Screen.width;
            var height = Screen.height;
            var startX = 0;
            var startY = 0;
            if (1f * width / height > 1.7778f /* 9/16 */)
            {
                width = height / 9 * 16;
                startX = (Screen.width - width) / 2;
            }
            else
            {
                height = width / 16 * 9;
                startY = (Screen.height - height) / 2;
            }
            var screenImage = new Texture2D(width, height);
            screenImage.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
            screenImage.Apply();
            VisionTriggerUIController.Screenshot = screenImage;
            SceneManager.LoadScene("VisionTrigger");
        }
    }
}
