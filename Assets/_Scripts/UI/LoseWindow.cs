using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrogNinja.UI
{
    public class LoseWindow : BaseWindow {

        public void Button_RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Button_ReturnToMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
