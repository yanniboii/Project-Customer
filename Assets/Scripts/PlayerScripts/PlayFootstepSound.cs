using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMoving;
    private bool isJumping;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 0) isMoving = true;
        else isMoving = false;

        if (GetComponent <PlayerMovement>().grounded) isJumping = false;
        else isJumping = true;


        if (isMoving && !audioSource.isPlaying && !isJumping) audioSource.Play(); // if player is moving, not jumping and audiosource is not playing play it
        if (!isMoving || isJumping) audioSource.Stop(); // if player is not moving or is jumping and audiosource is playing stop it
    }
}
