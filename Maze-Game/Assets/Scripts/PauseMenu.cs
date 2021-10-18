using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isMenuActive = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenuActive)
        {
            Cursor.lockState = CursorLockMode.None;
            isMenuActive = true;
            Pause();
        } else if (Input.GetKeyDown(KeyCode.Escape) && isMenuActive)
        {
            isMenuActive = false;
            Resume();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart(int sceneID)
    {
        Debug.Log("Restart");
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f; 
    }
    public void Exit(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
