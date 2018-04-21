using UnityEngine;
using LD.Core.Services;

namespace LD.UserInput
{
    public interface IInputService : IService 
	{
		Vector2 GetMovementVector();
		bool PressedSelect();
		bool PressedCancel();
		bool PressedMenu();
	}
}
