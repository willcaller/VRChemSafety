using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DigitalClock : MonoBehaviour
{
    // datetimenow is a static property that returns the current date and time
    public static DateTime Now { get; }

    // A reference to the clock's TextMeshProUGUI component
    public TextMeshProUGUI clockText;

    // A boolean to toggle between local time and VR time
    public bool useLocalTime = true;

    // A variable to store the VR time
    public DateTime vrTime;

    // A variable to store the time difference between local time and VR time
    private TimeSpan timeOffset;

    // A method to initialize the clock
    private void Start()
    {
        // If using local time, set the VR time to the system's current time
        if (useLocalTime)
        {
            vrTime = DateTime.Now;
        }
        // Otherwise, calculate the time difference between local time and VR time
        else
        {
            timeOffset = DateTime.Now - vrTime;
        }
    }

    // A method to update the clock every frame
    private void Update()
    {
        // If using local time, get the system's current time
        if (useLocalTime)
        {
            vrTime = DateTime.Now;
        }
        // Otherwise, add the time difference to the system's current time
        else
        {
            vrTime = DateTime.Now - timeOffset;
        }

        // Format the VR time as a string with leading zeros
        string timeString = vrTime.ToString("HH:mm:ss");

        // Assign the time string to the text component
        clockText.text = timeString;
    }
}