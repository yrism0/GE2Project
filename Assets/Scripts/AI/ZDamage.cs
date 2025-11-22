using UnityEngine;

public class ZDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerhealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerhealth.TakeDamage(damage);
        }
    }
}
