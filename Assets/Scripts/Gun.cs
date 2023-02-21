using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public Transform shootPoint;

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(1f, 1f, Player.gunAngle);
        transform.localScale = new Vector3(Player.mirror, Player.mirror, 1f);

        if (Input.GetMouseButton(0)) {
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(1f, 1f, Player.gunAngle - 90f));
    }

}
