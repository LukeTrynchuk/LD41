using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD.General
{
    /// <summary>
    /// This class will advance to the next scene in the build index when 
    /// its Advance() method is called. Meant for sequential scene management.
    /// </summary>
    public class AdvanceToNextScene : MonoBehaviour
    {
        #region Main Methods
        public void Advance()
        {
            Scene scene = SceneManager.GetActiveScene();
            int index = scene.buildIndex;
            index++;
            SceneManager.LoadScene(index);
        }
        #endregion

    }
}
