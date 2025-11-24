using UnityEngine;

public class AmmoBox : Interactable
{
    [SerializeField] private int abCost;

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
        if (PointManager.instance.points >= abCost)
        {            
            PointManager.instance.points -= abCost;
            PointManager.instance.UpdatePointsUI();
            Gun.instance.MaxAmmo();
        }
        else
        {
            return;
        }

    }
}
