using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Variables

    
    private float health;
    [Header("Health Values")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    private float lerpTimer;    
    [SerializeField] private float healDelay = 5f;
    [SerializeField] private float healSpeed = 2f;
    private float healTimer;

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
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(Random.Range(5, 10));
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            RestoreHealth(15);
        }
    }

    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        healthBar.value = health;        
        lerpTimer += Time.deltaTime;
        if (lerpTimer > healDelay)
        {
            healTimer += Time.deltaTime;
            if (healTimer > healSpeed)
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
}
