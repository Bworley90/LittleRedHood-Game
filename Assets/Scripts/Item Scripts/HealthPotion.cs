using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private bool entered;
    public GameObject gameInfo;
    public int cost;
    public Sprite purchasedGold;



    // Start is called before the first frame update
    void Start()
    {
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(entered == true && gameInfo.GetComponent<GameInfo>().fruitCount >= cost)
        {
            if(Input.GetButtonDown("Use"))
            {
                gameInfo.GetComponent<GameInfo>().playerHealth = gameInfo.GetComponent<GameInfo>().maxHealth;
                StartCoroutine("PurchasedPotion");
                gameInfo.GetComponent<GameInfo>().fruitCount -= cost;
                gameInfo.GetComponent<GameInfo>().playerHealth = gameInfo.GetComponent<GameInfo>().maxHealth;
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

    private IEnumerator PurchasedPotion()
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = purchasedGold;
        yield return new WaitForSeconds(4.0f);
        gameObject.SetActive(false);
    }
}
