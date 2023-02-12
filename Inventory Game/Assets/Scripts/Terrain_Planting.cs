using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Terrain_Planting : MonoBehaviour
{
    public GameObject panelMission;
    public RawImage itemNeededImage;
    public int itemNeededID;
    public int newItemNeededID;
    public Sprite newImageItem;

    void Update()
    {
        itemNeededID = newItemNeededID;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            //if State of terrain is zero = need Pickaxe and change to ground green 

            if (Game_Manager.instance.FindItemID(itemNeededID) == true)
            {
                //mando lo que necesita para el terreno
                panelMission.SetActive(true);
                if (itemNeededID == 0)
                {
                    itemNeededImage.texture = Game_Manager.instance.items[1].itemSprite.texture;
                    newItemNeededID = 1;
                }
                
                if (itemNeededID == 1)
                {
                    itemNeededImage.texture = Game_Manager.instance.items[0].itemSprite.texture;
                    newItemNeededID = 2;
                }

                if (itemNeededID == 2)
                {
                    itemNeededImage.texture = newImageItem.texture;
                    newItemNeededID = 3;
                }

                if (itemNeededID == 3)
                {
                    itemNeededImage.texture = Game_Manager.instance.items[2].itemSprite.texture;
                    newItemNeededID = 4;
                }

            }
            else {
               

             
            }
            // if state of terrain is one = need How and chage to groun mud

            // if state of terrain is two = need seed and activate plants 

            // if state of terrain is three = need collect plants 

            // if state for terrain is four = need shovel
        }
    }

}
