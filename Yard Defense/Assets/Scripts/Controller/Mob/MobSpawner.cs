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
        [SerializeField] MobScaler mobScaler;
        [SerializeField] GameObject mobPrefab;
        [SerializeField] int spawnLimit = 3;
        [SerializeField] float spawnTimer = 2f;
        
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > spawnTimer)
            {
                timer -= spawnTimer;
                
                
                
                //Use object pooler to instantiate mobPrefab
                MobInfo mobInfo = go.GetComponent<MobInfo>();
                
                //Sum up the total weight of mobs
                float totalWeight = 0f;
                foreach(WeightedMob wm in waveInfo.CurrentWave.mobs)
                {
                    totalWeight += wm.weight;
                }
                
                //Pick a random number up to the maximum weight
                float randMob = Random.Range(0f, totalWeight);
                
                //Iterate through the mobs until that weight is reached.
                MobSO mob;
                foreach(WeightedMob wm in waveInfo.CurrentWave.mobs)
                {
                    randMob -= wm.weight;
                    if(randMob <= 0f)
                    {
                        mob = wm.mob;
                        break;
                    }
                }
                
                mobInfo.Initialize(mob, mobScaler.DifficultyScale);
                EventManager.Instance.MobSpawned(mobInfo);
            } 
        }
    }
}