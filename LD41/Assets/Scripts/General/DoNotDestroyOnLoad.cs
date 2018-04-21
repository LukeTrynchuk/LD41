using UnityEngine;

namespace LD.General
{
    public class DoNotDestroyOnLoad : MonoBehaviour
    {
		#region Main Methods
		private void Start()
		{
            DontDestroyOnLoad(this.gameObject);
		}
		#endregion
	}
}
