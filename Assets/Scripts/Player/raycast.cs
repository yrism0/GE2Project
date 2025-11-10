using UnityEngine;
using UnityEngine.EventSystems;

public class raycast : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public static float DisFromTar;
    [SerializeField] private float ToTar;
    public static bool isDoor = false;
    public static bool isDoor2 = false;
    public static bool isDoor3 = false;
    public static bool isDoor4 = false;
    public static bool isDoor5 = false;
    public static bool isDoor6 = false;
    public static bool isZ = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            ToTar = hit.distance;
            DisFromTar = hit.distance;
            //checks for Door1
            if (hit.collider.CompareTag("door"))
            {
                isDoor = true;
            }
            else
            {
                isDoor = false;
            }
            //checks for door2
            if (hit.collider.CompareTag("door2"))
            {
                isDoor2 = true;
            }
            else
            {
                isDoor2 = false;
            }
            //checks for door3
            if (hit.collider.CompareTag("door3"))
            {
                isDoor3 = true;
            }
            else
            {
                isDoor3 = false;
            }
            //checks for door4
            if (hit.collider.CompareTag("door4"))
            {
                isDoor4 = true;
            }
            else
            {
                isDoor4 = false;
            }
            //checks door 5
            if (hit.collider.CompareTag("door5"))
            {
                isDoor5 = true;
            }
            else
            {
                isDoor5 = false;
            }
            //checks door 6
            if (hit.collider.CompareTag("door6"))
            {
                isDoor6 = true;
            }
            else
            {
                isDoor6 = false;
            }




            // checks for zombies 
            if (hit.collider.CompareTag("Z"))
            {
               isZ = true;
               
            }
            else
            {
                isZ = false;
            }

            if (DisFromTar < 10 && raycast.isZ == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Zhit");
                    hit.collider.gameObject.GetComponent<Zstats>()?.TakeDamage(10);
                }

            }

        }
       
    }

    
}
