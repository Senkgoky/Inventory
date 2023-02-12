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
            }
            else {
                Debug.Log("You can not pick up any items now, your inventory is full");
            }
        }
    }
}
