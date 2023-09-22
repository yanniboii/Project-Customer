using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootstepSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isMoving;
    private bool isJumping;
    public AudioClip[] sounds;
    [Range(0.1f,0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        audioSource.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
                
        
        if (GetComponent<Rigidbody>().velocity.magnitude > 0) isMoving = true;
        else isMoving = false;

        if (GetComponent <PlayerMovement>().grounded) isJumping = false;
        else isJumping = true;


        if (isMoving && !audioSource.isPlaying && !isJumping) audioSource.PlayOneShot(audioSource.clip); // if player is moving, not jumping and audiosource is not playing play it
        if (!isMoving || isJumping) audioSource.Stop(); // if player is not moving or is jumping and audiosource is playing stop it
    }
}
