using System;
using UnityEngine;

namespace FrogNinja.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D player;
        [SerializeField] private float movementSpeed;
        [SerializeField] private SpriteRenderer sprite;
        private Camera mainCamera;
        private bool wrapScreen;
        private Vector3 screenPosition;
        private Vector2 newPlayerVelocity;
        private float horizontalInput;
        private float fallingMultiplier;
        public bool canMove = false;

        private void Awake()
        {
            mainCamera = Camera.main;

            //Set gravity multipliers for falling and for low jump
            fallingMultiplier = Physics2D.gravity.y * (3 - 1);
        }

        private void Update()
        {
            if (canMove == false) {
                player.velocity = new Vector2(0, 0);
                return;
            }
           

            horizontalInput = Input.GetAxis("Horizontal");

            if (player.velocity.y == 0 && Input.GetKeyDown(KeyCode.X)) InitJump();
            if (horizontalInput != 0) MovePlayer();
            else
            {
                newPlayerVelocity.x = 0;
                newPlayerVelocity.y = player.velocity.y;
                player.velocity = newPlayerVelocity;
            }

            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * fallingMultiplier * Time.deltaTime;
            }

            EventManager.OnUpdatePlayerPosition(transform.position);

            HandleScreenWrap();
            if (wrapScreen)
                player.transform.localPosition = Camera.main.ViewportToWorldPoint(screenPosition);
        }

        private void InitJump()
        {
            player.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }

        private void MovePlayer()
        {
            newPlayerVelocity.x = horizontalInput * movementSpeed;
            newPlayerVelocity.y = player.velocity.y;
            player.velocity = newPlayerVelocity;
            sprite.flipX = horizontalInput > 0;
        }

        private void HandleScreenWrap()
        {
            screenPosition = mainCamera.WorldToViewportPoint(transform.position);

            if (screenPosition.x < -0.03f)
            {
                screenPosition.x = 1.03f;
                wrapScreen = true;
            }
            else if (screenPosition.x > 1.03f)
            {
                screenPosition.x = -0.03f;
                wrapScreen = true;
            }
            else
            {
                wrapScreen = false;
            }
        }
    }
}
