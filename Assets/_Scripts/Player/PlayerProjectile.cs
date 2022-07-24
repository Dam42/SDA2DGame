using UnityEngine;

namespace FrogNinja.Player
{
    public class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Rigidbody2D rb;
        [SerializeField] AudioClip clip;
        [SerializeField] AudioClip clip2;
        Vector3 direction = Vector3.zero;

        private void Awake()
        {
        }

        public void Shoot(Vector3 newDirection)
        {
            direction = newDirection;
            Invoke("Die", 3);
            AudioSystem.PlaySFX_Global(clip2);
        }

        private void FixedUpdate()
        {
            rb.velocity = direction * speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                AudioSystem.PlaySFX_Global(clip);
                Die();
            }
        }

        private void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
