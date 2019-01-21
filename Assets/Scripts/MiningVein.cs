using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningVein : MonoBehaviour
{
    public Sprite damageVein;
    public Sprite finishedVein;
    public int healthOfNode;
    public bool inRange = false;

    private void Start()
    {
        healthOfNode = Random.Range(3, 6);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Use") && inRange == true)
        {
            HealthCheck();
        }
    }

    

    private void HealthCheck()
    {
        if (healthOfNode >= 4)
        {
            GameInfo.oreObtained += 1;
            healthOfNode -= 1;
        }
        else if (healthOfNode == 1 ||healthOfNode == 2 || healthOfNode == 3)
        {
            GetComponent<SpriteRenderer>().sprite = damageVein;
            GameInfo.oreObtained += 1;
            healthOfNode -= 1;
        }
        else if (healthOfNode == 0)
        {
            GameInfo.oreObtained += 1;
            GetComponent<SpriteRenderer>().sprite = finishedVein;
            StartCoroutine("FinishedMining");
            healthOfNode -= 1;
        }
    }

    private IEnumerator FinishedMining()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
        // Possibly respawn a node somewhere

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

}
