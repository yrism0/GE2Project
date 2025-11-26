using UnityEngine;

public class DamagePerk : Interactable
{ // SS - Damage Perk Script -  Makes use of interactable base - Manages the Damage Perk Interactable

    // Variables

    [SerializeField] private Material activeMaterial;
    private MeshRenderer meshRenderer;

    [SerializeField] private int dPerkCost;
    private bool dPerkBought = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PowerManager.instance.powerOn == true) // IF Power is enabled THEN...
        {
            meshRenderer.material = activeMaterial; // Change object material
            promptMessage = ("Buy Damage Perk? (3000P)"); // Change interaction prompt
        }
    }

    protected override void Interact()
    {
        if(PowerManager.instance.powerOn == true) // IF Power is enabled THEN...
        {
            if (PointManager.points >= dPerkCost && dPerkBought == false) // Player can buy perk if they have enough points
            {
                dPerkBought = true;
                PointManager.points -= dPerkCost;
                PointManager.instance.UpdatePointsUI();
                promptMessage = ("Already Purchased"); // Change prompt once bought
                
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
        
        // SS - Unity Event runs on interaction - Runs BuyDamagePerk Function on Gun Script

    }
}
