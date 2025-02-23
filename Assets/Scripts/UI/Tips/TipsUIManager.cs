using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using GamePlay.Tips;
using UI.Base;
using UI.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Tips
{
    // public class TipsUIManager : OpenCloseCanvasGroup, IOpenClose, IChangeColor
    // {
    //     [SerializeField] private Button back;
    //     [SerializeField] private List<Graphic> imagesNeedToChange;
    //     [SerializeField] private TextAsset tipsAsset;
    //     [SerializeField] private RectTransform content;
    //     [SerializeField] private RectTransform tipRectTransform;
    //     [SerializeField] private RectTransform tipPrefab;
    //
    //     [Space(20), Header("For test use only. Disable/Delete when builds."), SerializeField]
    //     private RectTransform testPanel;
    //     [SerializeField] private Button buttonForTest;
    //     [SerializeField] private InputField inputFieldForTest;
    //
    //     public static TipsUIManager Instance { get; private set; }
    //
    //     private TipsStructure _tips = new TipsStructure();
    //     private Coroutine _loadCoroutine;
    //     private int _nowDecade;
    //
    //     void Start()
    //     {
    //         #if UNITY_EDITOR
    //         testPanel.gameObject.SetActive(true);
    //         buttonForTest.onClick.AddListener(delegate
    //         {
    //             TipsManager.Instance.ResolveTip(Convert.ToInt32(inputFieldForTest.text));
    //         });
    //         #endif
    //         
    //         if (Instance != null)
    //         {
    //             Destroy(Instance.gameObject);
    //         }
    //         Instance = this;
    //         back.onClick.AddListener(Close);
    //         try
    //         {
    //             _tips = JsonUtility.FromJson<TipsStructure>(tipsAsset.text);
    //         }
    //         catch (Exception e)
    //         {
    //             Debug.LogError("Unable to deserialize tips.");
    //         }
    //         RefreshTip(0);
    //         _nowDecade = 0;
    //     }
    //     
    //     public void Open()
    //     {
    //         ChangeColor();
    //         OpenCanvasGroup();
    //         RefreshTip(_nowDecade);
    //     }
    //
    //     public void Close()
    //     {
    //         CloseCanvasGroup();
    //     }
    //
    //     public void ChangeColor()
    //     {
    //         var c = UIColorManager.Instance.GetMainColor();
    //         imagesNeedToChange.ForEach((x) => x.color = c);
    //     }
    //
    //     public void RefreshTip(int decade)
    //     {
    //         _nowDecade = decade;
    //         if (_loadCoroutine != null)
    //         {
    //             StopCoroutine(_loadCoroutine);
    //         }
    //
    //         _loadCoroutine = StartCoroutine(LoadTip(decade));
    //     }
    //
    //     private IEnumerator LoadTip(int decade)
    //     {
    //         tipRectTransform.DOAnchorPosX(1800f, .5f);
    //         yield return new WaitForSeconds(.5f);
    //         for (int i = 0; i < content.childCount; i++)
    //         {
    //             Destroy(content.GetChild(i).gameObject);
    //         }
    //         tipRectTransform.DOAnchorPosX(360.9658f, 0f);
    //         for (int i = decade * 10 + 1; i <= (decade + 1) * 10; i++)
    //         {
    //             var a = Instantiate(tipPrefab, content);
    //             if (i - 1 >= _tips.tips.Count)
    //             {
    //                 a.GetChild(0).GetChild(0).GetComponent<Text>().text = "暂未制作";
    //                 a.GetChild(0).GetChild(1).GetComponent<Text>().text = "Coming s∞n";
    //                 a.GetChild(1).GetComponent<Text>().text = "正在制作中(*/ω＼*)";
    //             }
    //             else if (!TipsManager.Instance.IsResolved(i - 1))
    //             {
    //                 
    //             }
    //             else
    //             {
    //                 a.GetChild(0).GetChild(0).GetComponent<Text>().text = _tips.tips[i - 1].title;
    //                 a.GetChild(0).GetChild(1).GetComponent<Text>().text = _tips.tips[i - 1].eng;
    //                 a.GetChild(1).GetComponent<Text>().text = _tips.tips[i - 1].desc;
    //             }
    //             var tempText = a.GetChild(0).GetComponent<Text>();
    //             tempText.color = UIColorManager.Instance.GetMainColor();
    //             tempText.text = $"{i:00}.";
    //             a.DOAnchorPosX(1077.765f, .2f); 
    //             a.DOScale(new Vector3(1, 1, 1), .2f);
    //
    //             yield return new WaitForSeconds(.05f);
    //         }
    //     }
    //
    //     [Serializable]
    //     internal class TipsStructure
    //     {
    //         public List<Tip> tips;
    //     }
    //
    //     [Serializable]
    //     internal class Tip
    //     {
    //         public string title;
    //         public string eng;
    //         public string desc;
    //     }
    // }
}
