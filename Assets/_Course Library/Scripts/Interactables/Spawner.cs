using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] myObjects;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPoint = new Vector3 (Random.Range(-10, 11), 5, Random.Range(-10,11));

            Instantiate(myObjects[randomIndex] ,randomSpawnPoint, Quaternion.identity);

        }
    }
}
