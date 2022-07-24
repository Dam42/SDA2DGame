using UnityEngine;

namespace FrogNinja.Enemies
{
    public class FullHoveringEnemy : BaseEnemy
    {
        Vector2 movementRange;

        private void Awake()
        {
            movementRange = new Vector2(17, -17);
            velocity = new Vector2(speed, 0);
        }

        protected override void Move()
        {
            rb.velocity = velocity;

            float posX = transform.position.x;

            if (posX > movementRange.x)
            {
                velocity.x = -speed;
            }
            else if (posX < movementRange.y)
            {
                velocity.x = speed;
            }
        }
    }
}

