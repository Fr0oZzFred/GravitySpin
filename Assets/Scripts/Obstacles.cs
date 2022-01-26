using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Obstacles : MonoBehaviour {
    #region Declaration
    public float forceJumpGravity;
    [Header("Rotation")]
    public float rotateSpeed;
    [Header("Moving")]
    public float moveSpeedX;
    public float moveSpeedY;
    public float amplitudeX;
    public float amplitudeY;
    
    Rigidbody2D rb2d;
    Action action;
    #endregion


    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        action += Rotate;
        action += MoveX;
        action += MoveY;
    }

    void Update() {
        action();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null) {
            p.canJump = true;
            p.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        PlayerController p = collision.GetComponent<PlayerController>();
        if (p != null) {
            p.isGrounded = false;
        }
    }
    void MoveX() {
        transform.position = new Vector2(transform.position.x + Mathf.Sin(Time.time * moveSpeedX) * amplitudeX * Time.deltaTime, transform.position.y );
    }

    void MoveY() {
        transform.position = new Vector2(transform.position.x, transform.position.y + Mathf.Sin(Time.time * moveSpeedY) * amplitudeY * Time.deltaTime);
    }

    void Rotate() {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public void ChangeGravity(float gravity) {
        rb2d.gravityScale = gravity;
        if(gravity < 0) rb2d.velocity += Vector2.up * forceJumpGravity;
        else rb2d.velocity += Vector2.down * forceJumpGravity;
        StartCoroutine(Led());

    }
    public IEnumerator Led() {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
