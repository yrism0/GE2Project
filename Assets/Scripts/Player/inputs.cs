using UnityEngine;

public class inputs : MonoBehaviour
{
    //menus
    public GameObject Pmenu;
    public GameObject Hud;

    // raycst 
    [SerializeField] float internalDistance;
    [SerializeField] float Ponitscheckup;
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
        Ponitscheckup = pointmanager.points;
        if (open == false && internalDistance < 5 && raycast.isDoor == true && Ponitscheckup >= 100)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open");
                Ponitscheckup -= 100;
                Destroy(stuff);
            }
          
        }

        if (  internalDistance < 10 && raycast.isZ == true)
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                Debug.Log("Zhit");
                Zstats.health -= 25;
            }

        }
    }


    
}
