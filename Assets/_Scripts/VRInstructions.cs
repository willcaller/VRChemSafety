using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VRInstructions : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public string[] messages;
    private int currentIndex = 0;

    public void NextMessage()
    {
        if (currentIndex < messages.Length)
        {
            instructionText.text = messages[currentIndex];
            currentIndex++;
        }
        else
        {
            // Handle completion (e.g., hide the UI or trigger an event)
            Debug.Log("All messages displayed!");
        }
    }
}