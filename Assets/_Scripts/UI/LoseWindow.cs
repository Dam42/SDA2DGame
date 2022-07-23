using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrogNinja.UI
{
    public class LoseWindow : BaseWindow {

        [SerializeField] GameObject textObjectHolder;
        [SerializeField] private TMPro.TMP_Text currentScore;
        [SerializeField] private TMPro.TMP_Text highScore;

        public override void ShowWindow()
        {
            base.ShowWindow();

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

            bool hasScoreManager = scoreManager != null;
            textObjectHolder.SetActive(hasScoreManager);

            if (!hasScoreManager) return;

            currentScore.text = $"Current Score: {scoreManager.CurrentScore}";
            highScore.text = $"High Score: {scoreManager.HighScore}";
        }

        public void Button_RestartGame()
        {
            EventManager.EnterGameplayButton();
        }

        public void Button_ReturnToMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
