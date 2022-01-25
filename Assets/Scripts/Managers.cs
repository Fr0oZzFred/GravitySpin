using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Managers : MonoBehaviour
{
    void Start() {
        DontDestroyOnLoad(this.gameObject);
        string path = Application.persistentDataPath + "/GameManager.data";
        if (File.Exists(path)) {
            GameManager.Instance.LoadData();
        } else {
            GameManager.Instance.SaveData();
        }
        GameManager.Instance.ChangeGameState(GameManager.GameStates.MainMenu);
    }
}
