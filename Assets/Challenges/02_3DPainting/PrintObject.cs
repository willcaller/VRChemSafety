using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintObject : MonoBehaviour
{
    // The button component that triggers the action
    public Button button;

    // The 3d object that is copied and scaled down
    public GameObject objectToPrint;

    // The table object that holds the miniature version
    public GameObject table;

    // The scale factor for the miniature version
    public float scaleFactor = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the button component
        button.onClick.AddListener(OnButtonClick);
    }

    // This method is called when the button is clicked
    void OnButtonClick()
    {
        // Instantiate a copy of the 3d object
        GameObject copy = Instantiate(objectToPrint);

        // Scale down the copy by the factor
        copy.transform.localScale *= scaleFactor;

        // Position the copy on the table
        copy.transform.position = table.transform.position + new Vector3(0, 0.5f, 0);

        // Rotate the copy to match the original
        copy.transform.rotation = objectToPrint.transform.rotation;
    }
}