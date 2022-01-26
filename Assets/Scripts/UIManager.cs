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

    public void GameOver(bool win) {
        winGo.SetActive(win);
        looseGo.SetActive(!win);
        SoundManager.Instance.StopAllSounds();
        if (win) SoundManager.Instance.Play("WinTheme");
        else SoundManager.Instance.Play("LooseTheme");
    }
    #region Debug
    #endregion
}
