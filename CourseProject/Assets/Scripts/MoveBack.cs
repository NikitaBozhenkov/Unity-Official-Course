using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour {
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private float deleteZ = -8;

    // Update is called once per frame
    void Update() {
        if (gameObject.CompareTag("Wall")) {
            if (transform.position.z < -10) {
                var pos = transform.position;
                pos.z = 90;
                transform.position = pos;
            }
        } else {
            if (transform.position.z < deleteZ) {
                Destroy(gameObject);
            }
        }
        
        transform.Translate(moveDirection * (speed * Time.deltaTime));
    }
}