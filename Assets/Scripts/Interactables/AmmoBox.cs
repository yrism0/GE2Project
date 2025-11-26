using UnityEngine;

public class AmmoBox : Interactable
{ // SS - AmmoBox Script -  Makes use of interactable base - Gives max ammo for current weapon

    // Variables
    [SerializeField] private int abCost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact() // ON Interact...
    {
        if (PointManager.points >= abCost) // IF Player points are greater than Cost THEN...
        {            
            PointManager.points -= abCost; // Remove Cost from Points
            PointManager.instance.UpdatePointsUI();
            Gun.instance.MaxAmmo(); // Run MaxAmmo function - found in the Gun Script
        }
        else
        {
            return;
        }

    }
}
