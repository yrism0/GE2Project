using System.Collections;
using UnityEngine;

public class HandGunFire : MonoBehaviour
{

    [SerializeField] AudioSource pistolFire;
    [SerializeField] GameObject pistol;
    [SerializeField] bool canFire = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //if left button pressed
        { 
            if(canFire == true)
            {
                canFire = false;
                StartCoroutine(FiringGun());
            }
        }
        
    }
    
    IEnumerator FiringGun()
    {
        pistolFire.Play();
        pistol.GetComponent<Animator>().Play("PistolFire"); // acccess the pistol animator compononent and play
        yield return new WaitForSeconds(0.5f); //wait for .5 seconds
        pistol.GetComponent<Animator>().Play("New State"); // acccess the pistol animator compononent and play
        yield return new WaitForSeconds(0.1f); //wait for .5 seconds
        canFire = true;
    }
}
