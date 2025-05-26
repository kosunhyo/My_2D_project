using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isDeath = false;
    public bool isStart = false;
    public bool isClear = false;
    public static int score = 0;

    public GameObject gameOverUI;
    public GameObject gameClearUI;

    void Start()
    {
        isDeath = false;
        isStart = false;
        score = 0;
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        if (isDeath && !gameOverUI.activeSelf)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f; // 게임 정지
            
        }
        if (isClear && !gameClearUI.activeSelf)
        {
            gameClearUI.SetActive(true);
            Time.timeScale = 0f; // 게임 정지

        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void Menu()
    {
        Debug.Log("메인메뉴");
    }
}