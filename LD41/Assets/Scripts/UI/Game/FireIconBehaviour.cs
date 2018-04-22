using UnityEngine;
using UnityEngine.UI;

namespace LD.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class FireIconBehaviour : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private RectTransform m_fireIconTransform;

        [SerializeField]
        private int m_maxCharge;

        [SerializeField]
        private float m_timeToUpdate;

        [SerializeField]
        private AudioClip m_audioClip;

        private int m_curCharge = 0;
        private AudioSource m_source;
        #endregion

        #region Main Methods
        public void IncrementCharge()
        {
            m_curCharge = Mathf.Min(m_curCharge + 1, m_maxCharge);

            if(m_curCharge == m_maxCharge)
            {
                m_source.clip = m_audioClip;
                m_source.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
                m_source.Play();
            }
        }

        public void ResetCharge()
        {
            m_curCharge = 0;
        }

		private void Start()
		{
            m_source = GetComponent<AudioSource>();
		}

		private void Update()
		{
            float percentage = (float)m_curCharge / (float)m_maxCharge;

            Vector3 scale = m_fireIconTransform.localScale;
            float newAmount = Mathf.Lerp(scale.x, percentage, m_timeToUpdate * Time.deltaTime);
            scale.x = newAmount;
            scale.y = newAmount;
            scale.z = newAmount;

            m_fireIconTransform.localScale = scale;
		}
		#endregion
	}
}
