using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

    GameObject player;
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
        Destroy(coll.transform.gameObject);
    }
}
