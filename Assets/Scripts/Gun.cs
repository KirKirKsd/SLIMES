using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public Transform shootPoint;
    private bool canShoot = true;

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(1f, 1f, Player.gunAngle);
        transform.localScale = new Vector3(Player.mirror, Player.mirror, 1f);

        if (Input.GetMouseButton(0) && canShoot) {
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(bullet, shootPoint.position, Quaternion.Euler(1f, 1f, Player.gunAngle - 90f));
        canShoot = false;
        StartCoroutine(Reload());
    }

    IEnumerator Reload() {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
    
}
