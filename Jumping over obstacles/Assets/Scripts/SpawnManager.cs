using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject obstaclePrefab;
    private Vector3 _spawnPosition = new Vector3(25, 0, 0);
    private float _startDelay = 2f;
    private float _repeatRate = 2f;
    
    // Start is called before the first frame update
    void Start() {
     InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    // Update is called once per frame
    void Update() {
    }

    private void SpawnObstacle() {
        Instantiate(obstaclePrefab, _spawnPosition, obstaclePrefab.transform.rotation);
    }
}