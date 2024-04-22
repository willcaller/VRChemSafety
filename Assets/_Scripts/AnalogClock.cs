using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalogClock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        float hours = time.Hour % 12;
        float minutes = time.Minute;
        float seconds = time.Second;

        hourHand.localRotation = Quaternion.Euler(hours * 30f, 0f, 0f);
        minuteHand.localRotation = Quaternion.Euler(minutes * 6f, 0f, 0f);
        secondHand.localRotation = Quaternion.Euler(seconds * 6f,0f, 0f);
    }
}
