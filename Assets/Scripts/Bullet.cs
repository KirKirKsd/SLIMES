using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 10f;

    private void Start() {
        Destroy(gameObject, 3);
    }

    private void Update() {
        rb.velocity = transform.up * speed;
    }

}
