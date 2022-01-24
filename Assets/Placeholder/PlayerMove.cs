using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    public float force;
    public float speed;
    public float scaleForce;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        this.transform.position = new Vector2(
            transform.position.x + hori * speed * Time.deltaTime,
            transform.position.y + verti * speed * Time.deltaTime
            );
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity += Vector2.up * force;
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            transform.localScale *= -1;
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            transform.localScale += Vector3.one * scaleForce * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.I)){
            transform.localScale -= Vector3.one * scaleForce * Time.deltaTime;
        }
        //Vector2 v = Mathf.Sin
    }
}
