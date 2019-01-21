using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    //Fruit Counter
    public int fruitCount = 0;
    public Text fruitUINumber;
    public int fruitCountMultiplier;
    public bool axePurchased;

    // Player Info
    public GameObject playerUI;

    public int maxHealth;
    public int playerHealth;

    // Item Info

    public static int oreObtained;
    public int ironAxeCost;

    private void Start()
    {
        fruitCountMultiplier = 1;
        fruitCount = 0;
        axePurchased = false;
        ironAxeCost = 5;
    }


    void Update()
    {
        if(fruitUINumber != null)
        {
            fruitUINumber.text = fruitCount.ToString(); // Setting the number of fruit to the UI
        }
        

    }

}
