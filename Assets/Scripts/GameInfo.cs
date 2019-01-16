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

    private void Start()
    {
        fruitCountMultiplier = 1;
        fruitCount = 0;
        axePurchased = false;
    }


    void Update()
    {
        if(fruitUINumber != null)
        {
            fruitUINumber.text = fruitCount.ToString(); // Setting the number of fruit to the UI
        }
        

    }

}
