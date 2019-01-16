using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushWhack : MonoBehaviour  // Make it to where you have to hit the tree again to start the timer for reset.

{

    public bool hit = false;
    public GameObject orange;
    private float randomNumber;
    private int minWaitTime;
    private int maxWaitTime;


    // Start is called before the first frame update
    void Start()
    {
        TreeStartUp();  // Starting the randomNumber and setting Hit to false or true
        minWaitTime = 10; // Minimum wait time for retry of a hit
        maxWaitTime = 20; // Maximum wait time for retry of a hit
    }


    public void Attacked()
    {
        if(randomNumber >= 1) // If the randomNumber is greater or equal to 1 
        {
            if (hit == false)
            {
                Instantiate(orange, transform.position, transform.rotation); // Create the orange
                hit = true; // So they can't double hit
                StartCoroutine("ResetTreeFruit"); // Reset tree
            }
        }
        else if (randomNumber < 1) // If less than 1 
        {
            StartCoroutine("ResetTreeFruit");  // Try for a new seeed;
        }
        
        
    }

    private IEnumerator ResetTreeFruit()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime)); // Wait for a reset
        TreeStartUp(); // Finding a new number and seeing if it will reset the tree, if not itll try again
    }

    void TreeStartUp()
    {
        randomNumber = Random.Range(0, 2);

        if (randomNumber >= 1)
        {
            hit = false;
        }
        else
        {
            hit = true;
            //StartCoroutine("ResetTreeFruit");
        }
    }
}
