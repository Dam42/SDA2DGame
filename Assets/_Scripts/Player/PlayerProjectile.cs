using UnityEngine;

namespace FrogNinja.Player
{
    public class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Rigidbody2D rb;
        Vector3 direction = Vector3.zero;

        private void Awake()
        {
        }

        public void Shoot(Vector3 newDirection)
        {
            direction = newDirection;
            Invoke("Die", 3);
        }

        private void FixedUpdate()
        {
            rb.velocity = direction * speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
