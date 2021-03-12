using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BEGIN DRAG");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
