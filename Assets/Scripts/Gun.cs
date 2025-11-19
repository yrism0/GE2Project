using UnityEngine;

public class Gun : MonoBehaviour
{
    public float gunDamage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public LayerMask mask;

    private void Update()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.green);
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~mask))
        {
            
            Debug.Log(hit.transform.name);

            Zstats zombieHit = hit.transform.GetComponent<Zstats>();
            if (zombieHit != null)
            {
                zombieHit.TakeDamage(gunDamage);
            }
        }

    }
}
