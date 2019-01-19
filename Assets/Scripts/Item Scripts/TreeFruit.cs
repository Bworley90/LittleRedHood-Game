using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruit : MonoBehaviour
{

    public int speed;
    public GameObject target;
    public GameObject gameInfo;
    public int fruitMultiplier;
    private float[] randomDirection = new float[2];
    private int randomRangeNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        fruitMultiplier = gameInfo.GetComponent<GameInfo>().fruitCountMultiplier;
    }

    private void Awake()
    {
        randomDirection[0] = -100; // Force of the fruit
        randomDirection[1] = 100; // Force of the fruit
        randomRangeNumber = Random.Range(0, 2); // Grabbing a 1 or 0 to set the direction of the fruit
        SpawnFruit();
        StartCoroutine("StopGravity");
    }

    // Update is called once per frame
    /*
    void FixedUpdate()
    {
        Vector3 PathToPlayer = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().MovePosition(PathToPlayer);
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // Does it collide with the player
        {
            gameInfo.GetComponent<GameInfo>().fruitCount += fruitMultiplier; // fruitMultiplier to fruit counter
            Destroy(gameObject); // Destroying the object;
        }
    }

    private void SpawnFruit ()
    {
        GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(randomDirection[randomRangeNumber], 200), transform.position);
    }

    private IEnumerator StopGravity()
    {
        yield return new WaitForSeconds(.6f);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0; // turn off gravity;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); // Set velocity to 0 to stop movement;
    }
}
