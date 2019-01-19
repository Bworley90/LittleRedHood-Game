using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningVein : MonoBehaviour
{
    public GameObject gameInfo;
    public bool entered;
    public Sprite damageVein;
    private bool damagedVein;
    public Sprite finishedVein;
    private bool finished;

    // Start is called before the first frame update
    void Start()
    {
        entered = false;
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        damagedVein = false;
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (entered == true && finished == false)
        {
            if(Input.GetButtonDown("Use"))
            {
                StartCoroutine("Mining");
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

    private IEnumerator Mining()
    {
        if(damagedVein == false)
        {
            entered = false;
            gameInfo.GetComponent<GameInfo>().oreObtained += 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = damageVein;
            yield return new WaitForSeconds(2.0f);
            entered = true;
            damagedVein = true;
        }
        else if(damagedVein == true)
        {
            entered = false;
            gameInfo.GetComponent<GameInfo>().oreObtained += 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = finishedVein;
            yield return new WaitForSeconds(2.0f);
            finished = true;
            yield return new WaitForSeconds(3.0f);
            gameObject.SetActive(false);
        }
        
    }
}
