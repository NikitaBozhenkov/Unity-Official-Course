using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _horsePower = 20.0f;
    [SerializeField] private float _turnSpeed = 45.0f;
    [SerializeField] private List<WheelCollider> wheels;
    private float _horizontalInput;
    private float _forwardInput;
    private float _speed;
    private float _rpm;

    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI rpmText;

    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame  
    void FixedUpdate() {
        if (!IsGrounded()) return;
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        
        _speed = Mathf.RoundToInt(_rb.velocity.magnitude * 3.6f);
        _rpm = Mathf.RoundToInt((_speed % 30) * 40);
        speedText.SetText("Speed: " + _speed + "km/h");
        rpmText.SetText("RPM: " + _rpm);

        _rb.AddRelativeForce(Vector3.forward * (_forwardInput * _horsePower));
        transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
    }

    private bool IsGrounded() {
        foreach (var wheel in wheels) {
            if (!wheel.isGrounded) return false;
        }

        return true;
    }
}