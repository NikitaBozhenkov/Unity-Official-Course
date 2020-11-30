using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rb;
    private GameObject _focalPoint;
    private float powerupStrenght = 15f;
    
    public float speed = 5f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update() {
        var verticalInput = Input.GetAxis("Vertical");

        _rb.AddForce(_focalPoint.transform.forward * (speed * verticalInput));
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine("PowerCountdownRoutine");
            powerupIndicator.SetActive(true);
        }
    }

    IEnumerator PowerCountdownRoutine() {
        yield return new WaitForSeconds(7f);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup) {
            var enemyRb = other.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = other.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrenght, ForceMode.Impulse);
            Debug.Log("Collided with enemy and powerUp is " + hasPowerup);
        }
    }
}