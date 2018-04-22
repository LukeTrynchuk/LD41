using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.UI;

public class Fireball : MonoBehaviour {

    float lifeTimer = 3;
    KillCounter_Behaviour killCounter;
    GameObject environment;
	// Use this for initialization
	void Start () {
        killCounter = GameObject.FindWithTag("KillCounter").GetComponent<KillCounter_Behaviour>();
        environment = GameObject.FindWithTag("Environment");
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
            GameObject enemyObj = Instantiate(other.gameObject, new Vector3(10, 10, 10), Quaternion.identity);
            enemyObj.transform.parent = environment.transform;
            enemyObj.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemyObj.GetComponent<EnemyAI>().position = new Vector2((int)Random.Range(0, 5), (int)Random.Range(0, 5));
            Destroy(other.gameObject);
        }
    }
}
