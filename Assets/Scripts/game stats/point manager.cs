using UnityEngine;
using UnityEngine.UI;

public class pointmanager : MonoBehaviour
{
    public static int points; // store players points

    public Text pointText; // display points on UI

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0; // starting points
        UpdatePointsUI(); // update points

    }
    
    public void AddPoints(int points) // adding points and updating UI
    {
        points += points;
        UpdatePointsUI();
    }

    void UpdatePointsUI() // display points 
    {
        pointText.text = "Score: " + points;
    }
}
