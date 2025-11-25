using UnityEngine;

public class wavespawn : MonoBehaviour
{

    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject zombies;

    public static int Zcount = 0;
    public static double maxZcount = 4;
    public bool isWaveDone;
    public static bool isSpwanDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpwanDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Zcount == maxZcount)
        {
            isSpwanDone = true;
        }

        if ( Zcount <= maxZcount & isSpwanDone == false )
        {
            spawnzombie();
            Zcount ++;
        }
    }

    private void spawnzombie()
    {
        int randomInt = Random.Range(0, spawners.Length);
        Debug.Log(randomInt);
        Transform randomspwaner = spawners[randomInt];
        Instantiate(zombies, spawners[randomInt].position, spawners[randomInt].rotation);
    }
}
