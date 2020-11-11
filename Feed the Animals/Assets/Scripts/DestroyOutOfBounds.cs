using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour {
    private float _topBound = 30f;
    private float _lowerBound = -10f;
    
    void Update() {
        if (transform.position.z > _topBound) {
            Destroy(gameObject);
        } else if (transform.position.z < _lowerBound) {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}