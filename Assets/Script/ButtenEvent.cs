using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class button_Event : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(MyAction);
    }

    void MyAction()
    {
        Debug.Log("Pressed");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}