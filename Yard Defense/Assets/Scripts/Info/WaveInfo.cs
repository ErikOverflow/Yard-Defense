using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class WaveInfo : MonoBehaviour
    {
        //[SerializeField] List<WaveSO> weightedMobsList;
        //[SerializeField] ScienceNum difficultyScale;
        
        //Wave data
        [SerializeField] WaveSO wave;
        
        public WaveSO CurrentWave { get => wave; }
        //public ScienceNum DifficultyScale { get => difficultyScale; }
        
        public void ChangeWave(WaveSO _wave)
        {
            wave = _wave;
            EventManager.Instance.WaveChanged();
        }
    }
}