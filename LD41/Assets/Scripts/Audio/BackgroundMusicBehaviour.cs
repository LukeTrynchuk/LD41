using UnityEngine;

namespace LD.Audio
{
    /// <summary>
    /// This component will act as a background music player. Given an array
    /// of music clips, choose one to play and loop.
    /// </summary>

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(TransitionAudioMixer))]
    public class BackgroundMusicBehaviour : MonoBehaviour
    {

        #region Private Variables
        [SerializeField]
        private AudioClip[] m_musicClips;

        private AudioSource m_source;
        private TransitionAudioMixer m_transitionAudio;
        #endregion

        #region Main Methods
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
