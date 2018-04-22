using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Animation;

public class TestAnimatorController : MonoBehaviour 
{

    public ReaperAnimationHelper m_reaper;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
        {
            m_reaper.MoveTo(new Vector3(0, 0, -1));
        }
	}
}
