using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{ 
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag"); 
    }
}