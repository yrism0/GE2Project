using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Variables
    
    private float health;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    

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


    }
  
    public void TakeDamage(float damage)
    {
        health -= damage;
        
    }

    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
    }
}
