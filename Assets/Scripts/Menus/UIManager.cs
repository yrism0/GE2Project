using System.ComponentModel;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{// SS - Pause Menu script - Used for all UI code now

    public static UIManager instance;

    // Variables
    [Header("Screens")]
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject helpMenu;
    public static bool helpOpened;

    public GameObject playerHUD;
    public GameObject endResults;

    [Header("End Results Variables")]
    public Text finalWaveText;

    [Header("Raycast Prompt")]
    private Text promptText;

    public bool gameover;
    private void Awake()
    {
        instance = this;
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & gameover == false)
        {
            if(isPaused == false)
            {
                PauseGame();
                playerHUD.SetActive(false);
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
        Gun.ispaused = true;
        ShowMouse();
    }

    public void ResumeGame()
    {
        // Method used by Resume button on Pause menu 
        // Hides Pause Menu and gameplay resumes
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        HideMouse();
        playerHUD.SetActive(true);
        Gun.ispaused = false;
    }

    public void GoToMainMenu()
    {
        // Method used by Quit button on Pause Menu
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
        ShowMouse();
        
    }

    public void ShowHelpMenu()
    {
        pauseMenu.SetActive(false);
        helpMenu.SetActive(true);
        playerHUD.SetActive(false);
        ShowMouse();
        playerHUD.SetActive(false);
    }

    public void HideHelpMenu()
    {
        pauseMenu.SetActive(true);
        helpMenu.SetActive(false);
        playerHUD.SetActive(true);
        ShowMouse();
        playerHUD.SetActive(false);
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
        HideMouse();
        playerHUD.SetActive(true);
        Gun.ispaused = false;

    }

    public void ShowResultsScreen()
    {
        playerHUD.SetActive(false);
        endResults.SetActive(true);
        ShowMouse();
        gameover = true;
        finalWaveText.text = "YOU SURVIVED " + WaveCounter.finalWaveCount + " WAVES";
    }

    public void RestartGame()
    {
        pauseFailsafe();
        SceneManager.LoadScene("Level");
    }

    #region Hide/Show Mouse

    private void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerLook.Instance.xSensitivity = 30f;
        PlayerLook.Instance.ySensitivity = 30f;
        PlayerMotor.instance.speed = 5f;

    }

    private void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerLook.Instance.xSensitivity = 0f;
        PlayerLook.Instance.ySensitivity = 0f;
        PlayerMotor.instance.speed = 0f;
    }

    

    #endregion
}
