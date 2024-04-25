using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] myObjects;
    // Update is called once per frame
    void Start()
    {
        
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPoint = new Vector3 (Random.Range(0, 3), 0, Random.Range(0,3));

            Instantiate(myObjects[randomIndex] ,randomSpawnPoint, Quaternion.identity);

        
    }
}
