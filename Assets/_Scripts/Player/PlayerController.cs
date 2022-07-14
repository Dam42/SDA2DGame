using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _movementSpeed; 
    private float _horizontalInput;
    private float _boundLeftX = -9.5f, _boundRightX = 0.5f;
    Vector3 screenPosition;
    private Camera mainCamera;
    bool wrapScreen;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (_horizontalInput != 0) MovePlayer();
        HandleScreenWrap();
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

        if (screenPosition.y < 0f)
        {
            //Debug.Log("Player fallen off");
        }
    }

    private void FixedUpdate()
    {
        if (wrapScreen)
            rb.MovePosition(Camera.main.ViewportToWorldPoint(screenPosition));
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(_horizontalInput * _movementSpeed, rb.velocity.y);
    }
}
