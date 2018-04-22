using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.UI;

public class GarbageCollector : MonoBehaviour {

    GameObject player;
    public FireIconBehaviour iconBeh;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        player.GetComponent<PlayerInfo>().rythmCount = 0;
        iconBeh.ResetCharge();
        Destroy(coll.transform.gameObject);
    }
}
