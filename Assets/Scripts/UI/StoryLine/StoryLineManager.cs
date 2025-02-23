using DG.Tweening;
using GamePlay.StoryV2;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using UnityEngine.UI;

namespace UI.StoryLine
{
    public class StoryLineManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        private void Start()
        {
            canvasGroup.DOFade(1, .3f);
            if (ScriptResolverV2.Instance != null) {
                        ScriptResolverV2.Instance.BlockExecution++;
            }
    
            
        }

        private void Update()
        {
            if (StoryUtils.CheckUserCancelInput() || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.M))
            {
                Exit();
            }
        }

        private void Exit()
        {
            if (ScriptResolverV2.Instance != null) {
            ScriptResolverV2.Instance.hasClick=true;
            ScriptResolverV2.Instance.BlockExecution--;
            }
            var clip = StoryUtils.LoadResource<AudioClip>("SE/退出界面.ogg");
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.5f);
            canvasGroup.DOFade(0, .3f).OnComplete(delegate
            {
                SceneManager.UnloadSceneAsync("StorylineScene");
            });
        }

    }
}