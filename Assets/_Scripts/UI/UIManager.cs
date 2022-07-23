using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

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

        public void ShowFail()
        {
            Debug.Log($"Show fail from {name}");
        }
    }

}
