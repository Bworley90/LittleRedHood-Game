﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreCount : MonoBehaviour
{

    public GameObject gameInfo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = GameInfo.oreObtained.ToString();
    }
}
