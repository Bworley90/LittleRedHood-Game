using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodAxe : MonoBehaviour
{
    public bool entered;
    public GameObject axeUI;
    public int cost;
    public GameObject gameInfo;
    public bool purchased;



    // Start is called before the first frame update
    void Start()
    {
        entered = false;
        purchased = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(entered == true && gameInfo.GetComponent<GameInfo>().fruitCount >= cost && purchased == false)
        {
            if(Input.GetButtonDown("Use"))
            {
                purchased = true;
                gameInfo.GetComponent<GameInfo>().fruitCount -= cost;
                axeUI.SetActive(true);
                StartCoroutine("PurchasedAxe");
                

            }
        }
        else if(entered == true && gameInfo.GetComponent<GameInfo>().fruitCount < cost)
        {
            // Nothing so far
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

    private IEnumerator PurchasedAxe()
    {
        gameObject.GetComponent<Animator>().SetBool("purchased", true);
        gameInfo.GetComponent<GameInfo>().axePurchased = true;
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }
}
