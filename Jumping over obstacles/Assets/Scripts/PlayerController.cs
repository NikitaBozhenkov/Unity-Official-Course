using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody _rb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private AudioSource _audioSource;
    private Animator _animator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            _audioSource.PlayOneShot(jumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtParticle.Play();
        } else if (other.gameObject.CompareTag("Obstacle") && !gameOver) {
            gameOver = true;
            Debug.Log("Game Over!");
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _audioSource.PlayOneShot(crashSound, 1f);
        }
    }
}