using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AddItemScript : MonoBehaviour
{
    public List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        items.Add(new Item("wand", 3, "wand"));
        items.Add(new Item("scroll", 4, "scroll"));
        items.Add(new Item("tome", 2, "tome"));
        items.Add(new Item("map", 5, "map"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
