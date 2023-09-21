using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
    [Header("UI")]
    public Image image;
    public int itemNumber;

    [HideInInspector] public Transform parentAfterDrag; 
    //drag 'n drop

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
