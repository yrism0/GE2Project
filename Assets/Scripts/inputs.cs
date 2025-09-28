using UnityEngine;

public class inputs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resume()// unpasues the game 
    {

        Time.timeScale = 1;
        Debug.Log("pasued");
    }
}
