using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class SoundOnImpact : MonoBehaviour
{
    public AudioClip impactSound; // The sound to play on impact
    public float volumeScale = 1f; // The scale factor for the volume

    private AudioSource audioSource;
    private Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Calculate the volume based on the speed of the object
        float volume = rb.velocity.magnitude * volumeScale;

        // Play the impact sound
        audioSource.PlayOneShot(impactSound, volume);
    }
}
