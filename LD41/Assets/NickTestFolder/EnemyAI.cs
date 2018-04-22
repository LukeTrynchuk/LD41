using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    CreateGameBoardFunctiom gameBoard;

    public Vector2 position;
    Vector2 playerPosition;
    GameObject player;

    bool xvalue = false;
    bool yvalue = false;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        gameBoard = new CreateGameBoardFunctiom();
        transform.position = gameBoard.boxPositions[(int)position.x, (int)position.y];
    }
	
	// Update is called once per frame
	void Update () {

        playerPosition = player.GetComponent<PlayerInfo>().position;
        if (player.GetComponent<PlayerInfo>().moved)
        {
            EnemyMovement();
            transform.position = new Vector3(gameBoard.boxPositions[(int)position.x, (int)position.y].x, transform.position.y, gameBoard.boxPositions[(int)position.x, (int)position.y].z);
        }

	}

    void EnemyMovement()
    {
        if(playerPosition.x == position.x)
        {
            yvalue = true;
        }
        else if(playerPosition.y == position.y)
        {
            xvalue = true;
        }
        else
        {
            int random = (int)Random.Range(0, 2);
            if(random == 0)
            {
                yvalue = true;
            }
            else
            {
                xvalue = true;
            }
        }

        if(xvalue)
        {
            position.x += Mathf.Clamp((int)(playerPosition.x - position.x),-1,1);
        }

        if (yvalue)
        {
            position.y += Mathf.Clamp((int)(playerPosition.y - position.y), -1, 1);
        }
        xvalue = false;
        yvalue = false;
    }
}
