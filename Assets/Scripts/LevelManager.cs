using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    #region Delacration
    public bool win { get; private set; }
    public float gravityScale = 2.5f;
    public string soundName;
    public GameObject arrow;
    public GameObject particles;
    public Obstacles box;
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
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null) {
            win = true;
            particles.SetActive(true);
            arrow.SetActive(false);
            if (box != null) { 
                box.rotateSpeed = 0;
                box.moveSpeedX = 0;
                box.moveSpeedY = 0;
            }
            p.Stop();
            p.enabled = false;
        SoundManager.Instance.StopAllSounds();
            StartCoroutine(End());
        }
    }
    IEnumerator End() {
        SoundManager.Instance.StopAllSounds();
        SoundManager.Instance.Play("WinTheme");
        yield return new WaitForSeconds(2);
        GameManager.Instance.ChangeGameState("GameOver");
    }
}
