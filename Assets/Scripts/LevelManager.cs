using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    #region Delacration
    public bool win { get; private set; }
    public float gravityScale = 2.5f;
    public string soundName;
    public List<Obstacles> obstaclesGravitable;
    public List<Obstacles> backgroundDecor;
    public static LevelManager Instance { get; private set; }
    #endregion
    private void Awake() {
        Instance = this;
        win = false;
    }
    void Start() {
        SoundManager.Instance.StopAllSounds();
        SoundManager.Instance.Play(soundName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameManager.GameState == GameManager.GameStates.InGame) GameManager.Instance.ChangeGameState("Pause");
            else if (GameManager.GameState == GameManager.GameStates.Pause) GameManager.Instance.ChangeGameState("InGame");
        }
    }
    public void UpdateGravity(bool up) {
        if(obstaclesGravitable.Count > 0) {
            foreach (Obstacles o in obstaclesGravitable) {
                if (up) o.ChangeGravity(-gravityScale);
                else o.ChangeGravity(gravityScale);
            }
        }
        if (backgroundDecor.Count > 0) {
            foreach (Obstacles o in backgroundDecor) {
                o.StartCoroutine(o.Led());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<PlayerController>() != null) {
            win = true;
            GameManager.Instance.ChangeGameState("GameOver");
        }
    }
}
