using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD.Effects
{
    [RequireComponent(typeof(AudioSource))]
    public class EnemyDieEffectBehaviour : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private AudioClip[] m_deathSFX;

        private AudioSource m_source;
        #endregion

        #region Main Methods
        void Start()
        {
            m_source = GetComponent<AudioSource>();
            m_source.clip = GetClip();
            m_source.pitch = Random.Range(0.9f, 1.1f);
            m_source.Play();

            StartCoroutine(Die());
        }
        #endregion

        #region Utility Methods
        private AudioClip GetClip()
        {
            int index = Random.Range(0, m_deathSFX.Length - 1);
            return m_deathSFX[index];
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(5f);
            Destroy(this.gameObject);
        }
        #endregion
    }
}
