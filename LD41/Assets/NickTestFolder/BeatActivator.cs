using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivator : MonoBehaviour {

    bool active = false;
    GameObject beat;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && active)
        {
            Destroy(beat);
            player.GetComponent<PlayerInfo>().rythmCount += 1;
        }
        else if (Input.anyKeyDown)
        {
            player.GetComponent<PlayerInfo>().rythmCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        active = true;
        if (other.gameObject.tag == "Beat")
        {
            beat = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        active = false;
    }
}
