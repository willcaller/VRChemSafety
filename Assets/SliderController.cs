using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider; // Reference to the slider
    private float progress = 0f; // Progress of the idle state
    public float idleTime = 5f; // Idle time from WaypointMovement script
    public Transform npcTransform; // Transform of the NPC
    public Vector3 offset = new Vector3(0, 2, 0); // Offset to position the slider above the NPC's head
    public Camera playerCamera; // Reference to the player camera

    void Start()
    {
        // Adjust the scale and position of the Canvas
        slider.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        SetPosition();
    }
    void Update()
    {
        FaceCamera(); // Make the slider face the camera
    }
    // This function will be called when the NPC is idle
    public void UpdateProgress()
    {
        slider.gameObject.SetActive(true); // Show the slider
        SetPosition(); // Set the position of the slider
        if (progress < idleTime)
        {
            progress += Time.deltaTime; // Increment progress
            slider.value = progress / idleTime; // Update progress based on elapsed time
        }
    }

    // Call this function to reset the progress bar
    public void ResetProgress()
    {
        progress = 0f; // Reset the progress
        slider.value = 0f; // Reset the progress bar
        slider.gameObject.SetActive(false); // Hide the slider
    }

    // Call this function to set the position of the slider
    public void SetPosition()
    {
        slider.transform.position = npcTransform.position + offset;
    }

    // Call this function to make the slider always face the camera
    public void FaceCamera()
    {
        slider.transform.LookAt(slider.transform.position + playerCamera.transform.rotation * Vector3.forward,
            playerCamera.transform.rotation * Vector3.up);
    }
}