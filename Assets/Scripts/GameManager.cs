using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManagerData {
    public int lastLevelDone;
    public GameManagerData(GameManager gameManager) {
        lastLevelDone = gameManager.lastLevelDone;
    }
}
public class GameManager : MonoBehaviour
{
    #region Declaration

    public int lastLevelDone = 1;
    public int levelCount;

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
        lastLevelDone = data.lastLevelDone;
    }

    public void ChangeGameState(GameStates gs) {
        GameStates oldGS = GameState;
        GameState = gs;
        UIManager.Instance.ChangeState(oldGS);
        switch (GameState) {
            case GameStates.MainMenu:
                LoadScene("MainMenu");
                SoundManager.Instance.StopAllSounds();
                SoundManager.Instance.Play("MainMenuTheme");
                Time.timeScale = 1f;
                break;
            case GameStates.LevelSelection:
                break;
            case GameStates.Settings:
                break;
            case GameStates.InGame:
                Time.timeScale = 1f;
                break;
            case GameStates.Pause:
                Time.timeScale = 0f;
                break;
            case GameStates.GameOver:
                Time.timeScale = 0f;
                UIManager.Instance.GameOver(LevelManager.Instance.win);
                if (LevelManager.Instance.win) {
                    lastLevelDone = lastLevelDone < levelCount ? lastLevelDone + 1 : lastLevelDone;
                }
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
    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(int name) {
        SceneManager.LoadScene(name);
    }
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ChangeGameState("InGame");
    }
    public void PlayNextLevel() {
        if(lastLevelDone < levelCount) {
            LoadScene("Level " + (lastLevelDone + 1));
            ChangeGameState("InGame");
        } else {
            LoadScene("Level " + levelCount);
            ChangeGameState("InGame");
        }
    }
    #endregion
    public void Quit() {
        Application.Quit();
    }
    private void OnApplicationQuit() {
        SaveData();
    }
}
