using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreColorChange : MonoBehaviour
{

    public Sprite orangeButton;
    public Sprite greenButton;
    public GameObject gameInfo;
    public int oreCount;
    public int cost;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CanCraft();
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
}
