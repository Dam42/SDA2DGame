using UnityEngine;

namespace FrogNinja.UI {
    public class HUDWindow : BaseWindow
    {
        [SerializeField] private TMPro.TMP_Text scoreCounter;

        public override void ShowWindow()
        {
            scoreCounter.text = "0";

            EventManager.CurrentScoreUpdated += EventManager_CurrentScoreUpdated;
            base.ShowWindow();
        }

        public override void HideWindow()
        {
            EventManager.CurrentScoreUpdated -= EventManager_CurrentScoreUpdated;
            base.HideWindow();
        }

        private void EventManager_CurrentScoreUpdated(int obj)
        {
            scoreCounter.text = obj.ToString();
        }

        public void Button_PauseGame()
        {

        }
    }
}

