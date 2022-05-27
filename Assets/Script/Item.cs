using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item()
    {

    }
    public Item(string name, int quantity, string sourceImage)
    {
        this.name = name;
        this.quantity = quantity;
        this.sourceImage = sourceImage;
    }
    public string name;
    public int quantity;
    public string sourceImage;
}
