using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus1 : MonoBehaviour
{
    [Header("Main Menu")]
    public GameObject mainMenuScreen;


    [Header("Help Menu")]
    public GameObject helpScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("level");// loads the game
        Debug.Log("GAME LOADED");

    }
    public void ExitGame()
    {
        Application.Quit();//exits the game
        Debug.Log("GAME CLOSED");
    }
    
    public void ShowHelpMenu()
    {
        helpScreen.SetActive(true);
        mainMenuScreen.SetActive(false);
    }

    public void HideHelpMenu()
    {
        helpScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
    
}
