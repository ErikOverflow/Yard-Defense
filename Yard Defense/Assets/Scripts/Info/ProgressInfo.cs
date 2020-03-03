using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class ProgressInfo : MonoBehaviour
    {
        [SerializeField] NeighborhoodSO neighborhoodSO;
        [SerializeField] int currentWaveNum = 1;
        [SerializeField] int maxWave = 1;
        [SerializeField] int mobsDefeatedInWave = 0;
        
        public int CurrentWaveNum { get => currentWaveNum; }
        public NeighborhoodSO NeighborhoodSO { get => neighborhoodSO; }
        
        public void MobDefeated()
        {
            mobsDefeatedInWave++;
            EventManager.Instance.ProgressChanged();
        }
        
        //need to make sure we update this, as well as WaveInfo's ChangeWave
        public void ChangeWave(int newWaveNum)
        {
            if(maxWave < newWaveNum)
            {
                maxWave = newWaveNum;
                EventManager.Instance.NewMaxWave();
            }
            currentWaveNum = newWaveNum;
            EventManager.Instance.ProgressChanged();
        }
    }
}