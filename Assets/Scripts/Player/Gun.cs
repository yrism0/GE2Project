using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public static Gun instance;

    public float gunDamage = 10f;
    public float range = 100f;
    public int ammo = 0;
    public int revammo = 0;
    public int ammodiff;

    public bool damagePerk;

    public Text Acount;
    public Camera fpsCam;
    public LayerMask mask;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        ammo = 7;
        revammo = 49;
        ammodiff = 0;
    }

    private void Update()
    {
        Acount.text = ammo.ToString() + "/" + revammo.ToString();
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.green);
        if (Input.GetButtonDown("Fire1") & ammo > 0 )
        {
            Shoot();
        }

        if (Input.GetKeyDown("r") & ammo < 7 & revammo > 0)
        {
            ammo += ammodiff;
            revammo -= ammodiff;
            ammodiff = 0;
        }
        if (Input.GetKeyDown("k"))
        {
            revammo = 100;
        }

        if (revammo <= -1)
        {
            revammo = 0;
        }

        if (ammodiff > revammo)
        {
            ammodiff = revammo;
        }
    }

    void Shoot()
    {
        ammo -= 1;
        ammodiff += 1;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~mask))
        {
            
            //Debug.Log(hit.transform.name);

            Zstats zombieHit = hit.transform.GetComponent<Zstats>();
            if (zombieHit != null)
            {
                zombieHit.TakeDamage(gunDamage);
            }
        }

    }

    public void MaxAmmo()
    {
        revammo = 70;
        ammo = 7;
        ammodiff = 0;
    }

    public void BuyDamagePerk()
    {
        if (damagePerk == false && PowerManager.instance.powerOn == true)
        {
            damagePerk = true;
            gunDamage = 20f;
        }
    }
}
