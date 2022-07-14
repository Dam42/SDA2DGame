using UnityEngine;

namespace FrogNinja.platforms
{
    public class BouncyPlatform : BasePlatform
    {
        private float bouncePower = 22f;
        protected override void HandleCollision(Collision2D collision)
        {
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
        }
    }

}
