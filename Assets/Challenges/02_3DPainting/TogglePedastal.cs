using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePedastal : MonoBehaviour
{
    // The toggle component that controls the state
    public Toggle toggle;

    // The pedestal object that is shown or hidden
    public GameObject pedestal;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the toggle component
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    // This method is called when the toggle value changes
    void OnToggleChanged(bool value)
    {
        // Set the active state of the pedestal to the toggle value
        pedestal.SetActive(value);
    }
}
