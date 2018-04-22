using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.General;

public class TestCameraShake : MonoBehaviour {

    [SerializeField]
    CameraShake m_shake;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
            m_shake.Shake(1f);

	}
}
