using UnityEngine;

public class Door : Interactable
{// SS - Door Script - Makes use of interactable base - Opens door

    // Variables

    [SerializeField] private GameObject door;
    
    [SerializeField] private int doorCost;
    

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
        if (PointManager.instance.points >= doorCost) // IF Player points are greater than the Door cost THEN...
        {
          
            Destroy(gameObject); // Remove Door
            PointManager.instance.points -= doorCost; // Remove Cost from Points
            PointManager.instance.UpdatePointsUI(); 
        }
        else
        {
            return;
        }
        
    }

}
