using UnityEngine;

namespace FrogNinja.Enemies {
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected SpriteRenderer sprite;
        [SerializeField] protected float speed;
        protected Vector2 velocity;

        protected virtual void Update()
        {
            Move();
            sprite.flipX = velocity.x > 0;
        }

        protected abstract void Move();

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player")) 
                EventManager.OnEnemeyHitPlayer();

            if(collision.gameObject.CompareTag("Projectile"))
            {
                rb.gameObject.SetActive(false);
                EventManager.OnEnemeyDeath();
            }
        }
    }
}
