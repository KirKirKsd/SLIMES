using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private void FixedUpdate() {
        transform.rotation = Quaternion.Euler(1f, 1f, Player.gunAngle);
        transform.localScale = new Vector3(Player.mirror, Player.mirror, 1f);
    }

}
