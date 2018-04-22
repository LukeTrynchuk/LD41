using UnityEngine;
using UnityEngine.UI;

namespace LD.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    public class KillCounter_Behaviour : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private Text m_text;

        [SerializeField]
        private AudioClip m_killSound;

        private Animator m_animator;
        private AudioSource m_source;
        //private int m_kills = 0;
        private int m_actualAmount = 0;
        #endregion

        #region Main Methods
        public void Increment(int amount)
        {
            m_actualAmount += amount;
            m_animator.SetTrigger("Update");
        }

        public void UpdateVisual()
        {
            m_text.text = m_actualAmount.ToString();
            m_source.clip = m_killSound;
            m_source.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            m_source.Play();
        }

        void Start()
        {
            m_animator = GetComponent<Animator>();
            m_source = GetComponent<AudioSource>();
        }
        #endregion
    }
}
