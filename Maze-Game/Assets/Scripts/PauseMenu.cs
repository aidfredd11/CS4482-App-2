using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isMenuActive)
        {
            isMenuActive = false;
            Resume();
        }
    }

    // Button OnClick functions
    public void Pause()
    {
        pauseMenu.SetActive(true);
        ToggleTime(0);
    }
    public void Restart(int sceneID)
    { 
        LoadScene(sceneID, 1, false);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        ToggleTime(1);
    }
    public void Exit(int sceneID)
    {
        LoadScene(sceneID, 1, false);
    }

    // Helper functions

    // change state of the time scale
    private void ToggleTime(int timeScale)
    {
        Time.timeScale = timeScale;
    }
    // Change or reload scene
    // 0 = main menu, 1 = game, 2 = leaderboard
    private void LoadScene(int sceneID, int timeScale, bool activeStatus)
    {
        ToggleTime(timeScale);
        Stopwatch.isActive = activeStatus;
        SceneManager.LoadScene(sceneID);
    }
}
