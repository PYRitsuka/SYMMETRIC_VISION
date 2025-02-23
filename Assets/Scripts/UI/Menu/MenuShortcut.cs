using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuShortcut : MonoBehaviour
{
    public RectTransform Menu; // ??
    //public GameObject MainCanvas; // ???????
    public GameObject Canvas; // ??
    private bool Type; // ??????

    public GameObject GetOverUI(GameObject canvas) // ???????????UI
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;
        GraphicRaycaster gr = canvas.GetComponent<GraphicRaycaster>();
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);
        if (results.Count != 0)
        {
            return results[0].gameObject;
        }
        return null;
    }

    private void MenuType(bool type)
    {
        Menu.gameObject.SetActive(type); // ????
        Menu.position = Input.mousePosition;
        Type = type; // ??????
        Debug.Log("?????????" + (Type == true ? "??" : "??"));
    }

    private void Awake()
    {
        MenuType(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GetOverUI(Canvas))
        {
            MenuType(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            MenuType(true);
        }
    }
}
