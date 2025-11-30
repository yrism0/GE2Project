using UnityEngine;




public class HealthPerk : Interactable
{ // SS - Health Perk Script -  Makes use of interactable base - Manages health perk

    // Variables
    public GameObject screen;
    
    [SerializeField] private Material activeMaterial;
    private MeshRenderer meshRenderer;

    [SerializeField] private int hPerkCost;
    private bool hPerkBought = false;
    AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screen.SetActive(false);
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerManager.instance.powerOn == true) // IF Power is enabled THEN...
        {
            screen.SetActive(true);
            // meshRenderer.material = activeMaterial; // Change object material
            promptMessage = ("Buy Health Perk? (3000P)"); // Change prompt text
        }
        

    }

    protected override void Interact()
    {
        if (PowerManager.instance.powerOn == true)
        {
            if (PointManager.points >= hPerkCost && hPerkBought == false)
            {
                hPerkBought = true;
                audioManager.PlaySFX(audioManager.ammoPurchase); // plays SFX
                PointManager.points -= hPerkCost;
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
