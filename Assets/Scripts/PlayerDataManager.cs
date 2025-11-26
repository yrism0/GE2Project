using System.IO;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class PlayerDataManager : MonoBehaviour
{
    public int sWave;
    public int sPoints;
    
    public void SaveGame()
    {
        PlayerData playerData = new PlayerData();
        playerData.sWave = WaveCounter.wavecount;
        playerData.sPoints = PointManager.points;

        string json = JsonUtility.ToJson(playerData);
        string path = Application.persistentDataPath + "/playerData.json";
        System.IO.File.WriteAllText(path, json);
        //UIManager.instance.GoToMainMenu();
    }

   
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            // Load variables
            WaveCounter.wavecount = loadedData.sWave;
            PointManager.points = loadedData.sPoints;
        }
        else
        {
            Debug.LogWarning("File not found");
        }

    }
}
