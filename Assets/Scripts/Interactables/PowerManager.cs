using UnityEngine;

public class PowerManager : Interactable
{
    
    public static PowerManager instance;
    public bool powerOn = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnPowerOn()
    {
        if (powerOn == false)
        {
            powerOn = true;
            promptMessage = ("...");
        }
        
        
    }

    protected override void Interact()
    {
        if (powerOn == true)
        {
            
        }

    }


}
