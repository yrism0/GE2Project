using UnityEngine;

public class PowerManager : Interactable
{ // SS - Power Manager Script - Manages the power state for the level

    // Variables
    public Animator lever;
    public static PowerManager instance;
    public bool powerOn = false;
    AudioManager audioManager;

   
        
   
    private void Awake()
    {
        instance = this;
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

    public void TurnPowerOn()
    {
        if (powerOn == false)
        {
            lever.Play("pull the lever kronk");
            audioManager.PlaySFX(audioManager.powerOn); // plays SFX
            powerOn = true;
            promptMessage = ("...");
        }

        // SS - Utilises Unity Events to also change Material of Object
        
        
    }

    


}
