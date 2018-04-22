using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.UI;

public class TempFireIconConrtoller : MonoBehaviour {

    public FireIconBehaviour iconBehaviour;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
            iconBehaviour.ResetCharge();

        if (Input.GetKeyDown(KeyCode.P))
            iconBehaviour.IncrementCharge();
	}
}
