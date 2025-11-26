using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{ // SS - Gun Script - Controls behaviour of the currently held weapon

    // Variables

    public static Gun instance;

    [Header("Gun Stats")]
    public float gunDamage = 10f;
    public float range = 100f;
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public bool isAutomatic;

    private float currentCooldown;

    [Header("Ammo")]
    public int ammo = 0;
    public int revammo = 0;
    public int ammodiff;

    [Header("Reload")]
    public float reloadTime = 2f;
    public float rsTimer;
    bool isReloading = false;
    bool canShoot = true;    
    [SerializeField] private Slider reloadSlider;
    [SerializeField] GameObject reloadUI;
    public Animator reloadAnimator;

    [Header("Gun Perks")]
    public bool damagePerk;
    private float dPerkCost = 3000f;

    [Header("Other")]
    public Text Acount;
    public Camera fpsCam;
    public LayerMask mask;




    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        reloadUI.SetActive(false);
        reloadAnimator = GetComponent<Animator>();
        currentCooldown = fireCooldown;

        ammo = 7;
        revammo = 49;
        ammodiff = 0;
    }

    private void Update()
    {
        Acount.text = ammo.ToString() + "/" + revammo.ToString();
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.green);
        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") & ammo > 0 & canShoot == true & !isReloading)
            {
                if (currentCooldown <= 0f)
                {
                    onGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                    Shoot();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") & ammo > 0 & canShoot == true & !isReloading)
            {
                if (currentCooldown <= 0f)
                {
                    onGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                    Shoot();
                }
            }
        }

        currentCooldown -= Time.deltaTime;
        
          

        UpdateReloadUI();
        if (Input.GetKeyDown("r") & ammo < 7 & revammo > 0 && isReloading == false)
        {

            Reload();

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
        // Pistol Ammo
        
        revammo = 70;
        ammo = 7;
        ammodiff = 0;

        // Shotgun Ammo

    }

    public void BuyDamagePerk()
    {
        if (damagePerk == false && PowerManager.instance.powerOn == true & PointManager.instance.points >= dPerkCost)
        {
            damagePerk = true;
            gunDamage = 20f;
        }
    }

    #region Reload

    private void Reload() // Cannot shoot while reloading and Invokes the ReloadCompleted function after (reloadTime) amount of seconds
    {
        isReloading = true;
        canShoot = false;
        reloadAnimator.SetTrigger("isReloading");
        Invoke("ReloadCompleted", reloadTime);
    }
        
    private void ReloadCompleted() // Reloads the Weapon and enables shooting again
    {
        ammo += ammodiff;
        revammo -= ammodiff;
        ammodiff = 0;

        isReloading = false;
        canShoot = true;

        reloadAnimator.ResetTrigger("isReloading");
        reloadUI.SetActive(false);
        rsTimer = 0;
    }

    private void UpdateReloadUI()
    {
        
        
        if (isReloading)
        {
            rsTimer += Time.deltaTime;
            reloadSlider.maxValue = reloadTime;

            reloadUI.SetActive(true);
            
            reloadSlider.value = rsTimer;
            
            
        }
        else
        {
            rsTimer = 0;
        }
    }

    #endregion

}
