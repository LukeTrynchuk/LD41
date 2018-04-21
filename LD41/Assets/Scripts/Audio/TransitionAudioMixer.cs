using UnityEngine;
using UnityEngine.Audio;

namespace LD.Audio
{
    public class TransitionAudioMixer : MonoBehaviour
    {
        #region Public Variables
        public AudioMixerSnapshot m_TransitionToGroup;
        #endregion

        #region Private Variables
        private float m_timeToTransition = 1.0f;
        #endregion

        #region Main Methods
        public void Transition()
        {
            if(m_TransitionToGroup == null)
            {
                Debug.LogError("Cannot transition to a null audio snapshot");
                return;
            }

            m_TransitionToGroup.TransitionTo(m_timeToTransition);
        }

        public void SetTransitionTime(float time)
        {
            if (time < 0.0f)
                return;

            m_timeToTransition = time;
        }
        #endregion

    }
}
