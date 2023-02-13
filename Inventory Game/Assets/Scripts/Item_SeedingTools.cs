using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_SeedingTools : MonoBehaviour
{
    public Item itemData;
    
       private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player") {
            //items number greater than inventory grid total/max numbers
            if (Game_Manager.instance.items.Count < Game_Manager.instance.slots.Length)
            {
                Destroy(gameObject);
                Game_Manager.instance.AddItem(itemData);
                if (itemData.itemID == 0)
                {
                    Game_Manager.instance.toolHand[0].SetActive(true);
                    Game_Manager.instance.toolHand[1].SetActive(false);
                    Game_Manager.instance.toolHand[2].SetActive(false);
                    Game_Manager.instance.vegetableItem.SetActive(false);
                }
                if (itemData.itemID == 1)
                {
                    Game_Manager.instance.toolHand[0].SetActive(false);
                    Game_Manager.instance.toolHand[1].SetActive(true);
                    Game_Manager.instance.toolHand[2].SetActive(false);
                    Game_Manager.instance.vegetableItem.SetActive(false);
                }
                if (itemData.itemID == 2)
                {
                    Game_Manager.instance.toolHand[0].SetActive(false);
                    Game_Manager.instance.toolHand[1].SetActive(false);
                    Game_Manager.instance.toolHand[2].SetActive(true);
                    Game_Manager.instance.vegetableItem.SetActive(false);
                }
                if (itemData.itemID == 3)
                {
                    Game_Manager.instance.toolHand[0].SetActive(false);
                    Game_Manager.instance.toolHand[1].SetActive(false);
                    Game_Manager.instance.toolHand[2].SetActive(false);
                    Game_Manager.instance.vegetableItem.SetActive(true);
                }
            }
            else
            {
                Debug.Log("You can not pick up any items now, your inventory is full");
            }
        }
    }
}
