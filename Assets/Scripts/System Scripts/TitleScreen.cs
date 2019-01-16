using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public GameObject gameInfo;
    public GameObject playerUI;

    private void Awake()
    {

    }

    public void GoToGame()
    {
        playerUI.SetActive(true);
        DontDestroyOnLoad(playerUI);
        DontDestroyOnLoad(gameInfo);
        SceneManager.LoadScene("LRH 1.1");
    }


}
