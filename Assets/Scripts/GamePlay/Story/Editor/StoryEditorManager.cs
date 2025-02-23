using System.IO;
using Baracuda.Threading;
using Common;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Story.Edit
{
    public class StoryEditorManager : MonoBehaviour
    {
        [SerializeField] private Button openCloseButton;
        [SerializeField] private GameObject panel;
        [SerializeField] private InputField scriptPath;
        [SerializeField] private Button reloadScriptButton;
        [SerializeField] private TMP_Text scriptPreview;
        [SerializeField] private Toggle richTextToggle;
        [SerializeField] private TMP_Text debugLogText;

        private bool _isOpened = false;
        private string _loggedMessage = "";
        private string _path = "";
        private FileSystemWatcher _fileSystemWatcher;

        // Start is called before the first frame update
        void Start()
        {
            openCloseButton.onClick.AddListener(ToggleOpenState);
            richTextToggle.onValueChanged.AddListener(delegate { scriptPreview.richText = richTextToggle.isOn; });
            reloadScriptButton.onClick.AddListener(ReloadScript);
        }

        private void ReloadScript()
        {
            var path = scriptPath.text;
            if (!File.Exists(path))
            {
                _loggedMessage = "<color=#FF5647>ERROR : File does not exist.</color>";
                UpdateMessage();
                return;
            }
            //ScriptResolver.Instance.ResetStoryCanvas();
            var script = File.ReadAllText(path);
            _path = path;
            _fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(path));
            Debug.Log(Path.GetFileName(path));
            _fileSystemWatcher.Filter = Path.GetFileName(path);
            _fileSystemWatcher.NotifyFilter = NotifyFilters.LastAccess
                                              | NotifyFilters.LastWrite
                                              | NotifyFilters.FileName
                                              | NotifyFilters.DirectoryName
                                              | NotifyFilters.Size;
            _fileSystemWatcher.Changed += ReloadChangedScript;
            _fileSystemWatcher.Renamed += ReloadChangedScript;
            _fileSystemWatcher.EnableRaisingEvents = true;
            _loggedMessage = $"Script {path} loaded.";
            UpdateMessage();
            ScriptResolver.ReloadScript(script, 1);
            scriptPreview.text = script;
            SceneTransit.Instance.TransitTo("StoryScene");
        }

        private void ReloadChangedScript(object sender, FileSystemEventArgs e)
        {
            //Dispatcher.Invoke(() => ScriptResolver.Instance.ResetStoryCanvas());
            var script = File.ReadAllText(_path);
            _loggedMessage = $"<color=#669653>Script {_path} changed, reloaded.</color>";
            Dispatcher.Invoke(delegate
            {
                UpdateMessage();
                ScriptResolver.ReloadScript(script, 1);
                scriptPreview.text = script;
                SceneTransit.Instance.TransitTo("StoryScene");
            });
        }

        private void ToggleOpenState()
        {
            _isOpened = !_isOpened;
            ScriptResolver.BlockExecution.Value += _isOpened ? 1 : -1;
            panel.SetActive(_isOpened);
        }

        void UpdateMessage()
        {
            debugLogText.text = _loggedMessage;
            debugLogText.color = Color.white;
            debugLogText.DOFade(1, 2f).OnComplete(delegate
            {
                debugLogText.DOFade(0, 1f);
            });
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
