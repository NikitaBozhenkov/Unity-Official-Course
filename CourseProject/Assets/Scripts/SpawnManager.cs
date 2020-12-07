using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private GameObject powerupPrefab;

    [SerializeField] private float zSpawn;
    [SerializeField] private float ySpawn;
    
    [SerializeField] private float xSpawnRange;

    [SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float enemySpawnDelay = 1.5f;
    [SerializeField] private float obstacleSpawnDelay = 2f;
    [SerializeField] private float powerupSpawnDelay = 6f;
    
    private GameplayController _gameplayController;
    
    
    // Start is called before the first frame update
    void Start() {
        _gameplayController = GameObject.Find("Gameplay Controller").GetComponent<GameplayController>();
        InvokeRepeating(nameof(SpawnEnemy), spawnDelay, enemySpawnDelay);
        InvokeRepeating(nameof(SpawnObstacle), spawnDelay, obstacleSpawnDelay);
        InvokeRepeating(nameof(SpawnPowerup), spawnDelay, powerupSpawnDelay);
    }

    void SpawnEnemy() {
        if(_gameplayController.IsGameOver) return;
        
        var go = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        var spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, zSpawn);

        Instantiate(go, spawnPos, go.transform.rotation);
    }
    
    void SpawnObstacle() {
        if(_gameplayController.IsGameOver) return;
        
        var go = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        var spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, zSpawn);

        Instantiate(go, spawnPos, go.transform.rotation);
    }
    
    void SpawnPowerup() {
        if(_gameplayController.IsGameOver) return;
        
        var spawnPos = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, zSpawn);
        
        Instantiate(powerupPrefab, spawnPos, powerupPrefab.transform.rotation);
    }

}