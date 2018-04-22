using UnityEngine;

namespace LD.Audio
{

    [RequireComponent(typeof(AudioSource))]
    public class GameEnvironmentAudioBehaviour : MonoBehaviour
    {

        #region Private Variables
        [SerializeField]
        private AudioClip m_woosh;

        [SerializeField]
        private AudioClip m_boing;

        private AudioSource m_source;
        #endregion

        #region Main Methods
        void Start()
        {
            m_source = GetComponent<AudioSource>();
        }

        public void Boing()
        {
            m_source.clip = m_boing;
            m_source.Play();
        }

        public void Woosh()
        {
            m_source.clip = m_woosh;
            m_source.Play();
        }
        #endregion
    }
}
