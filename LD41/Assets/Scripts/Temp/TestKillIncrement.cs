using UnityEngine;
using LD.UI;

public class TestKillIncrement : MonoBehaviour 
{
    public HealthCounter_Behaviour m_kill;
	
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.P))
        {
            m_kill.SetHealth(2);
        }
	}
}
