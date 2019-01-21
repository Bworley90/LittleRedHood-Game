using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBlockingLog : MonoBehaviour
{
    public bool entered;
    public GameObject gameInfo;
    public GameObject axeUI;


    // Start is called before the first frame update
    void Start()
    {
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(entered == true)
        {
            if(gameInfo.GetComponent<GameInfo>().axePurchased == true)
            {
                if(Input.GetButtonDown("Use"))
                {
                    entered = false;
                    gameObject.SetActive(false);
                    axeUI.SetActive(false);
                    gameInfo.GetComponent<GameInfo>().axePurchased = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            entered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            entered = false;
        }
    }
}
