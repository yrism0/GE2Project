using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame()
    {
        SceneManager.LoadScene("level");// loads the game
        Debug.Log("GAME LOADED");

    }
    public void exitgame()
    {
        Application.Quit();//exits the game
        Debug.Log("GAME CLOSED");
    }
    public void Bmain()
    {
        SceneManager.LoadScene("main menu");// loads the main menu
        Debug.Log("MENU LOADED");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void starthelp()
    {
        SceneManager.LoadScene("help menu");// loads the game
        Debug.Log("help LOADED");

    }
}
