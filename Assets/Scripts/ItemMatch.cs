using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMatch: MonoBehaviour
{
    public UIItem collectedItem;
    public Item item;
    public GameObject interactionItem;
    public string itemCheck;
    public bool success;
    // Start is called before the first frame update
    void Start()
    {
        collectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        item = collectedItem.item;
        //print(item);
        success = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        //gets the information from inventory UI to figure out what item is currently selected 
        item = collectedItem.item;
        //checks if item is correct to assigned item
        if (item.title == null)
        {
            print("no item selected");
        }
        if (item.title == null)
         {
             print("whattt");
         }
         else if(item.title == itemCheck)
        {
            //if correct item is selecteed success bool will be true
            success = true;
            print(itemCheck + " match successful");
        } else
        {
            print("wrong item match");
        }
       /* if(collectedItem.item.title == itemCheck)
         {
             print("matches used on candle");
         }
         */
    }

}
