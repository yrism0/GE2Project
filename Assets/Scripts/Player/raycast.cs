using UnityEngine;
using UnityEngine.EventSystems;

public class raycast : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    public static float DisFromTar;
    [SerializeField] private float ToTar;
    public static bool isDoor = false;
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
            if (hit.collider.CompareTag("door"))
            {
                isDoor = true;
            }
            else
            {
                isDoor = false;
            }

            if (hit.collider.CompareTag("Z"))
            {
               isZ = true;
            }
            else
            {
                isZ = false;
            }

        }
       
    }

    
}
