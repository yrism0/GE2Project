using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject door;
    private bool doorOpen = false;
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
        if (PointManager.instance.points >= doorCost)
        {
          
            Destroy(gameObject);
            PointManager.instance.points -= doorCost;
            PointManager.instance.UpdatePointsUI();
        }
        else
        {
            return;
        }
        
    }

}
