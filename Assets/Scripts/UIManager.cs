using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    #region Declaration
    public List<GameObject> uIElements;

    //[Header("Text")]
    [Header("LevelSelection")]
    public List<GameObject> levelButtonList;
    [Header("GameOver")]
    public GameObject winGo;
    public GameObject looseGo;
    [Header("Debug")]
    public bool enabledDebug;
    #endregion
    public static UIManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    private void Start() {
    }

    public void ChangeState(GameManager.GameStates oldGameState) {
        uIElements[(int)oldGameState].SetActive(false);
        uIElements[(int)GameManager.GameState].SetActive(true);
    }

    public void DisplayLevel(int lastLevelDone) {
        for(int i = 0; i < levelButtonList.Count; i++) {
            if (i <= lastLevelDone) {
                levelButtonList[i].SetActive(true);
            } else {
                levelButtonList[i].SetActive(false);
            }
        }
    }

    public void GameOver(bool win) {
        winGo.SetActive(win);
        looseGo.SetActive(!win);
    }

    #region Debug
    #endregion
}
