using UnityEngine;

public class wavespawn : MonoBehaviour
{

    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject zombies;
    

    public static int Zcount = 0;
    public static double maxZcount = 4;
    public bool isWaveDone;
    public static bool isSpwanDone;
    public static bool isroom1open;
    public static bool isroom2open;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpwanDone = false;
        isroom1open = false;
        isroom2open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Zcount == maxZcount)
        {
            isSpwanDone = true;
        }

        if (Zcount <= maxZcount & isSpwanDone == false & gameObject.CompareTag("spR0"))
        {
            spawnzombie();
            
            Zcount ++;
        }
        if (Zcount <= maxZcount & isSpwanDone == false & isroom1open == true )
        {
           
            spawnzombie2();
            Zcount++;
        }
        if (Zcount <= maxZcount & isSpwanDone == false & isroom2open == true)
        {

            spawnzombie3();
            Zcount++;
        }
    }

    public void openroom1()
    {
        if (PointManager.points >=750) 
        {
            isroom1open = true;
        }

       
    }
    public void openroom2()
    {
        if (PointManager.points >= 750)
        {
            isroom2open = true;
        }


    }


    private void spawnzombie()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
    private void spawnzombie2()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
    private void spawnzombie3()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
}
