using UnityEngine;

public class PlayerInteract : MonoBehaviour
{ // SS - Player Interact Script - Manages the Raycast for player interactions

    // Variables

    private Camera cam;
    [SerializeField] private float distance = 3f;

    [SerializeField] private LayerMask mask; // Mask is used to only hit objects in the Interactable Layer
    private PlayerUI playerUI;

    private InputManager inputManager;
        
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }
        
    void Update()
    {
        playerUI.UpdateText(string.Empty); // Prompt UI is blank when not looking at anything
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered) // IF Input Action Interact is used THEN...
                {
                    interactable.BaseInteract(); // Runs BaseInteract function found in the Interactable script
                }
            }
        }

    }
}
