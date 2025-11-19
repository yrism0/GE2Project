using UnityEngine;

public class inputs : MonoBehaviour
{
     // raycst 
    [SerializeField] float internalDistance;
    [SerializeField] float pointsCheckup;
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
     
        internalDistance = raycast.DisFromTar;
        pointsCheckup = pointmanager.points;
        if (open == false && internalDistance < 5 && raycast.isDoor == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open");
                pointsCheckup -= 0;
                Destroy(D1);
            }
          
        }

        if (open == false && internalDistance < 5 && raycast.isDoor2 == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open2");
                pointsCheckup -= 0;
                Destroy(D2);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor3 == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open3");
                pointsCheckup -= 0;
                Destroy(D3);
            }

        }
        
        if (open == false && internalDistance < 5 && raycast.isDoor4 == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open4");
                pointsCheckup -= 0;
                Destroy(D4);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor5 == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open5");
                pointsCheckup -= 0;
                Destroy(D5);
            }

        }

        if (open == false && internalDistance < 5 && raycast.isDoor6 == true && pointsCheckup >= 0)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("open6");
                pointsCheckup -= 0;
                Destroy(D6);
            }

        }


       
    }


    
}
