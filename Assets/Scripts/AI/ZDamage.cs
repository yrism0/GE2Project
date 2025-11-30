using System.Collections;
using UnityEngine;

public class ZDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerhealth;
    public bool delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        delay = false;
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" & delay == false)
        {
            playerhealth.TakeDamage(damage);
            StartCoroutine(Delay());
        }
    }

  IEnumerator Delay()
    {
        delay = true;
        yield return new WaitForSeconds(1);
        delay = false;
    }
}
