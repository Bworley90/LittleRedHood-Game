using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFruit : MonoBehaviour
{

    public int speed;
    public GameObject target;
    public GameObject gameInfo;
    public int fruitMultiplier;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo");
        fruitMultiplier = gameInfo.GetComponent<GameInfo>().fruitCountMultiplier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 PathToPlayer = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().MovePosition(PathToPlayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) // Does it collide with the player
        {
            gameInfo.GetComponent<GameInfo>().fruitCount += fruitMultiplier; // fruitMultiplier to fruit counter
            Destroy(gameObject); // Destroying the object;
        }
    }
}
