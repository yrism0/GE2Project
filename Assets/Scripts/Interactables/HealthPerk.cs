using UnityEngine;

public class HealthPerk : Interactable
{ // SS - Health Perk Script -  Makes use of interactable base - Manages health perk

    // Variables

    [SerializeField] private Material activeMaterial;
    private MeshRenderer meshRenderer;

    [SerializeField] private int hPerkCost;
    private bool hPerkBought = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerManager.instance.powerOn == true) // IF Power is enabled THEN...
        {
            meshRenderer.material = activeMaterial; // Change object material
            promptMessage = ("Buy Health Perk? (300P)"); // Change prompt text
        }
    }

    protected override void Interact()
    {
        if (PowerManager.instance.powerOn == true)
        {
            if (PointManager.instance.points >= hPerkCost && hPerkBought == false)
            {
                hPerkBought = true;
                PointManager.instance.points -= hPerkCost;
                PointManager.instance.UpdatePointsUI();
                promptMessage = ("Already Purchased");

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


    }
}
