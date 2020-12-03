using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public GameObject player;
    [SerializeField] private Vector3 _offset = new Vector3(0, 4, -7);

    // Update is called once per frame
    void LateUpdate() {
        transform.position = player.transform.position + _offset;
    }
}