using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    //question why need file script to store gridLayout??????????
   // [SerializeField] GameObject slotPrefab;
   // private Slot slot;
    [SerializeField] GridLayoutGroup gridLayout;
    //private CanvasGroup canvasGroup;
    public List<Item> items;
    public List<int> items1 = new List<int>();
    [SerializeField] Button addButton,deleteButton;
   // [SerializeField]  Canvas canvas;
    string icon;
    static int slot_displayed=13;
  
    // Start is called before the first frame update
    void Start()
    {
      
        Button addbtn = addButton.GetComponent<Button>();
        addbtn.onClick.AddListener(TaskAddOnClick);
        Button deletebtn = deleteButton.GetComponent<Button>();
        deletebtn.onClick.AddListener(TaskDeleteOnClick);

        gridLayout = GameObject.Find("SlotHolder").GetComponent<GridLayoutGroup>();
        Debug.Log(gridLayout.name);
        items = ListOfItemInventory();
        LoadAllItemToInventory();
        //  SetUpListForAdding();
      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }
    }
   
   
    public void LoadAllItemToInventory()
    {
           
            for (int i = 0; i < slot_displayed; i++)
            {
            GameObject slotUI = gridLayout.transform.GetChild(i).gameObject;
            icon = items[i].sourceImage.ToString();  
                GameObject imageOfSlot = slotUI.transform.GetChild(0).gameObject;
                GameObject TextOfImage = imageOfSlot.transform.GetChild(0).gameObject;
                Text text = TextOfImage.GetComponent<Text>();
                Image image = imageOfSlot.GetComponent<Image>();
                image.sprite = Resources.Load<Sprite>("Sprites/ItemIcon/" + icon);
            image.color = new Color32(255, 255, 225, 225);
            text.enabled = true;        
               text.text = items[i].quantity.ToString();
            Debug.Log(items.Count);
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
  void TaskAddOnClick()
    {
        
        Debug.Log("You have clicked the button!");
      //  items.Add(items[slot_displayed]);
        LoadOneInventory();
      
    }
    void LoadOneInventory()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject slotUI = gridLayout.transform.GetChild(i).gameObject;
            icon = items[i].sourceImage.ToString();
            GameObject imageOfSlot = slotUI.transform.GetChild(0).gameObject;
            GameObject TextOfImage = imageOfSlot.transform.GetChild(0).gameObject;
            Text text = TextOfImage.GetComponent<Text>();
            Image image = imageOfSlot.GetComponent<Image>();
            if (image.sprite.ToString().StartsWith("BG1")|| image.sprite.ToString().StartsWith("UI"))
            {
                image.sprite = Resources.Load<Sprite>("Sprites/ItemIcon/" + icon);
                image.color = new Color32(255, 255, 225, 225);
                text.enabled = true;
                text.text = items[i].quantity.ToString();
                items.RemoveAt(i);
                return;


            }

        }
    }
    void TaskDeleteOnClick()
    {
        if (DeleteScript.lastItem != -1)
        {
            Debug.Log("You have deleted the item!: " + DeleteScript.lastItem);
            //items.RemoveAt(DeleteScript.lastItem - 1);
            DeleteSlot();
        }

      
        //items.RemoveAt(slot_displayed - 1);
        //slot_displayed--;
        //DeleteSlot(slot_displayed);
        
    }
    void DeleteSlot()
    {
        //GameObject slotUI = gridLayout.transform.GetChild(i).gameObject;
        //GameObject imageOfSlot = slotUI.transform.GetChild(0).gameObject;
        //imageOfSlot.GetComponent<Image>().sprite= Resources.Load<Sprite>("Sprites/BG1");
        //imageOfSlot.GetComponent<Image>().color= new Color32(255, 255, 225, 0);
        //imageOfSlot.GetComponentInChildren<Text>().text = "";
        GameObject gameObjectDelete = GameObject.Find("SlotForDelete");
        GameObject gameObjectImageDelete = gameObjectDelete.transform.GetChild(0).gameObject;
        Image imageDelete = gameObjectImageDelete.GetComponent<Image>();
        imageDelete.sprite= Resources.Load<Sprite>("Sprites/BG1");
        imageDelete.color = new Color32(0, 0, 0, 0);
        gameObjectImageDelete.GetComponentInChildren<Text>().text = "";

        DeleteScript.lastItem = -1;
    }
}
