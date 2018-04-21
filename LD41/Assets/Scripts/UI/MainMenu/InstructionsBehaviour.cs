using UnityEngine;
using LD.General;

namespace LD.UI
{
    public class InstructionsBehaviour : MonoBehaviour, ITogglable
    {
        #region Private Variables
        [SerializeField]
        private GameObject m_childToToggle;
        #endregion

        #region Main Methods
        void Start()
        {
            m_childToToggle.SetActive(false);
        }

        public void Toggle()
        {
            m_childToToggle.SetActive(!m_childToToggle.active);
        }
        #endregion  
    }
}
