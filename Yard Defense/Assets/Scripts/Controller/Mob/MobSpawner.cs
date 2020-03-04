using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobSpawner : MonoBehaviour
    {
        //Prefab for a mob you see in the yard, NOT a battle mob.
        [SerializeField] WaveInfo waveInfo;
        [SerializeField] ScalerInfo scalerInfo;
        [SerializeField] SpawnerInfo spawnerInfo;
        [SerializeField] GameObject mobPrefab;
        float timer;

        private void Awake()
        {
            EventManager.Instance.OnWaveChanged += PoofAwayMobs;
            EventManager.Instance.OnMobDied += RemoveMob;
            timer = 0;
        }
        
        private void OnDestroy()
        {
            EventManager.Instance.OnWaveChanged -= PoofAwayMobs;
            EventManager.Instance.OnMobDied -= RemoveMob;
        }

        private void RemoveMob(MobInfo mobInfo)
        {
            spawnerInfo.RemoveMob(mobInfo);
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > spawnerInfo.SpawnTimer)
            {
                timer -= spawnerInfo.SpawnTimer;

                if (spawnerInfo.SpawnCount >= spawnerInfo.SpawnLimit)
                    return;

                GameObject go = ObjectPooler.Instance.GetPooledObject(mobPrefab);
                go.transform.SetParent(spawnerInfo.SpawnPoint);
                go.transform.localPosition = Vector3.zero;

                //Use object pooler to instantiate mobPrefab
                MobInfo mobInfo = go.GetComponent<MobInfo>();
                
                //Sum up the total weight of mobs
                float totalWeight = 0f;
                foreach(WeightedMob wm in waveInfo.CurrentWave.mobs)
                {
                    totalWeight += wm.weight;
                }
                
                //Pick a random number up to the maximum weight
                float randMob = UnityEngine.Random.Range(0f, totalWeight);
                
                //Iterate through the mobs until that weight is reached.
                MobSO mob = null;
                foreach(WeightedMob wm in waveInfo.CurrentWave.mobs)
                {
                    randMob -= wm.weight;
                    if(randMob <= 0f)
                    {
                        mob = wm.mob;
                        break;
                    }
                }
                
                mobInfo.Initialize(mob, scalerInfo.DifficultyScale);
                //Update the spawnerInfo with this specific mob
                spawnerInfo.MobSpawned(mobInfo);
                //Generic event stating a mob has spawned
                EventManager.Instance.MobSpawned(mobInfo);
            } 
        }
        
        void PoofAwayMobs()
        {
            foreach(MobInfo mi in spawnerInfo.GetAllMobs())
            {
                //Insert a poof animation at the mob's location if desired
                mi.gameObject.SetActive(false);
            }
            spawnerInfo.ReleaseAllMobs();
        }
    }
}