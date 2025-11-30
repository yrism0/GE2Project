using UnityEngine;

public class Door : Interactable
{// SS - Door Script - Makes use of interactable base - Opens door

    // Variables
    AudioManager audioManager;

    [SerializeField] private GameObject door;
    
    [SerializeField] private int doorCost;

    


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {
        if (PointManager.points >= doorCost) // IF Player points are greater than the Door cost THEN...
        {
          
            Destroy(gameObject); // Remove Door
            audioManager.PlaySFX(audioManager.ammoPurchase); // plays SFX
            PointManager.points -= doorCost; // Remove Cost from Points
            PointManager.instance.UpdatePointsUI(); 
        }
        else
        {
            return;
        }
        
    }

}
