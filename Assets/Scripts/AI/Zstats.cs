using UnityEngine;

public class Zstats : MonoBehaviour
{

    public GameObject Z;
    public  float  health = 50f;

    // Will be used for shooting zombie points

    public int zombieBonusPoints = 50;
   
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
        AddBonusPoints();
        health -= damageAmount;
        if (health <= 0f)
        {
            
            if (zombieBonusPoints > 0)
            {
                PointManager.instance.points += zombieBonusPoints;
                PointManager.instance.UpdatePointsUI();
                
            }
            else
            {
                return;
            }
            Die();
        }
    }

    void Die()
    {
        PointManager.instance.AddPoints();
        Destroy(gameObject);
        wavespawn.Zcount --;
        WaveCounter.wavetick++;
    }

    void AddBonusPoints()
    {
        if (zombieBonusPoints > 0)
        {
            zombieBonusPoints -= 10;
            PointManager.instance.points += 10;
            PointManager.instance.UpdatePointsUI();
        }
        
    }

   
}
