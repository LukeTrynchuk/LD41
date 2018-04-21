using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LD.Core.Services;

namespace LD.UserInput
{
	public class StandaloneControllerInputService : MonoBehaviour , IInputService
	{

		#region Private Variables
		private const string SELECT_BUTTON = "Select";
		private const string CANCEL_BUTTON = "Cancel";
		private const string MENU_BUTTON = "Menu";

		private const string LEFT_STICK_HOR = "LeftStickHorizontal";
		private const string LEFT_STICK_VER = "LeftStickVertical";

		private int m_numberOfJoySticks;
		#endregion

		#region Main Methods
		void Awake()
		{
			m_numberOfJoySticks = GetNumberOfJoySticks ();
			if (m_numberOfJoySticks >= 1)
				RegisterService ();
		}

		void Update()
		{
			if (m_numberOfJoySticks == 0 && GetNumberOfJoySticks () >= 1) 
			{
				RegisterService ();
			}

			m_numberOfJoySticks = GetNumberOfJoySticks ();
		}

		public Vector2 GetMovementVector()
		{
			float xaxis = Input.GetAxis (LEFT_STICK_HOR);
			float yaxis = Input.GetAxis (LEFT_STICK_VER);

			return new Vector2 (xaxis, yaxis);
		}

		public bool PressedSelect()
		{
			return ButtonPressed (SELECT_BUTTON);
		}

		public bool PressedCancel()
		{
			return ButtonPressed (CANCEL_BUTTON);
		}

		public bool PressedMenu()
		{
			return ButtonPressed (MENU_BUTTON);
		}

		public void RegisterService()
		{
			#if UNITY_STANDALONE
				ServiceLocator.Register<IInputService>(this);
			#else
				gameObject.SetActive (false);
			#endif
		}
		#endregion

		#region Utility Methods

		private bool ButtonPressed(string ButtonName)
		{
			string osName;
			#if UNITY_STANDALONE_OSX
			osName = "_OSX";
			#elif UNITY_STANDALONE_WIN
			osName = "_WIN";
			#elif UNITY_STANDALONE_LINUX
			osName = "_LIN";
			#endif

			if (Input.GetButtonDown (ButtonName + osName))
				return true;

			return false;
		}
		#endregion

		#region Low Level Functions
		private int GetNumberOfJoySticks()
		{
			return Input.GetJoystickNames ().Length;
		}
		#endregion
	}
}
