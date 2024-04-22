using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushSound : MonoBehaviour
{
    // The audio source component that plays the sound
    public AudioSource audioSource;

    // The camera object that represents the user's head
    public new GameObject camera;

    // The maximum distance for full volume
    public float maxDistance = 0.5f;

    // The minimum distance for zero volume
    public float minDistance = 2f;

    // The minimum and maximum volume values
    public float minVolume = 0.5f;
    public float maxVolume = 1f;

    // Update is called once per frame
    void Update()
    {
        // Get the distance between the pen and the camera
        float distance = Vector3.Distance(transform.position, camera.transform.position);

        // Clamp the distance between the min and max values
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Map the distance to a volume value between the min and max values
        float volume = Mathf.Lerp(maxVolume, minVolume, (distance - minDistance) / (maxDistance - minDistance));

        // Set the volume of the audio source
        audioSource.volume = volume;
    }
}
