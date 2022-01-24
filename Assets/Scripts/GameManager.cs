using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManagerData {
    public int tutu;
    public GameManagerData(GameManager gameManager) {
        tutu = gameManager.tutu;
    }
}
public class GameManager : MonoBehaviour
{
    #region Declaration

    public int tutu = 1;

    public enum GameStates {
        MainMenu,
        LevelSelection,
        Settings,
        InGame,
        Pause,
        GameOver
    }
    public static GameStates GameState { get; private set; }

    public static GameManager Instance { get; private set; }
    #endregion

    void Awake() {
        Instance = this;
    }

    public void SaveData() {
        SaveSystem.SaveGameManager(this);
    }
    public void LoadData() {
        GameManagerData data = SaveSystem.LoadGameManager();
        tutu = data.tutu;
    }

    public void ChangeGameState(GameStates gs) {
        GameStates oldGS = GameState;
        GameState = gs;
        UIManager.Instance.ChangeState(oldGS);
        switch (GameState) {
            case GameStates.MainMenu:
                break;
            case GameStates.InGame:
                break;
        }
    }
    public void ChangeGameState(int gs) {
        ChangeGameState((GameStates)gs);
    }
    public void ChangeGameState(string gs) {
        switch (gs) {
            case "MainMenu":
                ChangeGameState(0);
                break;
            case "LevelSelection":
                ChangeGameState(1);
                break;
            case "Settings":
                ChangeGameState(2);
                break;
            case "InGame":
                ChangeGameState(3);
                break;
            case "Pause":
                ChangeGameState(4);
                break;
            case "GameOver":
                ChangeGameState(5);
                break;
            default:
                Debug.LogWarning("GameState not found");
                break;
        }
    }

    #region SceneManagement
    public void ChangeScene(string name) {
        SceneManager.LoadScene(name);
    }
    public void ChangeScene(int name) {
        SceneManager.LoadScene(name);
    }
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion
    public void Quit() {
        Application.Quit();
    }
    private void OnApplicationQuit() {
        SaveData();
    }
}
