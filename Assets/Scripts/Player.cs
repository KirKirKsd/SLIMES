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
    public Transform gun;

    public static Vector2 mousePos;
    public static Vector2 playerPos;
    public static float mirror = 1f;

    public Transform cursorPos;
    
    public Rigidbody2D rb;

    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
        movement = getInputs();
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = new Vector2(transform.position.x, transform.position.y);

        cursorPos.position = new Vector3(mousePos.x, mousePos.y, 0);

        if (playerPos.x < mousePos.x) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            mirror = 1f;
        }
        else {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            mirror = -1f;
        } 

        gunAngle = getAngleMouse(mousePos, gun.position);
    }

    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;
    }

    Vector2 getInputs() {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    float getAngleMouse(Vector2 mousePos, Vector3 objectPos) {
        float angle = Mathf.Atan2(mousePos.y - objectPos.y, mousePos.x - objectPos.x) * Mathf.Rad2Deg;

        return angle;
    }

}
