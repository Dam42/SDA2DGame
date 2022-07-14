using UnityEngine;

namespace FrogNinja.platforms
{
    public abstract class BasePlatform : MonoBehaviour
    {
        protected abstract void HandleCollision(Collision2D collision);

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.rigidbody.velocity.y > 0)
            {
                return;
            }

            if (collision.transform.position.y < transform.position.y)
            {
                return;
            }

            HandleCollision(collision);
        }
    }
}

