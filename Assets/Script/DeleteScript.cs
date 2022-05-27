using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DeleteScript : MonoBehaviour, IDropHandler
{
    public static int lastItem = -1;
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


        GameObject itemBeingDragged = DragDrop.draggedItem;
        string s = itemBeingDragged.transform.parent.name.ToString();
        Debug.Log(s);
        s = new string(s.Where(c => char.IsDigit(c)).ToArray());

        Debug.Log("go next");
        Debug.Log(s);
        lastItem = int.Parse(s);
        //slot be swaped
        item.transform.SetParent(itemBeingDragged.transform.parent);


        itemBeingDragged.transform.SetParent(transform);



    }
}
