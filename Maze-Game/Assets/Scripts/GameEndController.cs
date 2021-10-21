using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    private bool isGameEnded = false;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Finish line has been crossed
    public void GameEnd(float recordedTime)
    {
        // wait a second
        Invoke("ActivatePopup", 1);

        // Display their time
        TimeSpan time = TimeSpan.FromSeconds(recordedTime);
        timeText.text = time.ToString(@"mm\:ss\:fff");

    }

    private void ActivatePopup()
    {
        // enable popup game object and mouse

        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public bool IsGameEnded
    {
        get { return isGameEnded; }
        set { isGameEnded = value; }
    }

}
