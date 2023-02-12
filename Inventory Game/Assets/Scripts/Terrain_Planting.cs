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
    public Material groundMaterialStateFirts;
    public Material groundMaterialStateSecond;
    public Material groundMaterialStateThird;
    public Material groundMaterialStateFourth;
    public Material groundMaterialStateFifth;
    public GameObject groundPlanting;
    public bool panelActivated;
    public GameObject myPlants;

    private void Start()
    {
        newItemNeededID = itemNeededID;
        myPlants.SetActive(false);
        Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[0];
    }

    void Update()
    {
        //itemNeededID = newItemNeededID;
        //newItemNeededID = itemNeededID;
        Debug.Log("el item que tengo es " + itemNeededID);

        if (newItemNeededID == 1)
        {
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", true);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", false);
            groundPlanting.GetComponent<Renderer>().material = groundMaterialStateSecond;
            Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[1];
            
        }
        if (newItemNeededID == 2)
        {
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", true);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", false);
            groundPlanting.GetComponent<Renderer>().material = groundMaterialStateThird;
            Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[2];
        }
        if (newItemNeededID == 3)
        {
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", false);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", true);
            groundPlanting.GetComponent<Renderer>().material = groundMaterialStateFourth;
            Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[3];

        }
        if (newItemNeededID == 4)
        {
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", true);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", false);
            Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", false);
            groundPlanting.GetComponent<Renderer>().material = groundMaterialStateFourth;
            Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[4];
            myPlants.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if(panelActivated)
        {
            return;
        }

        if (other.tag == "Player")
        {
            //if State of terrain is zero = need Pickaxe and change to ground green 

            if (Game_Manager.instance.FindNumberOfXItem(newItemNeededID) <= 0)
            {
                //Determine what you need for the land
                panelMission.SetActive(true);
                panelActivated = true;

                itemNeededImage.texture = Game_Manager.instance.items[newItemNeededID].itemSprite.texture;
                groundPlanting.GetComponent<Renderer>().material = groundMaterialStateFirts;
                Game_Manager.instance.myMissionActual.GetComponent<SpriteRenderer>().sprite = Game_Manager.instance.imagenMissionCloud[0];

            }
            else {

               /*
                if (newItemNeededID == 1)
                {
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", true);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", false);
                    groundPlanting.GetComponent<Renderer>().material = groundMaterialStateSecond;
                }
                if (newItemNeededID == 2)
                {
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", true);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", false);
                    groundPlanting.GetComponent<Renderer>().material = groundMaterialStateThird;
                }
                if (newItemNeededID == 3)
                {
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Idle", false);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Move", false);
                    Game_Manager.instance.characterAnimtor.GetComponent<Animator>().SetBool("Dig", true);
                    groundPlanting.GetComponent<Renderer>().material = groundMaterialStateFourth;

                }*/
                //after doing the animation is that the counter is increased
                newItemNeededID++;
            }
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        panelActivated = false;
    }

    public void ClosePanelMission() {
        panelMission.SetActive(false);
        panelActivated = false;
    }

}
