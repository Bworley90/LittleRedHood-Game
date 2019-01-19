using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceScript : MonoBehaviour
{
    private GameObject gameInfo;
    public GameObject ForgeMenu;

    // Start is called before the first frame update
    void Start()
    {
        gameInfo = GameObject.FindGameObjectWithTag("GameInfo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ForgeMenu.GetComponent<OpenForgeMenu>().nearForge = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ForgeMenu.GetComponent<OpenForgeMenu>().nearForge = false;
    }
}
