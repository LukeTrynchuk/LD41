using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.UI;

public class Fireball : MonoBehaviour {

    float lifeTimer = 3;
    KillCounter_Behaviour killCounter;
	// Use this for initialization
	void Start () {
        killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter_Behaviour>();
	}
	
	// Update is called once per frame
	void Update () {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer<=0)
        {
            Destroy(transform.gameObject);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            killCounter.Increment(1);
            Destroy(other.gameObject);
        }
    }
}
