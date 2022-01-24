using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        InGame,
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
}
