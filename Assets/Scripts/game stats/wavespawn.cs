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
    public static bool isroom3open;
    public static bool isroom4open;
    public static bool isroom5open;
    public static bool isroom6open;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpwanDone = false;
        isroom1open = false;
        isroom2open = false;
        isroom3open = false;
        isroom4open = false;
        isroom5open = false;
        isroom6open = false;
        Zcount = 0;
        maxZcount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Zcount == maxZcount)
        {
            isSpwanDone = true;
        }
        // start room
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
        if (Zcount <= maxZcount & isSpwanDone == false & isroom3open == true)
        {

            spawnzombie4();
            Zcount++;
        }
        if (Zcount <= maxZcount & isSpwanDone == false & isroom4open == true)
        {

            spawnzombie5();
            Zcount++;
        }
        if (Zcount <= maxZcount & isSpwanDone == false & isroom5open == true)
        {

            spawnzombie6();
            Zcount++;
        }
        if (Zcount <= maxZcount & isSpwanDone == false & isroom6open == true)
        {

            spawnzombie7();
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
    public void openroom1A3()
    {
        if (PointManager.points >= 1000)
        {
            isroom1open = true;
            isroom3open = true;
        }


    }
    public void openroom2A4()
    {
        if (PointManager.points >= 1000)
        {
            isroom2open = true;
            isroom4open = true;
        }


    }
    public void openroom5A4()
    {
        if (PointManager.points >= 1200)
        {
            isroom5open = true;
            isroom4open = true;
        }
    }
    public void openroom5A3()
    {
        if (PointManager.points >= 1200)
        {
            isroom5open = true;
            isroom3open = true;
        }
    }
    public void openroom6()
    {
        if (PointManager.points >= 1500)
        {
            isroom6open = true;
            
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
    private void spawnzombie4()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
    private void spawnzombie5()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
    private void spawnzombie6()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
    private void spawnzombie7()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
}
