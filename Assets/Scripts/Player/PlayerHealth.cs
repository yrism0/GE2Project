using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{ // SS - Player Health Script - Manages the Player health and its corresponding UI

    // Variables
        
    [Header("Health Values")]
    public float maxHealth = 100f;
    private float health;

    
    private float lerpTimer;    
    [SerializeField] private float healDelay = 5f; // The amount of time that must pass before healing begins
    [SerializeField] private float healSpeed = 0.01f; // The speed the health restores at (The lower the faster)
    private float healTimer;


    private bool healthPerk;
    private float hPerkCost = 3000f;

    [Header("Health UI")]
    public Slider healthBar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        health = Mathf.Clamp(health, 0, maxHealth); // Clamps health so that its values MUST stay between 0 and the MaxHealth value
        UpdateHealthUI();
        
        if (Input.GetKeyDown(KeyCode.K)) // Debug Code to Test
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.L)) // Debug Code to Test
        {
            RestoreHealth(15);
        }
    }

    public void UpdateHealthUI()
    {
       
        healthBar.value = health;        
        lerpTimer += Time.deltaTime;
        if (lerpTimer > healDelay) // IF (healDelay) amount of time has passed THEN...
        {
            healTimer += Time.deltaTime; 
            if (healTimer > healSpeed) // Everytime healTimer ticks past healSpeed THEN...
            {
                health++;
                healTimer = 0;
            }
            
        }



    }
  
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        if (health <= 0)
        {
            GameOver();
        }
        
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }

    public void GameOver()
    {
        UIManager.instance.ShowResultsScreen();
    }

    public void BuyHealthPerk()
    {
        if (healthPerk == false && PowerManager.instance.powerOn == true & PointManager.points >= hPerkCost)
        {
            healthPerk = true;
            maxHealth = 150f;
            healDelay = 4f;
            healthBar.maxValue = 150; // Increases max value of slider to show increased health
           
        }
    }
}
