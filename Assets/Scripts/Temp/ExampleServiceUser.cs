using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Core.Services;
using LD.UserInput;

public class ExampleServiceUser : MonoBehaviour 
{

    private ServiceReference<IInputService> m_inputService = new ServiceReference<IInputService>();

	void Start () 
    {
        m_inputService.AddRegistrationHandle(HandleInputServiceRegistered);
	}

    void Update()
    {
        if (!m_inputService.isRegistered())
            return;

        if(m_inputService.Reference.PressedCancel())
        {
            Debug.Log("CANCEL");
        }

        if(m_inputService.Reference.PressedMenu())
        {
            Debug.Log("MENU");
        }

        if(m_inputService.Reference.PressedSelect())
        {
            Debug.Log("SELECT");
        }
    }

    void HandleInputServiceRegistered()
    {
        Debug.Log("Input service registered.");
    }

}
