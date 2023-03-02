using UnityEngine;
using UnityEngine.SceneManagement;

namespace Monobehaviors
{
    public class ButtonHandler : MonoBehaviour
    {
        public void RestartingGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
