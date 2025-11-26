using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerDataManager : MonoBehaviour
{
    public int sWave;
    public int sPoints;
    
    
    public void SaveGame() // Saves points and wave variables to a .json file when the function is called
    {
        PlayerData playerData = new PlayerData();
        playerData.sWave = WaveCounter.wavecount;
        playerData.sPoints = WaveCounter.startWavePoints; // startWavePoints saves points at beginning of wave
        

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
        //UIManager.instance.GoToMainMenu();
    }

   
    public void LoadGame() // Loads points and wave variable from a .json file when the function is called
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            // Load variables
            WaveCounter.wavecount = loadedData.sWave;
            PointManager.points = loadedData.sPoints;
            
            PointManager.instance.UpdatePointsUI(); // Updates point UI to show changes when loaded
        }
        else
        {
            Debug.LogWarning("File not found");
        }

    }
}
