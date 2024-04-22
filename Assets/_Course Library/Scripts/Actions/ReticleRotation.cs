using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleRotation : MonoBehaviour
{
    // The speed of the rotation in degrees per second
    public float rotationSpeed = 180f;

    // The scale factor for the size change
    public float scaleFactor = 0.1f;

    // The frequency of the size change in cycles per second
    public float frequency = 2f;

    // The initial scale of the reticle
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        // Store the initial scale of the reticle
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the reticle around the X axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Change the scale of the reticle based on a sine wave
        float scale = 1f + scaleFactor * Mathf.Sin(2f * Mathf.PI * frequency * Time.time);
        transform.localScale = initialScale * scale;
    }
}