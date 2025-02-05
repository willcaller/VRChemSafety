using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splashscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextScenes;
    public int waitingTime;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }


    private void Start()
    {
        StartCoroutine(PindahHalaman());
    }

    IEnumerator PindahHalaman()
    {
        yield return new WaitForSeconds(waitingTime);
        SceneManager.LoadScene(nextScenes);
    }
}
