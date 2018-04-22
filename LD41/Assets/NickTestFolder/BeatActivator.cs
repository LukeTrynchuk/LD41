using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.UI;

public class BeatActivator : MonoBehaviour {
    [SerializeField]
    bool active = false;
    GameObject beat;
    GameObject player;
    FireIconBehaviour iconBeh;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        iconBeh = GetComponent<FireIconBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown && active)
        {
            Destroy(beat);
            player.GetComponent<PlayerInfo>().rythmCount += 1;
            iconBeh.IncrementCharge();
        }
        else if (Input.anyKeyDown)
        {
            player.GetComponent<PlayerInfo>().rythmCount = 0;
            iconBeh.ResetCharge();
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
