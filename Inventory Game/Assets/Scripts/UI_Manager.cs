using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI_Manager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject panelMission;
    public bool ifPanelActivated;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
      
    }

    // Update is called once per frame
    void Update()
    {
        InventoryController();
        StatePanelMission();
       
    }

    public void InventoryController() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //Pause Game, press Scape, Reesume the Game
            if (Game_Manager.instance.isPaused)
            {
                Game_Resume();
            }
            else {
                Game_Pause(); //Resume Game, press Scape, Pause the Game
            }
        }

        if (panelMission.activeSelf == true)
        {
            Time.timeScale = 0f; //stop the time the game
            Game_Manager.instance.isPaused = true;
        }
        else {
            Time.timeScale = 1.0f; //Real Timer is 1.0f
            Game_Manager.instance.isPaused = false;
        }

    }

    private void Game_Resume() {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1.0f; //Real Timer is 1.0f
        Game_Manager.instance.isPaused = false;
    }

    private void Game_Pause() {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0.0f; //stop the time the game
        Game_Manager.instance.isPaused =true;
    }

    public void Close_Invenroy() {
        Game_Resume();
    }

    public void Show_Inventory() {
        Game_Pause();
    }

    public void StatePanelMission() {
        if (panelMission.activeSelf==true) {
            ifPanelActivated = panelMission.activeSelf;
        }
    }
    

}
