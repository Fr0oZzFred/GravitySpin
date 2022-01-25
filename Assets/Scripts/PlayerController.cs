﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rb;

    public float forceJump;
    public float forceJumpGravity;
    public float speed;
    public bool canJump = false;
    Animator animator;
    
    public SpriteRenderer srBackground;
    public Color colorUp;
    public Color colorDown;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update() {
        Move();
        ChangeGravity();
        Jump();
    }

    void Move() {
        //Movement
        float hori = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(
            rb.velocity.x + hori * speed * Time.deltaTime,
            rb.velocity.y);

        //Rotation
        Quaternion rot;
        if (rb.gravityScale < 0) {
            rot = Quaternion.Euler(0, 0, hori * 25);
        } else {
            rot = Quaternion.Euler(0, 0, -(hori * 25));
        }
        rb.MoveRotation(rot);

        //Animation
        animator.SetFloat("Speed",rb.velocity.x);
        if ((hori == 0) && (rb.velocity.x < 1) && (rb.velocity.x > -1)) animator.SetFloat("Speed", 1f);
    }

    void ChangeGravity() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            srBackground.flipY = false;
            srBackground.color = colorUp;
            if (transform.localScale.x > 0) {
                transform.localScale *= -1;
            }
            rb.velocity += Vector2.up * forceJumpGravity;
            rb.gravityScale = -LevelManager.Instance.gravityScale;
            LevelManager.Instance.UpdateGravity(true);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            srBackground.flipY = true;
            srBackground.color = colorDown;
            if (transform.localScale.x < 0) {
                transform.localScale *= -1;
            }
            rb.velocity += Vector2.down * forceJumpGravity;
            rb.gravityScale = LevelManager.Instance.gravityScale;
            LevelManager.Instance.UpdateGravity(false);
        }
    }
    void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            canJump = false;
            //Change la direction du saut d'après la gravity
            if (rb.gravityScale < 0) {
                rb.velocity += Vector2.down * forceJump;
            } else {
                rb.velocity += Vector2.up * forceJump;
            }
        }
    }
}
