using System;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    public Text timeText;
    public MenuController menuController;
    public InputField inputField;

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

        // save their time
        PlayerPrefs.SetFloat("timeScore", recordedTime);
 
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

        Time.timeScale = 0; // stop time
    }

    public void OnSubmitButton()
    {
        // make sure it's not empty
        if (!string.IsNullOrEmpty(inputField.text))
        {

            string name = inputField.text;
            PlayerPrefs.SetString("name", name);

            Time.timeScale = 1; // resume time

            // change the scene
            menuController.ChangeScene(2);
        }
            
    }
}
