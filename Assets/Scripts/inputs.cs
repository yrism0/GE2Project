using UnityEngine;

public class inputs : MonoBehaviour
{

    public GameObject Pmenu;
    public GameObject Hud;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//sets up the mouse 
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            Pmenu.SetActive(true);
            Hud.SetActive(false);
            //Time.timeScale = 0;
        }
    }

    
}
