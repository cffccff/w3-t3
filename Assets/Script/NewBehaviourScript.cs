using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    //question why need file script to store gridLayout??????????
    [SerializeField] GameObject myPrefab;
    [SerializeField] UIItem ui_item;
    [SerializeField] GridLayoutGroup gridLayout;
   
    [SerializeField] List<Item> items;
    string icon;
    // Start is called before the first frame update
    void Start()
    {
        gridLayout = GameObject.Find("InventoryGridLayout").GetComponent<GridLayoutGroup>();
        items = ListOfItemInventory();
        LoadAllItemToInventory();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void LoadAllItemToInventory()
    {
        for (int i = 0; i < items.Count; i++)
        {
            icon = items[i].sourceImage.ToString();
            ui_item = Instantiate(myPrefab.GetComponent<UIItem>());
            ui_item.itemQuantity.text = items[i].quantity.ToString();
            ui_item.imageItem.sprite = Resources.Load<Sprite>("Sprites/ItemIcon/" + icon);
            ui_item.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            ui_item.transform.SetParent(gridLayout.transform);
        }
    }
    public List<Item> ListOfItemInventory()
    {
        List<Item> items = new List<Item>();
        TextAsset inventoryAsset = Resources.Load<TextAsset>("SaveData/Inventory");
        if (inventoryAsset == null)
        {
            Debug.Log("No item in invertory file");
        }
        else
        {
            string[] data = inventoryAsset.text.Split(new char[] { '\n' });
         
            for (int i = 1; i < data.Length - 1; i++)
            {
                string[] row = data[i].Split(new char[] { ';' });
                if (row[1] != "")
                {
                    Item item = new Item();
                    item.name = row[0];
                    int.TryParse(row[1], out item.quantity);
                    row[2] = row[2].Replace("\r", "");
                    item.sourceImage = row[2];
                    items.Add(item);
                }
            }
            
        }
        return items;
    }
}
