using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGloves : MonoBehaviour
{

    public GameObject gameInfo;
    public int cost;
    public bool readyToBuy;
    public bool bought;
    public GameObject fruitGlovesUI;

    // Start is called before the first frame update
    void Start()
    {
        readyToBuy = false;
        bought = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(readyToBuy == true)
        {
            if (gameInfo.GetComponent<GameInfo>().fruitCount >= cost && bought == false) // IF there is enough fruit and hasn't been bought
            {
                if (Input.GetButtonDown("Use"))
                {
                    gameObject.GetComponent<Animator>().SetBool("bought", true);
                    gameInfo.GetComponent<GameInfo>().fruitCount -= cost;
                    gameInfo.GetComponent<GameInfo>().fruitCountMultiplier += 1;
                    bought = true;
                    fruitGlovesUI.SetActive(true);
                    StartCoroutine("DisableGlovesOnPurchase");
                }
            }
            else if (gameInfo.GetComponent<GameInfo>().fruitCount < cost)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Nothing
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            readyToBuy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            readyToBuy = false;
        }
    }

    private IEnumerator DisableGlovesOnPurchase()
    {
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }
}
