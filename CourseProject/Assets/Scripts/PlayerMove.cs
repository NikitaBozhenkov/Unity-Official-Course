using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float HorizontalInput { get; set; }

    private Rigidbody _rb;
    private Animator _animator;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        HorizontalInput = Input.GetAxis("Horizontal");
        _rb.AddForce(Vector3.right * (speed * HorizontalInput), ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space)) {
            _animator.SetBool("Jump_b", true);
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            _animator.SetBool("Jump_b", false);
        }
    }
}