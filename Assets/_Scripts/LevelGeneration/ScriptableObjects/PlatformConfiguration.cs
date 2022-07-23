using UnityEngine;
using System.Collections.Generic;
using FrogNinja.platforms;

namespace FrogNinja.LevelGeneration.Configs
{
    [CreateAssetMenu(fileName = "PlatformConfig", menuName = "Platform/Platform Config", order = 0)]
    public class PlatformConfiguration : ScriptableObject
    {
        public List<BasePlatform> Platforms;
        public float defaultYIncrease = 1;
        
        public BasePlatform GetRandomPlatform()
        {
            return Platforms[Random.Range(0, Platforms.Count)];
        }

        private void OnValidate()
        {
            if (defaultYIncrease < 0) {
                Debug.Log("Can't be smaller than 0");
                defaultYIncrease = 1;
            } 
        }
    }
}
