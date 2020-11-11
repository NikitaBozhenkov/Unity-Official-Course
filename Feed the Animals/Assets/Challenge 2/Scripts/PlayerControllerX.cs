using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public GameObject dogPrefab;
    private bool _canSpawn = true;

    private void UpdateSpawnAbility() {
        _canSpawn = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && _canSpawn) {
            _canSpawn = false;
            Invoke("UpdateSpawnAbility", 0.7f);
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}