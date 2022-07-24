using UnityEngine;

namespace FrogNinja.platforms
{
    public class BouncyPlatform : BasePlatform
    {
        [SerializeField] AudioClip clip;
        private float bouncePower = 21f;
        protected override void HandleCollision(Collision2D collision)
        {
            AudioSystem.PlaySFX_Global(clip);
            collision.rigidbody.velocity = Vector3.zero;
            collision.rigidbody.AddForce(Vector2.up * bouncePower, ForceMode2D.Impulse);
        }
    }

}
