using UnityEngine;
using LD.Core.Services;

namespace LD.UserInput
{
	public class StandalineKeyboardInputService : MonoBehaviour , IInputService
	{
        #region Private Variables
        [SerializeField]
        private KeyCode m_LeftButton;
        [SerializeField]
        private KeyCode m_RightButton;
        [SerializeField]
        private KeyCode m_UpButton;
        [SerializeField]
        private KeyCode m_DownButton;

        [SerializeField]
        private KeyCode m_SelectButton;
        [SerializeField]
        private KeyCode m_MenuButton;
        [SerializeField]
        private KeyCode m_CancelButton;

		private int m_numberOfJoysticks;
		#endregion

		#region Main Methods
		void Awake()
		{
			SetNumberOfJoySticks ();
			if (m_numberOfJoysticks == 0)
				RegisterService ();
		}

		void Update()
		{

			#if UNITY_STANDALONE
			if (Input.GetJoystickNames ().Length == 0 && m_numberOfJoysticks > 0) 
			{
				RegisterService ();
			}

			SetNumberOfJoySticks ();
			#endif
		}

		public Vector2 GetMovementVector()
		{
            /*
			bool left = Input.GetKeyDown (KeyCode.LeftArrow);
			bool right = Input.GetKeyDown (KeyCode.RightArrow);
			bool up = Input.GetKeyDown (KeyCode.UpArrow);
			bool down = Input.GetKeyDown (KeyCode.DownArrow);
            Vector2 deltaMovement = new Vector2 ();
            */

            bool left = Input.GetKeyDown(m_LeftButton);
            bool right = Input.GetKeyDown(m_RightButton);
            bool up = Input.GetKeyDown(m_UpButton);
            bool down = Input.GetKeyDown(m_DownButton);

            Vector2 deltaMovement = new Vector2();

			if (left ^ right) 
			{
				if (left)
					deltaMovement.x = -1;
				if (right)
					deltaMovement.x = 1;
			}

			if (up ^ down) 
			{
				if (up)
					deltaMovement.y = 1;
				if (down)
					deltaMovement.y = -1;
			}

			return deltaMovement;
		}

		public bool PressedSelect()
		{
			if (Input.GetKeyDown (m_SelectButton))
				return true;
			return false;
		}

		public bool PressedCancel()
		{
			if (Input.GetKeyDown (m_CancelButton))
				return true;
			return false;
		}

		public bool PressedMenu()
		{
			if (Input.GetKeyDown (m_MenuButton))
				return true;
			return false;
		}

		public void RegisterService()
		{
			#if UNITY_STANDALONE
				ServiceLocator.Register<IInputService>(this);
			#elif
				gameObject.SetActive(false);
			#endif
		}
		#endregion

		#region Low Level Functions

		private void SetNumberOfJoySticks()
		{
			m_numberOfJoysticks = Input.GetJoystickNames ().Length;
		}

		#endregion
	}
}
