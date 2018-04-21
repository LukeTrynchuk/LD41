using UnityEngine;
using LD.General;
using UnityEngine.Audio;

namespace LD.Audio
{
    /// <summary>
    /// This component will act as a background music player. Given an array
    /// of music clips, choose one to play and loop.
    /// </summary>

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(TransitionAudioMixer))]
    public class BackgroundMusicBehaviour : MonoBehaviour, ITogglable
    {

        #region Private Variables
        [SerializeField]
        private AudioClip[] m_musicClips;

        [SerializeField]
        private AudioMixerSnapshot m_pauseSnapShot;

        [SerializeField]
        private AudioMixerSnapshot m_normalSnapShot;

        private bool m_paused = false;
        private AudioSource m_source;
        private TransitionAudioMixer m_transitionAudio;
        #endregion

        #region Main Methods
        public void Toggle()
        {
            if(!m_paused)
            {
				m_paused = !m_paused;
    
                m_transitionAudio.m_TransitionToGroup = m_pauseSnapShot;
                m_transitionAudio.SetTransitionTime(1f);
                m_transitionAudio.Transition();
                return;            
            }

            m_paused = !m_paused;

            m_transitionAudio.m_TransitionToGroup = m_normalSnapShot;
            m_transitionAudio.SetTransitionTime(1f);
            m_transitionAudio.Transition();

        }

        private void Start()
        {
            InitializeComponents();

            StartMusic();

            m_transitionAudio.SetTransitionTime(2f);
            m_transitionAudio.Transition();
        }
        #endregion

        #region Utility Methods

        private void StartMusic()
        {
            m_source.clip = GetAudioClipToPlay();

            if (m_source.clip == null)
            {
                Debug.LogError("Unable to play music from empty list.");
                return;
            }

            m_source.loop = true;
            m_source.Play();
        }

        private void InitializeComponents()
        {
            m_source = GetComponent<AudioSource>();
            m_transitionAudio = GetComponent<TransitionAudioMixer>();
        }

        private AudioClip GetAudioClipToPlay()
        {
            int index = UnityEngine.Random.Range(0, m_musicClips.Length - 1);
            return m_musicClips[index];
        }
        #endregion
    }
}
