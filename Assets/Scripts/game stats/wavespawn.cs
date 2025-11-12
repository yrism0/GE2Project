using UnityEngine;

public class wavespawn : MonoBehaviour
{

    [SerializeField] private Transform[] spwaners;
    [SerializeField] private GameObject zombies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            spwanzombie();
        }
    }

    private void spwanzombie()
    {
        int randomInt = Random.Range(1, spwaners.Length);
        Debug.Log(randomInt);
    }
}
