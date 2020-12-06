using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour {
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed;

    void Update() {
        if (transform.position.z < -10) {
            var pos = transform.position;
            pos.z = 90;
            transform.position = pos;
        }

        transform.Translate(moveDirection * (speed * Time.deltaTime));
    }
}