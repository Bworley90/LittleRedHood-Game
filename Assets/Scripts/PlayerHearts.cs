using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHearts : MonoBehaviour
{
    public GameObject gameInfo;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameInfo.GetComponent<GameInfo>().playerHealth > gameInfo.GetComponent<GameInfo>().maxHealth)
        {
            gameInfo.GetComponent<GameInfo>().playerHealth = gameInfo.GetComponent<GameInfo>().maxHealth;
        }
        
        
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < gameInfo.GetComponent<GameInfo>().playerHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
   
            if (i < gameInfo.GetComponent<GameInfo>().maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
