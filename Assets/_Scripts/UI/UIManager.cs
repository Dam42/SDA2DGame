using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] MainMenuWindow mainMenu;

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
        }

        public void ShowFail()
        {
            Debug.Log($"Show fail from {name}");
        }
    }

}
