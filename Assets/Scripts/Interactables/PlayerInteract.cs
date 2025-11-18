using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Variables

    [SerializeField] private Camera cam;
    [SerializeField] private float distance = 3f;

    [SerializeField] private LayerMask mask;

    private PlayerUI playerUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
            }
        }
    }
}
