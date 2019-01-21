using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreColorChange : MonoBehaviour
{

    public Sprite orangeButton;
    public Sprite greenButton;
    private GameObject gameInfo;
    public GameObject axeUI;
    public GameObject axeCostText;
    public int oreCount;
    public int cost;
    public GameObject forgeMenuUI;


    // Start is called before the first frame update
    void Awake()
    {
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        
    }

    // Update is called once per frame
    void Update()
    {
        CanCraft();
        cost = gameInfo.GetComponent<GameInfo>().ironAxeCost;
        axeCostText.GetComponent<Text>().text = gameInfo.GetComponent<GameInfo>().ironAxeCost.ToString();
    }




    private void CanCraft()
    { 
        if (GameInfo.oreObtained < cost)
        {
            gameObject.GetComponent<Image>().sprite = orangeButton;
        }
        else if (GameInfo.oreObtained >= cost)
        {
            gameObject.GetComponent<Image>().sprite = greenButton;
        }
    }

    public void CraftIronAxe ()
    {
        if (GameInfo.oreObtained >= cost && gameInfo.GetComponent<GameInfo>().axePurchased == false)
        {
            if(forgeMenuUI.GetComponent<Animator>().GetBool("isOpen"))
            {
                GameInfo.oreObtained -= cost;
                gameInfo.GetComponent<GameInfo>().axePurchased = true;
                axeUI.SetActive(true);
                Debug.Log("Craft Axe");
            }

        }
    }
}
