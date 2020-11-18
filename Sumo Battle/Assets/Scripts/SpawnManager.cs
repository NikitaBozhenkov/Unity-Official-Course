using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyPrefab;
    private float _spawnRange;

    // Start is called before the first frame update
    void Start() {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-9, 9);
        
        var randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update() {
    }
}