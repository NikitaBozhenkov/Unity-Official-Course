using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rb;
    private GameObject _focalPoint;
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update() {
        var verticalInput = Input.GetAxis("Vertical");
        
        _rb.AddForce(_focalPoint.transform.forward * (speed * verticalInput));
    }
}