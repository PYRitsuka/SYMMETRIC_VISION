using System;
using System.Linq;
using Common;
using DG.Tweening;
using GamePlay.Story;
using GamePlay.Story.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

namespace UI.Story.System
{
    public class SystemManager : MonoBehaviour
    {
        
        public static SystemManager Instance { get; private set; }
        
        [SerializeField] private CanvasGroup m_mainCanvas;
        [SerializeField] private CanvasGroup m_systemCanvas;
        [SerializeField] private CanvasGroup m_saveLoadCanvas;
        [SerializeField] private CanvasGroup m_rightClickMenuCanvas;

        [SerializeField] private Button m_exitArea;
        [SerializeField] private PostProcessVolume m_postProcess;
        [SerializeField] private PostProcessLayer m_postProcessLayer;
        
        public bool IsInSystem => _isInSystem;

        private bool _isInSystem;
        private RightMenuManager _rightMenuManager;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            _isInSystem = false;
            _rightMenuManager = m_rightClickMenuCanvas.GetComponent<RightMenuManager>();
            m_exitArea.onClick.AddListener(() => SwitchSystem(false));
            m_systemCanvas.GetComponent<Canvas>().worldCamera = FindObjectsOfType<Camera>().Where(x => x.name.Contains("Blur")).FirstOrDefault();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject()) //检测右键
            {
                if (!_isInSystem)
                {
                    SwitchSystem(true);
                }
            }
        }

        private void MainCanvas(bool disable)
        {
            m_mainCanvas.interactable = disable;
            m_mainCanvas.blocksRaycasts = disable;
        }

        private void SystemCanvas(bool show)
        {
            m_systemCanvas.DOFade(Convert.ToInt32(show), .3f);
            m_systemCanvas.interactable = show;
            m_systemCanvas.blocksRaycasts = show;
        }
    
        private void RightClickCanvas(bool show)
        {
            m_rightClickMenuCanvas.DOFade(Convert.ToInt32(show), .3f);
            m_rightClickMenuCanvas.interactable = show;
            m_rightClickMenuCanvas.blocksRaycasts = show;
        }
        
        private void SLCanvas(bool show)
        {
            m_saveLoadCanvas.DOFade(Convert.ToInt32(show), .3f);
            m_saveLoadCanvas.interactable = show;
            m_saveLoadCanvas.blocksRaycasts = show;
        }

        public void SwitchSystem(bool show)
        {
            SystemCanvas(show);
            MainCanvas(!show);
            if (show)
            {
                _rightMenuManager.OnEnterMenu.Invoke();
                m_postProcess.gameObject.SetActive(true);
                m_postProcessLayer.enabled = true;
            }
            else
            {
                _rightMenuManager.OnExitMenu.Invoke();
                m_postProcess.gameObject.SetActive(false);
                m_postProcessLayer.enabled = false;
            }
            DOTween.To(() => m_postProcess.weight, x => m_postProcess.weight = x, Convert.ToInt32(show) / 2f + .5f, .5f);
            _isInSystem = show;
        }
    }
}
