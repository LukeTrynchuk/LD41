using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD.SceneManagement
{
    public class TransitionToGameScene : MonoBehaviour
    {
		#region Main Methods
		private void LateUpdate()
		{
            SceneManager.LoadScene(1);
		}
		#endregion
	}
}
