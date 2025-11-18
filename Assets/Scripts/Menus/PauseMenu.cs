using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Variables

    public GameObject pauseMenu;
    public static bool isPaused;

    public static bool helpOpened;
    public GameObject helpMenu;

    public GameObject playerHUD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                PauseGame();                
            }
            else if (isPaused == true)
            {
                return;
            }
            else
            {
                if (helpOpened == false)
                {
                    pauseFailsafe();
                }
            }
        }
    }

    public void PauseGame()
    {
        // Displays Pause Menu and freezes gameplay through timescale
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        // Method used by Resume button on Pause menu -
        // Hides Pause Menu and gameplay resumes
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GoToMainMenu()
    {
        // Method used by Quit button on Pause Menu
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowHelpMenu()
    {
        pauseMenu.SetActive(false);
        helpMenu.SetActive(true);
        playerHUD.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideHelpMenu()
    {
        pauseMenu.SetActive(true);
        helpMenu.SetActive(false);
        playerHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void pauseFailsafe()
    {
        // Method used to ensure that menus don't get stuck open.
        pauseMenu.SetActive(false);
        helpMenu.SetActive(false);
        isPaused = false;
        helpOpened = false;
        Time.timeScale = 1f;
        playerHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
