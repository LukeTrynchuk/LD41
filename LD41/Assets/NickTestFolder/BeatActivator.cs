using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivator : MonoBehaviour {

    bool active = false;
    GameObject beat;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && active)
        {
            Destroy(beat);
        }
        else if (Input.anyKeyDown)
        {

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
