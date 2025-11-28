using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{ // SS - Gun Script - Controls behaviour of the currently held weapon

    // Variables
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject pistolT;
    public GameObject shotgunT;
    public static Gun instance;
    public bool ispistolActive;
    public bool isshotgunActive;

    [Header("Gun Stats")]
    public float gunDamage = 10f;
    public float shotgundmg = 100f;
    public float range = 100f;
    public UnityEvent onGunShoot;
    public float fireCooldown;

    public bool isAutomatic;
    public static bool ispaused;

    private float currentCooldown;

    [Header("Ammo")]
    public int ammo = 0;
    public int revammo = 0;
    public int ammodiff;
    public int ammo2;
    public int revammo2;
    public int ammodiff2;

    [Header("Reload")]
    public float reloadTime = 2f;
    public float rsTimer;
    bool isReloading = false;
    bool canShoot = true;    
    [SerializeField] private Slider reloadSlider;
    [SerializeField] GameObject reloadUI;
    public Animator reloadAnimator;
    public AnimationClip pistolReload;
    public AnimationClip shotgunReload;
    public AnimationClip idle;

    [Header("Gun Perks")]
    public bool damagePerk;
    private float dPerkCost = 3000f;

    [Header("Other")]
    public Text Acount;
    public Text Acount2;
    public Camera fpsCam;
    public LayerMask mask;




    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        ispaused = false;
        pistol.SetActive(true);
        pistolT.SetActive(true);
        shotgun.SetActive(false);
        shotgunT.SetActive(false);
        ispistolActive = true;
        isshotgunActive = false;
        reloadUI.SetActive(false);
        reloadAnimator = GetComponent<Animator>();
        currentCooldown = fireCooldown;

        ammo = 7;
        revammo = 49;
        ammo2 = 2;
        revammo2 = 20;
        ammodiff = 0;
        ammodiff2 = 0;
    }

    private void Update()
    {
        Acount.text = ammo.ToString() + "/" + revammo.ToString();
        Acount2.text = ammo2.ToString() + "/" + revammo2.ToString();
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, Color.green);
        if (isAutomatic)
        {
            if (Input.GetButton("Fire1") & ammo > 0 & canShoot == true & !isReloading & ispistolActive == true & ispaused == false)
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
            if (Input.GetButtonDown("Fire1") & ammo > 0 & canShoot == true & !isReloading & ispistolActive == true & ispaused == false)
            {
                if (currentCooldown <= 0f)
                {
                    onGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                    Shoot();
                }
            }
        }

        if (Input.GetButtonDown("Fire1") & ammo2 > 0 & canShoot == true & !isReloading & isshotgunActive == true & ispaused == false)
        {
            if (currentCooldown <= 0f)
            {
                onGunShoot?.Invoke();
                currentCooldown = fireCooldown;
                Shoot2();
            }
        }

        currentCooldown -= Time.deltaTime;
        
          

        UpdateReloadUI();
        if (Input.GetKeyDown("r") & ammo < 7 & revammo > 0 && isReloading == false & ispistolActive == true)
        {

            Reload();

        }
        if (Input.GetKeyDown("r") & ammo2 < 2 & revammo2 > 0 && isReloading == false & isshotgunActive == true)
        {

            Reload2();

        }
        if (!isReloading)
        {
            // weapon swap
            if (Input.GetKeyDown("1") & isshotgunActive == true)
            {
                reloadAnimator.SetTrigger("isPistol");
                shotgun.SetActive(false);
                pistol.SetActive(true);
                shotgunT.SetActive(false);
                pistolT.SetActive(true);
                isshotgunActive = false;
                ispistolActive = true;
            }
            if (Input.GetKeyDown("2") & ispistolActive == true)
            {
                reloadAnimator.ResetTrigger("isPistol");                
                pistol.SetActive(false);
                shotgun.SetActive(true);
                pistolT.SetActive(false);
                shotgunT.SetActive(true);
                isshotgunActive = true;
                ispistolActive = false;

            }
        }
        

        if (revammo <= -1)
        {
            revammo = 0;
        }

        if (ammodiff > revammo)
        {
            ammodiff = revammo;
        }
        if (revammo2 <= -1)
        {
            revammo2 = 0;
        }

        if (ammodiff2 > revammo2)
        {
            ammodiff2 = revammo2;
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
    void Shoot2()
    {
        ammo2 -= 1;
        ammodiff2 += 1;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, ~mask))
        {

            //Debug.Log(hit.transform.name);

            Zstats zombieHit = hit.transform.GetComponent<Zstats>();
            if (zombieHit != null)
            {
                zombieHit.TakeDamage(shotgundmg);
            }
        }

    }

    public void MaxAmmo()
    {
        if (PointManager.points >= 1200) // IF Player points are greater than Cost THEN...
        {
            PointManager.points -= 1200; // Remove Cost from Points
            PointManager.instance.UpdatePointsUI();
            // Pistol Ammo
            revammo = 70;
            ammo = 7;
            ammodiff = 0;

            // Shotgun Ammo
            revammo2 = 30;
            ammo2 = 2;
            ammodiff2 = 0;
        }
        else
        {
            return;
        }
       
    }

    public void BuyDamagePerk()
    {
        if (damagePerk == false && PowerManager.instance.powerOn == true & PointManager.points >= dPerkCost)
        {
            damagePerk = true;
            gunDamage = gunDamage * 2;
            shotgundmg = shotgundmg * 2;
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
    private void Reload2() // Cannot shoot while reloading and Invokes the ReloadCompleted function after (reloadTime) amount of seconds
    {
        isReloading = true;
        canShoot = false;
        reloadAnimator.SetTrigger("isReloading");
        Invoke("ReloadCompleted2", reloadTime);
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
    private void ReloadCompleted2() // Reloads the Weapon and enables shooting again
    {
        ammo2 += ammodiff2;
        revammo2 -= ammodiff2;
        ammodiff2 = 0;

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
