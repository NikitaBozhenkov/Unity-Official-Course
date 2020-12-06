using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Vector3 moveDirection;
    private Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        var vel = _rb.velocity;
        vel.z = moveDirection.z * speed;
        _rb.velocity = vel;
        //_rb.AddForce(moveDirection * speed, ForceMode.Force);
    }
}