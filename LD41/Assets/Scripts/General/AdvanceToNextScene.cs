using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD.General
{
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
