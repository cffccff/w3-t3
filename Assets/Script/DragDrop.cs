using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject draggedItem;

    Vector3 startPosition;
    Transform startParent; // this is the original slot the item was inside of


    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedItem = gameObject;
       
            startPosition = transform.position;
            startParent = transform.parent;
            //todo we need to stop the interaction with other objects
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        
     
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}
