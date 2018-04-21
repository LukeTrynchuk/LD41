using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour {

    public GameObject beat;
    public float setTimer;
    float countDownTimer;
	// Use this for initialization
	void Start () {
        countDownTimer = setTimer;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(countDownTimer<=0)
        {
            GameObject newBeat = Instantiate(beat, new Vector3(0,0,0), Quaternion.identity);
            newBeat.transform.SetParent(this.gameObject.transform);
            newBeat.transform.position = transform.position;
            countDownTimer = setTimer;
        }

        countDownTimer -= Time.deltaTime;
	}
}
