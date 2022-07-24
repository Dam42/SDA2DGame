using UnityEngine;

namespace FrogNinja.Player {
    public class PlayerShotting : MonoBehaviour
    {
        [SerializeField] PlayerProjectile projectile;
        PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
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

            spawnedProjectile.Shoot(direction);
        }
    }
}


