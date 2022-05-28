using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class NewBehaviourScript1 : MonoBehaviour
{
    public List<Item> items;
    void Start()
    {
     

        Image ItemSlot = GameObject.Find("ItemSlot").GetComponent<Image>();
        Image ItemSlot1 = GameObject.Find("ItemSlot1").GetComponent<Image>();

        GameObject ImageOfItemSlot = ItemSlot.transform.GetChild(0).gameObject;
        GameObject ImageOfItemSlot1 = ItemSlot1.transform.GetChild(0).gameObject;
        Image image = ImageOfItemSlot.GetComponent<Image>();
        Image image1 = ImageOfItemSlot1.GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Sprites/ItemIcon/axe");
        image1.sprite = Resources.Load<Sprite>("Sprites/ItemIcon/armor");
        GameObject TextOfImage = ImageOfItemSlot.transform.GetChild(0).gameObject;
        GameObject TextOfImage1 = ImageOfItemSlot1.transform.GetChild(0).gameObject;
        Text text = TextOfImage.GetComponent<Text>();
        Text text1 = TextOfImage1.GetComponent<Text>();
        text.enabled = true;
        text1.enabled = true;
        text.text = "3";
        text1.text = "5";
       

        Image ItemSlot2 = GameObject.Find("ItemSlot2").GetComponent<Image>();
        GameObject ImageOfItemSlot2 = ItemSlot2.transform.GetChild(0).gameObject;
        Image image2 = ImageOfItemSlot2.GetComponent<Image>();
        GameObject TextOfImage2 = ImageOfItemSlot2.transform.GetChild(0).gameObject;
        Text text2 = TextOfImage2.GetComponent<Text>();
        Debug.Log(text2.text.ToString().StartsWith(""));
        Debug.Log(text2.text.ToString()=="");

        Debug.Log(text2.text.ToString().Equals(""));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   
   
   
   
   
  
}
