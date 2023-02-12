using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Button : MonoBehaviour
{

    public int buttonID;
    private Item thisItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Helper function to get items on this button
    private Item GetThisItem() {
        for (int i = 0; i < Game_Manager.instance.items.Count; i++) {
            if (buttonID == i) {
                thisItem = Game_Manager.instance.items[i];
            }
        }
        return thisItem;
    }

    public void CloseButton() {
        Game_Manager.instance.RemoveItem(GetThisItem());
    }
}
