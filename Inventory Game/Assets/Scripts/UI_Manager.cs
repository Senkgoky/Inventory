using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public GameObject inventoryMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryController(); 
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

}
