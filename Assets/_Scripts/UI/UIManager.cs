using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] MainMenuWindow mainMenu;
        [SerializeField] LoseWindow loseWindow;
        [SerializeField] HUDWindow hud;

        BaseWindow currentlyOpenWindow;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Debug.Log($"{name} is Initialized");
            Instance = this;
        }

        public void ShowMainMenu()
        {
            if(currentlyOpenWindow != null)
            {
                currentlyOpenWindow.HideWindow();
            }

            currentlyOpenWindow = mainMenu;
            currentlyOpenWindow.ShowWindow();
        }

        public void ShowDeathScreen()
        {
            if (currentlyOpenWindow != null)
            {
                currentlyOpenWindow.HideWindow();
            }

            currentlyOpenWindow = loseWindow;
            currentlyOpenWindow.ShowWindow();
        }

        public void ShowHUD()
        {
            HideAndSwitchWindow(hud);
        }

        private void HideAndSwitchWindow(BaseWindow windowtoSwitchTo)
        {
            if (currentlyOpenWindow != null)
                currentlyOpenWindow.HideWindow();

            currentlyOpenWindow = windowtoSwitchTo;

            currentlyOpenWindow.ShowWindow();
        }
    }

}
