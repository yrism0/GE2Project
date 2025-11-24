using UnityEngine;
using UnityEngine.UI;
public class WaveCounter : MonoBehaviour
{

    public static WaveCounter instance;

    public Text wavecountdisplay;
    public static int wavecount;
    public static int wavetick;

    public static int finalWaveCount; // For use in End results UI


    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wavecount = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        wavecountdisplay.text = "wave" + ":" + wavecount.ToString(); 
        if (wavetick == 3)
        {
            Debug.Log("wave+1");
            wavecount++;
            finalWaveCount = wavecount;

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Z"))
            {
                Destroy(gameObj);
            }
            wavespawn.Zcount = 0;
            wavetick = 0;
        }
    }
}
