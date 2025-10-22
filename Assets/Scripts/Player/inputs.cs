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
    [SerializeField] GameObject D1;
    [SerializeField] GameObject D2;
    [SerializeField] GameObject D3;
    [SerializeField] GameObject D4;
    [SerializeField] GameObject D5;
    [SerializeField] GameObject D6;



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
        if (open == false && internalDistance < 5 && raycast.isDoor == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open");
                Ponitscheckup -= 0;
                Destroy(D1);
            }
          
        }

        if (open == false && internalDistance < 5 && raycast.isDoor2 == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open2");
                Ponitscheckup -= 0;
                Destroy(D2);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor3 == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open3");
                Ponitscheckup -= 0;
                Destroy(D3);
            }

        }
        
        if (open == false && internalDistance < 5 && raycast.isDoor4 == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open4");
                Ponitscheckup -= 0;
                Destroy(D4);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor5 == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open5");
                Ponitscheckup -= 0;
                Destroy(D5);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor6 == true && Ponitscheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open6");
                Ponitscheckup -= 0;
                Destroy(D6);
            }

        }


        // for the gun gives range and tells it for fire when mouse is clicked 
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
