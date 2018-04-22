using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Core.Services;
using LD.UserInput;

public class PlayerInfo : MonoBehaviour {

    private ServiceReference<IInputService> m_inputService = new ServiceReference<IInputService>();


    CreateGameBoardFunctiom gameBoard;
    public bool moved;
    public Vector2 position;
    Vector2 input;
    Vector2 previousPosition;
	// Use this for initialization
	void Start () {

        gameBoard = new CreateGameBoardFunctiom();
        transform.position = gameBoard.boxPositions[(int)position.x, (int)position.y];
        previousPosition = position;
	}
	
	// Update is called once per frame
	void Update () {
        moved = true;
        if(!m_inputService.isRegistered())
        {
            Debug.Log("Not Registered");
            return;
        }

        GetInput();
        if(previousPosition == position)
        {
            moved = false;
        }
        else
        {
            previousPosition = position;
        }
        transform.position = gameBoard.boxPositions[(int)position.x,(int)position.y];
	}
    void GetInput()
    {

        input = m_inputService.Reference.GetMovementVector();

        if (input.x > .4)
        {
            position.x--;
        }
        if (input.x < -.4)
        {
            position.x++;
        }
        if (input.y > .4)
        {
            position.y++;
        }
        if (input.y < -.4)
        {
            position.y--;
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
}
