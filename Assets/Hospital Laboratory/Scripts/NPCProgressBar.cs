using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//work in progress
using UnityEngine.UI;
//I GOTTA LOOK AT HOW THEY ANIMATING THE CHARACTER AND CALL THAT IN THIS FILLER GPT CODE

public class NPCProgressBar : MonoBehaviour
{
    public GameObject progressBarPrefab; // Assign your progress bar prefab in the inspector
    private GameObject progressBar;
    private Slider progressBarSlider;
/*
    // Subscribe to the appropriate events to enable/disable the progress bar
    void OnEnable()
    {
        // Assuming the NPC has an event that triggers when entering the idle state
        NPCIdleState.OnEnterIdle += ShowProgressBar;
        // Assuming the NPC has an event that triggers when exiting the idle state
        NPCIdleState.OnExitIdle += HideProgressBar;
    }

    void OnDisable()
    {
        NPCIdleState.OnEnterIdle -= ShowProgressBar;
        NPCIdleState.OnExitIdle -= HideProgressBar;
    }
*/
    void ShowProgressBar()
    {
        if (progressBar == null)
        {
            progressBar = Instantiate(progressBarPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            progressBar.transform.SetParent(this.transform, false);
            progressBarSlider = progressBar.GetComponent<Slider>();
        }
        progressBar.SetActive(true);
        // Start your coroutine or method to update the progress bar here
    }

    void HideProgressBar()
    {
        if (progressBar != null)
        {
            progressBar.SetActive(false);
        }
        // Stop your coroutine or method to update the progress bar here
    }

    // Update the progress bar value here
    void UpdateProgressBar(float value)
    {
        if (progressBarSlider != null)
        {
            progressBarSlider.value = value;
        }
    }
}
