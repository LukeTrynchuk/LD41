using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

namespace LD.General
{
    public class CameraShake : MonoBehaviour
    {

        #region Private Variables
        private CameraShaker m_shaker;
        #endregion

        #region Main Methods
        void Start()
        {
            m_shaker = GetComponent<CameraShaker>();
            if (m_shaker == null)
            {
                m_shaker = gameObject.AddComponent<CameraShaker>();
            }
        }

        public void Shake(float intensity)
        {
            CameraShaker.Instance.ShakeOnce(4f * intensity, intensity, 0.2f, 0.3f);
        }
        #endregion
    }
}
