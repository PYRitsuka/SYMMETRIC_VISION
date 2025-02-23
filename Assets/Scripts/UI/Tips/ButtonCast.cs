using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Tips
{
    // public class ButtonCast : MonoBehaviour
    // {
    //     [SerializeField] private List<Button> buttons;
    //
    //     [SerializeField] private Image maskImage;
    //
    //     [SerializeField] private Image coverImage;
    //
    //     // Start is called before the first frame update
    //     void Start()
    //     {
    //         for(int i = buttons.Count - 1; i >= 0; i--)
    //         {
    //             Button b = buttons[i];
    //             int i1 = i;
    //             b.onClick.AddListener(delegate() { OnClick(b.GetComponent<RectTransform>().anchoredPosition.y, i1); });
    //         }
    //     }
    //
    //     private void OnClick(float posY, int p)
    //     {
    //         float delta = maskImage.rectTransform.anchoredPosition.y - posY + 67/*magic idk why*/;
    //         maskImage.rectTransform.DOAnchorPosY(maskImage.rectTransform.anchoredPosition.y - delta, .1f);
    //         coverImage.rectTransform.DOAnchorPosY(coverImage.rectTransform.anchoredPosition.y + delta, .1f);
    //
    //         TipsUIManager.Instance.RefreshTip(p);
    //     }
    // }
}
