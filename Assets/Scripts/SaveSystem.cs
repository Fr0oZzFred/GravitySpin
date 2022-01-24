using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem { 
    public static void SaveGameManager(GameManager gameManager) {
        string path = Application.persistentDataPath + "/GameManager.data";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        GameManagerData data = new GameManagerData(gameManager);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameManagerData LoadGameManager() {
        string path = Application.persistentDataPath + "/GameManager.data";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            GameManagerData data = formatter.Deserialize(stream) as GameManagerData;
            stream.Close();
            return data;
        } else {
            Debug.LogError("Save file pas trouvé dans " + path);
            return null;
        }
    }
}
