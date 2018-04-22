using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPreviousScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Return()
    {
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        index--;
        SceneManager.LoadScene(index);
    }
}
