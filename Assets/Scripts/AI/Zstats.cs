using UnityEngine;

public class Zstats : MonoBehaviour
{

    public GameObject Z;
    public  float  health = 50f;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
        
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        pointmanager.points += 100;
        Destroy(gameObject);
    }

   
}
