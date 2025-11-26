using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{

    public static PointManager instance;
    public int points; // store players points

    public Text pointText; // display points on UI

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = 0; // starting points
        UpdatePointsUI(); // update points

    }
    
    public void AddPoints() // adding points and updating UI
    {
        
        points += 100;
        UpdatePointsUI();
    }

    public void UpdatePointsUI() // display points 
    {
        pointText.text = "POINTS: " + points;
    }


    
}
