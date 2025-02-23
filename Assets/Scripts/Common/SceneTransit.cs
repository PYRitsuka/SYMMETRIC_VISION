using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Common
{
    public class SceneTransit : MonoBehaviour
    {
        [SerializeField] private CanvasGroup transitionCanvas;
        public static SceneTransit Instance { get; private set; }
        
        private Stack<string> _sceneTraceStack = new();

        private UnityEvent _onTransit = new();
        
        // Start is called before the first frame update
        void Start()
        {
            if (Instance != null)
            {
                if (Instance != this)
                {
                    DestroyImmediate(this);
                }
                return;
            }
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            _sceneTraceStack.Push(SceneManager.GetActiveScene().name);
        }

        public async UniTask TransitTo(string sceneName)
        {
            _onTransit.Invoke();
            _sceneTraceStack.Push(sceneName);
            transitionCanvas.blocksRaycasts = true;
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;
            transitionCanvas.DOFade(1, 1f);
            await Task.Delay(1000);
            operation.allowSceneActivation = true;
            await operation;
            transitionCanvas.DOFade(0, 1f).OnComplete(() => transitionCanvas.blocksRaycasts = false);
        }
        
        public void Back()
        {
            _sceneTraceStack.Pop();
            TransitTo(_sceneTraceStack.Pop());
        }

        public static void RegisterSceneTransitEvent(Action action)
        {
            Instance._onTransit.AddListener(action.Invoke);
        }
        
        public static void UnregisterSceneTransitEvent(Action action)
        {
            Instance._onTransit.RemoveListener(action.Invoke);
        }
    }
}
