using UnityEngine;

public class Zstats : MonoBehaviour
{

    public GameObject Z;
    public  float  health = 0;
    public static float damage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 50;
        damage = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (health <= 0)
        {
            Debug.Log("Zkilled");
            pointmanager.points += 100;
            Destroy(this.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Zhit");
    }

   
}
