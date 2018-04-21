using UnityEngine;

namespace LD.General
{
    /// <summary>
    /// This component will toggle any objects in the object array.
    /// </summary>
    public class ToggleToggles : MonoBehaviour
    {
        #region Private Variables
        [SerializeField]
        private GameObject[] m_gameObjectsToToggle;
        #endregion

        #region Main Methods
        public void ToggleItems()
        {
            foreach(GameObject go in m_gameObjectsToToggle)
            {
                ITogglable togglable = go.GetComponent<ITogglable>();

                if (togglable != null)
                    togglable.Toggle();
            }
        }
        #endregion
    }
}
