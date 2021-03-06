using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class SpawnerInfo : MonoBehaviour
    {
        [SerializeField] int spawnLimit = 3;
        [SerializeField] float spawnTimer = 2f;
        [SerializeField] Transform[] spawnPoint;
        HashSet<MobInfo> spawnedMobs;
        
        public int SpawnLimit { get => spawnLimit; }
        public float SpawnTimer { get => spawnTimer; }
        public int SpawnCount { get => spawnedMobs.Count; }
        public Transform[] SpawnPoints { get => spawnPoint; }
        
        void Awake()
        {
            spawnedMobs = new HashSet<MobInfo>();
        }
        
        public void MobSpawned(MobInfo mobInfo)
        {
            spawnedMobs.Add(mobInfo);
        }
        
        public void RemoveMob(MobInfo mobInfo)
        {
            spawnedMobs.Remove(mobInfo);
        }
        
        public IEnumerable<MobInfo> GetAllMobs()
        {
            return spawnedMobs;
        }
        
        public void ReleaseAllMobs()
        {
            spawnedMobs.Clear();
        }
    }
}