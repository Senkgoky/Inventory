using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance; //Need Created Singleton pattern
    public bool isPaused;

    public List<Item> items= new List<Item>(); //What kind of items we have
    public List<int> itemsNumbers = new List<int>(); //How many items we have
    public GameObject[] slots;
    public List<int> counterItems = new List<int>();


    public GameObject[] toolHand;
    public Animator characterAnimtor;

    public GameObject spriteCloud;
    public GameObject myMissionActual;
    public Sprite[] imagenMissionCloud;
    public GameObject vegetableItem;

    //public Item addItem_01; 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayItems();
        for (int i = 0; i < 2; i++) {
            toolHand[i].SetActive(false);
        }

        spriteCloud.SetActive(true);
        myMissionActual.GetComponent<SpriteRenderer>().sprite = imagenMissionCloud[0];
        characterAnimtor.GetComponent<Animator>().SetBool("Move", true);
        toolHand[0].SetActive(false);
        toolHand[1].SetActive(false);
        toolHand[2].SetActive(false);
        vegetableItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayItems() {
       
        //we ignore the fact
        for (int i = 0; i < slots.Length; i++) {
            if (i < items.Count)
            {
                if (itemsNumbers[i] == 0)
                {
                    //Update slots Items image
                    slots[i].transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    slots[i].transform.GetChild(2).GetComponent<Image>().sprite = null;

                    //Update slots Count text
                    slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = new Color(0, 0, 0, 0);
                    slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = null;

                   //Update slots Stickers
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                else {
                    //Update slots Items image
                    slots[i].transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    slots[i].transform.GetChild(2).GetComponent<Image>().sprite = items[i].itemSprite;

                    //Update slots Count text
                    slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = new Color(0, 0, 0, 1);
                    slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = itemsNumbers[i].ToString();

                    //Update slots Stickers
                    slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
               
               
            }
            else  //Some remove Item
            {
                //Update slots Items image
                slots[i].transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(2).GetComponent<Image>().sprite = null;

                //Update slots Count text
                slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = null;

                //Update Close / Throw button
              //  slots[i].transform.GetChild(3).gameObject.SetActive(false);

                //Up;pas slots Stickers
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void AddItem(Item _item) {
        if (!items.Contains(_item))
        {
            //if there is one existing item in our inventory (List)
            items.Add(_item);
            itemsNumbers.Add(1);
        }
        else   //if there is a new _item in our inventory
        {
            Debug.Log("You have alredy have this One");
            for (int i = 0; i < items.Count; i++) {
                if (_item == items[i])
                {
                    itemsNumbers[i]++;
                }
            }
        }

        DisplayItems();
       

    }

    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item)) //if there is one existing item in our inventory (List)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    itemsNumbers[i]--;
                    if (itemsNumbers[i] == 0)
                    {
                        //We have to remove this item
                        items.Remove(_item);
                        itemsNumbers.Remove(itemsNumbers[i]);
                    }

                }
            }
        }
        else {
            Debug.Log("There is no " + _item + " in my inventory");
        }
        //if there is no items inside inventory
        DisplayItems();
    }

    public int FindNumberOfXItem(int idItemToFind)
    {

        
        return itemsNumbers[idItemToFind];
        
    }

    public bool FindItemID(int idItemSearch) {
        bool result = false;
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                if (items[i].itemID == idItemSearch)
                {
                  

                    result = true;

                }
            } 
        }


                return result;
    }
}
