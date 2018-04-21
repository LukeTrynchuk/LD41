using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameBoardFunctiom{

    public Vector3[,] boxPositions;

	// Use this for initialization
	public CreateGameBoardFunctiom () {
        boxPositions = new Vector3[5,5];

        for(int x = 0; x<5;x++)
        {
            for(int y = 0; y<5;y++)
            {
                boxPositions[x,y] = new Vector3(-2 + x, 0, 2 - y);
            }
        }
        SpawnGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnGrid()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = boxPositions[x, y];
            }
        }
    }
}
