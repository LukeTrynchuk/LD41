using UnityEngine;

namespace LD.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class UISFXController : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private AudioClip m_buttonClickAudioClip;

        private AudioSource m_source;
		#endregion

		#region Main Methods
		private void Start()
		{
            m_source = GetComponent<AudioSource>();
		}

		public void ButtonClicked()
        {
            m_source.clip = m_buttonClickAudioClip;
            m_source.pitch = Random.Range(0.9f, 1.1f);
            m_source.Play();
        }
        #endregion
    }
}
