using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Animation;
using LD.UI;
using LD.General;

public class EnemyAI : MonoBehaviour {

    CreateGameBoardFunctiom gameBoard;
    ReaperAnimationHelper animHelper;
    GameObject player;
    HealthCounter_Behaviour hpBeh;
    CameraShake camShake;

    public Vector2 position;
    Vector2 playerPosition;

    bool xvalue = false;
    bool yvalue = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        gameBoard = new CreateGameBoardFunctiom();
        transform.position = gameBoard.boxPositions[(int)position.x, (int)position.y];
        animHelper = GetComponent<ReaperAnimationHelper>();
        hpBeh = GameObject.FindWithTag("HealthCounter").GetComponent<HealthCounter_Behaviour>();
        camShake = GameObject.FindWithTag("CameraShake").GetComponent<CameraShake>();
    }
	
	// Update is called once per frame
	void Update () {

        playerPosition = player.GetComponent<PlayerInfo>().position;
        if (player.GetComponent<PlayerInfo>().action)
        {
            if (AttackCheck())
            {
                animHelper.AttackPosition(gameBoard.boxPositions[(int)playerPosition.x, (int)playerPosition.y]);
                player.GetComponent<PlayerInfo>().health -= 1;
                hpBeh.SetHealth(player.GetComponent<PlayerInfo>().health);
                camShake.Shake(1);
            }
            else
            {
                EnemyMovement();
                animHelper.MoveTo(new Vector3(gameBoard.boxPositions[(int)position.x, (int)position.y].x, transform.position.y, gameBoard.boxPositions[(int)position.x, (int)position.y].z));
            }
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

    bool AttackCheck()
    {
        if(Mathf.Abs(playerPosition.x - position.x) == 1 && playerPosition.y == position.y)
        {
            return true;
        }
        else if(Mathf.Abs(playerPosition.y - position.y) == 1 && playerPosition.x == position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
