using UnityEngine;
using UnityEngine.UI;
public class wavecounter : MonoBehaviour
{
    public Text wavecountdisplay;
    public static int wavecount;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wavecount = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        wavecountdisplay.text = "wave" + ":" + wavecount.ToString(); 
        if (Input.GetKeyDown("m"))
        {
            Debug.Log("wave+1");
            wavecount = wavecount+1;
           

            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Z"))
            {
                Destroy(gameObj);
            }

        }
    }
}
