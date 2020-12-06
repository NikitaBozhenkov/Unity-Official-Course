using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Vector3 moveDirection;
    private Rigidbody _rb;

    [SerializeField] private float zDestroy = -5f;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        var vel = _rb.velocity;
        vel.z = moveDirection.z * speed;
        _rb.velocity = vel;

        if (transform.position.z < zDestroy) {
            Destroy(gameObject);
        }
    }


}