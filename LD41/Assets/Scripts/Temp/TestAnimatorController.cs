﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Animation;

public class TestAnimatorController : MonoBehaviour 
{

    public FoxAnimationHelper m_reaper;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
        {
            m_reaper.SetToDead();
            //m_reaper.MoveTo(this.transform.position);
            //m_reaper.AttackPosition(this.transform.position);
        }
	}
}
