using UnityEngine;

namespace FrogNinja.Player {
    public class PlayerShotting : MonoBehaviour
    {
        [SerializeField] PlayerProjectile projectile;
        [SerializeField] Animator anim;
        PlayerController playerController;
        Camera mainCamera;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (playerController.canMove == false) return;
            if (Input.GetMouseButtonDown(0)) SpawnProjectile();            
        }

        private void SpawnProjectile()
        {
            PlayerProjectile spawnedProjectile = GameObject.Instantiate<PlayerProjectile>(projectile, transform.position, Quaternion.Euler(0f, 0f, -90f));

            Vector3 direction = Vector3.up;

            Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldMousePosition.z = 0;

            direction = worldMousePosition - transform.position;

            //anim.CrossFade("Throw", 0);
            spawnedProjectile.Shoot(direction.normalized);
        }
    }
}


