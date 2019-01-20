using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreColorChange : MonoBehaviour
{

    public Sprite orangeButton;
    public Sprite greenButton;
    public GameObject gameInfo;
    public GameObject axeUI;
    public GameObject axeCostText;
    public int oreCount;
    public int cost;


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
        oreCount = gameInfo.GetComponent<GameInfo>().oreObtained;

        if (oreCount < cost)
        {
            gameObject.GetComponent<Image>().sprite = orangeButton;
        }
        else if (oreCount >= cost)
        {
            gameObject.GetComponent<Image>().sprite = greenButton;
        }
    }

    public void CraftIronAxe ()
    {
        if (gameInfo.GetComponent<GameInfo>().oreObtained >= cost && gameInfo.GetComponent<GameInfo>().axePurchased == false)
        {
            gameInfo.GetComponent<GameInfo>().oreObtained -= cost;
            gameInfo.GetComponent<GameInfo>().axePurchased = true;
            axeUI.SetActive(true);


        }
    }
}
