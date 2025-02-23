
using DG.Tweening;
using UnityEngine;

namespace GamePlay.StoryV2.RecordsResolver
{
    public class ShakeManager : MonoBehaviour

    {
        private Tween shaking;
        public RectTransform rectTransform ;
        public enum ShakeState
        {
            None,
            Weak,
            Medium,
            Strong,
        }

        public ShakeState shakeState = ShakeState.None;
        public bool shakeLoop = false;
        public void SetShakeState(ShakeState state, bool loop = false)
        {
            
            Debug.Log($"Shakable:SetShakeState {state}");
            if (rectTransform != null)
            {
                shakeState = state;
                shakeLoop = loop;
                if (shaking != null)
                {
                    if (shaking.IsActive())
                    {
                        try
                        {
                            shaking.Kill(true);
                        }
                        catch
                        {
                            // hack, 
                        }

                    }

                    shaking = null;
                }
                switch (state)
                {
                    case ShakeState.None:
                        break;
                    case ShakeState.Weak:
                        shaking = rectTransform.DOShakeAnchorPos(.5f, 10f, 20, 90f, false, false);
                        break;
                    case ShakeState.Medium:
                        shaking = rectTransform.DOShakeAnchorPos(.5f, 15f, 20, 90f, false, false);
                        break;
                    case ShakeState.Strong:
                        shaking = rectTransform.DOShakeAnchorPos(.5f, 20f, 20, 90f, false, false);
                        break;
                    default:
                        break;
                }
                if (shaking != null)
                {
                    shaking.SetAutoKill(false);
                    shaking.OnComplete(
                        () =>
                        {
                            if (!shakeLoop)
                            {
                                SetShakeState(ShakeState.None, false); // will kill this
                            }
                            else
                            {
                                shaking.Restart();
                            }
                        }
                    );
                }

            }
        }
        public void SetShakeState(string state, bool loop = false)
        {
            switch (state)
            {
                case "none":
                    SetShakeState(ShakeState.None, loop);
                    break;
                case "weak":
                    SetShakeState(ShakeState.Weak, loop);
                    break;
                case "medium":
                    SetShakeState(ShakeState.Medium, loop);
                    break;
                case "strong":
                    SetShakeState(ShakeState.Strong, loop);
                    break;

                default:
                    break;
            }
        }

    }
}