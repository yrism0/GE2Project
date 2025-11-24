using UnityEngine;

public class DamagePerk : Interactable
{
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
        if(PowerManager.instance.powerOn == true)
        {
            meshRenderer.material = activeMaterial;
            promptMessage = ("Buy Damage Perk? (PRICE)");
        }
    }

    protected override void Interact()
    {
        if(PowerManager.instance.powerOn == true)
        {
            if (PointManager.instance.points >= dPerkCost && dPerkBought == false)
            {
                dPerkBought = true;
                PointManager.instance.points -= dPerkCost;
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
