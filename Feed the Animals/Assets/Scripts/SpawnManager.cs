using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject[] animalPrefabs;
    private float _spawnRangeX = 20f;
    private float _spawnPosZ = 20f;
    private float _startDelay = 2;
    private float _spawnInterval = 1.5f;
    
    void Start() {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _spawnInterval);
    }

    void SpawnRandomAnimal() {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}