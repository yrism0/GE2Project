using UnityEngine;

public class wavespawn : MonoBehaviour
{

    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject zombies;

    public static int Zcount = 0;
    public static int maxZcount = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Zcount <= maxZcount)
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
