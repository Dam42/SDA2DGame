using UnityEngine;

namespace FrogNinja.UI
{
    public class GameEnder : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                UIManager.Instance.ShowFail();
            }
        }
    }

}
