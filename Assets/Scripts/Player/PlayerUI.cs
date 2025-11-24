using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] private Text promptText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
