using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EquipmentSlot : MonoBehaviour, IDropHandler
{

    public GameObject item
    {
        //the first child of the item slot is the image being dragged
        get
        {
            if (transform.childCount != 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item will be swap");
        Debug.Log(item.transform.parent.name.ToString());
        Debug.Log(item.transform.name.ToString());
       
        if (item.GetComponentInChildren<Text>().text.ToString().StartsWith(""))
        {
            item.GetComponentInChildren<Text>().color = new Color32(255, 255, 255, 255);
        }
       
        GameObject itemBeingDragged = DragDrop.draggedItem;
        
        //slot be swaped
        item.transform.SetParent(itemBeingDragged.transform.parent);
        itemBeingDragged.transform.SetParent(transform);
        if (itemBeingDragged.GetComponentInChildren<Text>().text.ToString().StartsWith(""))
        {
            itemBeingDragged.GetComponentInChildren<Text>().color = new Color32(0,0,0,0);
        }
       
        Debug.Log("Item swaped");
        Debug.Log(itemBeingDragged.transform.parent.name.ToString());
        Debug.Log(itemBeingDragged.transform.name.ToString());





    }
}
