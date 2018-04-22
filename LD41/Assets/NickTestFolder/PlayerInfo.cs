using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Core.Services;
using LD.UserInput;
using LD.Animation;
using LD.UI;

public class PlayerInfo : MonoBehaviour {

    private ServiceReference<IInputService> m_inputService = new ServiceReference<IInputService>();
    FoxAnimationHelper animHelper;
    CreateGameBoardFunctiom gameBoard;
    public GameObject fireBall;

    public bool action;
    public Vector2 position;
    Vector2 input;
    Vector2 previousPosition;
    public int rythmCount = 0;
    public int health = 3;
    bool active;
    bool fire;

	// Use this for initialization
	void Start () {

        gameBoard = new CreateGameBoardFunctiom();
        transform.position = gameBoard.boxPositions[(int)position.x, (int)position.y];
        previousPosition = position;
        animHelper = GetComponent<FoxAnimationHelper>();
        
        animHelper.OnArrivedToDestination += ReachDestination;
        active = true;
        fire = false;
	}
	
	// Update is called once per frame
	void Update () {

        action = false;
       
        if(!m_inputService.isRegistered())
        {
            Debug.Log("Not Registered");
            return;
        }
        if(active)
        {
            GetInput();
            if(fire && rythmCount >=3)
            {
                ShootFire();
            }
           
        }

        if(previousPosition == position)
        {
            action = false;
        }
        else
        {
            previousPosition = position;
            action = true;
            animHelper.MoveTo(new Vector3(gameBoard.boxPositions[(int)position.x, (int)position.y].x, transform.position.y, gameBoard.boxPositions[(int)position.x, (int)position.y].z));
        }
        
	}

    private void OnDisable()
    {
        animHelper.OnArrivedToDestination -= ReachDestination;
    }

    void GetInput()
    {

        input = m_inputService.Reference.GetMovementVector();
        fire = m_inputService.Reference.PressedSelect();

        if (input.x > .4)
        {
            position.y++;
        }
        if (input.x < -.4)
        {
            position.y--;
        }
        if (input.y > .4)
        {
            position.x++;
        }
        if (input.y < -.4)
        {
            position.x--;
        }
        BoundCheck();
    }
    void BoundCheck()
    {
        if(position.x>4)
        {
            position.x = 4;
        }
        if (position.x < 0)
        {
            position.x = 0;
        }
        if (position.y > 4)
        {
            position.y = 4;
        }
        if (position.y < 0)
        {
            position.y = 0;
        }
    }
    void ReachDestination()
    {
        active = true;
    }
    void ShootFire()
    {
        GameObject ball = Instantiate(fireBall, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody>().velocity = transform.forward * 5;
    }
}
