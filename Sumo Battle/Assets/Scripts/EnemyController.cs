using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private float _speed = 3f;
    private Rigidbody _rb;
    private GameObject _player;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }

        var lookDirection = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(lookDirection * _speed);
    }
}