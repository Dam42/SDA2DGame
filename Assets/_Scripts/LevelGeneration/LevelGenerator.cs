using FrogNinja.LevelGeneration.Configs;
using FrogNinja.platforms;
using System.Collections.Generic;
using UnityEngine;

namespace FrogNinja.LevelGeneration
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private List<PlatformConfiguration> platformConfigurations;
        [SerializeField] private List<BasePlatform> spawnedPlatforms;
        [SerializeField] private Transform playerSpawnPosition;
        [SerializeField] GameObject player;

        private float lastSpawnedY;
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;

            //CreatrStartLevel();

            EventManager.EnterGameplay += EventManager_EnterGameplay;
            EventManager.PlayerPositionUpdate += EventManager_PlayerPositionUpdate;
            EventManager.PlayerFallenOff += EventManager_PlayerFallenOff;
        }

        private void EventManager_PlayerPositionUpdate(Vector3 obj)
        {
            if(obj.y > lastSpawnedY/2)
            {
                SpawnPlatform();
            }
        }

        private void EventManager_EnterGameplay()
        {
            player.transform.position = playerSpawnPosition.position;
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, playerSpawnPosition.position.y, -10);
            foreach (BasePlatform platform in spawnedPlatforms)
            {
                Destroy(platform.gameObject);
            }
            spawnedPlatforms.Clear();
            CreatrStartLevel();        
        }

        private void EventManager_PlayerFallenOff()
        {
            
        }

        private void CreatrStartLevel()
        {
            lastSpawnedY = playerSpawnPosition.position.y;

            for (int i = 0; i < 10; i++)
            {
                SpawnPlatform();
            }
        }

        private void SpawnPlatform()
        {
            PlatformConfiguration configToUse = platformConfigurations[Random.Range(0, platformConfigurations.Count)];

            Vector3 spawnPosition = new Vector3(GetRandomXPosition(), lastSpawnedY + configToUse.defaultYIncrease, 0);

            BasePlatform platformToSpawn = configToUse.GetRandomPlatform();

            spawnedPlatforms.Add(GameObject.Instantiate<BasePlatform>(platformToSpawn, spawnPosition, Quaternion.identity, transform)); 

            lastSpawnedY = spawnPosition.y;
        }

        private float GetRandomXPosition()
        {
            var randomValue = Random.Range(0f, 1f);

            Vector3 resutlPosition = mainCamera.ViewportToWorldPoint(new Vector3(randomValue, 0));

            return resutlPosition.x;
        }

        private void OnDestroy()
        {
            EventManager.EnterGameplay -= EventManager_EnterGameplay;
            EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
            EventManager.PlayerFallenOff -= EventManager_PlayerFallenOff;
        }
    }
}