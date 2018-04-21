using UnityEngine;

namespace LD.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class LogoBehaviour : MonoBehaviour
    {

        #region Private Variables
        [SerializeField]
        private AudioClip m_bounceSFX;

        private AudioSource m_source;
		#endregion

		#region Main Methods
		private void Start()
		{
            m_source = GetComponent<AudioSource>();
		}

		public void PlayBounce()
        {
            m_source.clip = m_bounceSFX;
            m_source.Play();
        }
        #endregion
    }
}
