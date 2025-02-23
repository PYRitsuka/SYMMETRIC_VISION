using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MouseClickDetector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            DetectObjectUnderMouse();
        }
    }

    void DetectObjectUnderMouse()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            pointerId = -1,
        };

        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (!IsBlocked(result))
            {
                Debug.Log("Hit: " + result.gameObject.name,result.gameObject);
                break; // Stop after the first non-blocked result
            }
        }
    }

    bool IsBlocked(RaycastResult result)
    {
        var raycastTarget = result.gameObject.GetComponent<CanvasRenderer>();
        return raycastTarget != null && raycastTarget.cull;
    }
}