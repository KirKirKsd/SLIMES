using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector2 movement;
    public float moveSpeed = 3.5f;

    public static float gunAngle;
    public static Vector2 mousePos;
    public static Vector2 playerPos;
    public static float mirror = 1f;
    
    public Rigidbody2D rb;

    private void Update() {
        movement = getInputs();
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(transform.position.x, transform.position.y);
        
        if (playerPos.x < mousePos.x) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            mirror = 1f;
        }
        else {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            mirror = -1f;
        }

        gunAngle = getAngleMouse(mousePos, transform.position);
    }

    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;
    }

    Vector2 getInputs() {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    float getAngleMouse(Vector2 mousePos, Vector3 playerPos) {
        float angle = Mathf.Atan2(mousePos.y - playerPos.y, mousePos.x - playerPos.x) * Mathf.Rad2Deg;

        return angle;
    }

}
