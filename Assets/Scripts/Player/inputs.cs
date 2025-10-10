using UnityEngine;

public class inputs : MonoBehaviour
{
    //menus
    public GameObject Pmenu;
    public GameObject Hud;

    // raycst 
    [SerializeField] float internalDistance;
    [SerializeField] bool open = false;
    [SerializeField] GameObject stuff;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//sets up the mouse 
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) // set to ESC for final build 
        {
            Pmenu.SetActive(true);
            Hud.SetActive(false);
            //Time.timeScale = 0;
        }

        internalDistance = raycast.DisFromTar;
        if (open == false && internalDistance < 5 && raycast.isDoor == true)
        {
            if (Input.GetKeyDown("e"))
            {
                Destroy(stuff);
            }
          
        }

        if (open == false && internalDistance < 5 && raycast.isDoor == true)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                
            }

        }
    }


    
}
