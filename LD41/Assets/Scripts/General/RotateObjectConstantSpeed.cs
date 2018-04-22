using UnityEngine;

namespace LD.General
{
    public class RotateObjectConstantSpeed : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private float m_rotateSpeed;
        #endregion

        #region Main Methods
        void Update()
        {
            transform.rotation *= Quaternion.Euler(Vector3.up * m_rotateSpeed);
        }
        #endregion
    }
}
