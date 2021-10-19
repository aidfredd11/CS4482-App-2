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

    public void Pause()
    {
        pauseMenu.SetActive(true);
        ToggleTime(0);
    }
    public void Restart(int sceneID)
    {
        ToggleTime(1);
        Stopwatch.isActive = false;
        SceneManager.LoadScene(sceneID);
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        ToggleTime(1);
    }
    public void Exit(int sceneID)
    {
        ToggleTime(1);
        SceneManager.LoadScene(sceneID);
    }

    // change state of the time scale
    private void ToggleTime(int timeScale)
    {
        Time.timeScale = timeScale;
    }
}
