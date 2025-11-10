using UnityEngine;

public class wavecounter : MonoBehaviour
{
    public GameObject wavecountdisplay;
    public int wavecount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wavecount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("wave+1");
            wavecount = wavecount+1;
        }
    }
}
