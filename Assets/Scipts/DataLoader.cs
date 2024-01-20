using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{

    public Data LoadJsonFromStreamingAssets()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "data.json");

        
        if (File.Exists(filePath))
        {
            
            string jsonContent = File.ReadAllText(filePath);
            Debug.Log(jsonContent); 
            
            Data data = JsonConvert.DeserializeObject<Data>(jsonContent);

            return data;
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            return null;
        }
    }
}
