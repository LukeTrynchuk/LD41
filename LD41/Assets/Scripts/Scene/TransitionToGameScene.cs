using UnityEngine;
using UnityEngine.SceneManagement;
using LD.General;

namespace LD.SceneManagement
{
    [RequireComponent(typeof(AdvanceToNextScene))]
    public class TransitionToGameScene : MonoBehaviour
    {
		#region Main Methods
		private void LateUpdate()
		{
            AdvanceToNextScene advance = GetComponent<AdvanceToNextScene>();
            advance.Advance();
		}
		#endregion
	}
}
