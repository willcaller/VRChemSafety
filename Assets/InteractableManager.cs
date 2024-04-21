using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class InteractableManager : MonoBehaviour
{

    //Each list of items corresponds to a different type of violation.
    [SerializeField]
    public List<GameObject> glassContainer;



    // Start is called before the first frame update
    void Start()
    {
        bool glassContainerActive = true;
        /*
         * Once there are more categories of violations implemented, 
         * there should be a function here which determines which violations are
         * active within the scene randomly
         */


        //Big ol' string of disconnected if statements only activating the selected violations (only one right now though since we only have one violation type and it's on by default)
        if(glassContainerActive)
        {
            //50/50 shot violating the object
            float frequency = 0.5f;
            for (int i = 0; i < glassContainer.Count; i++)
            {
                //UnityEngine.Debug.Log("IS THIS THING ON????");
                if (Random.value < frequency)
                {
                    //For each glass, if it failed the coinflip, break it (turn it pink magenta) as punishment 
                    GlassContainerBreak(glassContainer[i]);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GlassContainerBreak(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        //UnityEngine.Debug.Log("In function");
        if (objRenderer != null)
        {
            //UnityEngine.Debug.Log("Made it pink");
            objRenderer.material.color = Color.magenta;
        }
        return;
    }



}
