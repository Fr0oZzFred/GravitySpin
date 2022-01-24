using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb;

    public float force;
    public float speed;
    public float scaleForce;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        float hori = Input.GetAxis("Horizontal");
        //float verti = Input.GetAxis("Vertical");
        /*this.transform.position = new Vector2(
            transform.position.x + hori * speed * Time.deltaTime,
            transform.position.y
            );*/
        rb.velocity = new Vector2(
            rb.velocity.x + hori * speed * Time.deltaTime,
            rb.velocity.y);
        //rb.AddForce(new Vector2(hori * speed * Time.deltaTime, rb.velocity.y));
        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -50, 50), Mathf.Clamp(rb.velocity.y, -50, 50));
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if(transform.localScale.x > 0) {
                transform.localScale *= -1;
            }
            rb.velocity += Vector2.up * force;
            rb.gravityScale = -2.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (transform.localScale.x < 0) {
                transform.localScale *= -1;
            }
            rb.velocity += Vector2.down * force;
            rb.gravityScale = 2.5f;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if(rb.gravityScale < 0) {
                rb.velocity += Vector2.down * force;
            } else {
                rb.velocity += Vector2.up * force;
            }
        }
        Quaternion rot;
        if (rb.gravityScale < 0) {
            rot = Quaternion.Euler(0, 0, hori * 25);
        } else {
            rot = Quaternion.Euler(0, 0, -(hori * 25));
        }
        rb.MoveRotation(rot);
        Debug.Log(rb.velocity);
        //transform.rotation = rot;
    }
}
