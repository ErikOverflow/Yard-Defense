using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobScaler : MonoBehaviour
    {
        [SerializeField] ProgressInfo progressInfo;
        [SerializeField] ScienceNum scalingPerWave;
        Dictionary<int, ScienceNum> difficultyDictionary;
        int highestDictionaryEntry;

        void Awake()
        {
            //Build a dictionary of difficulties
            difficultyDictionary = new Dictionary<int, ScienceNum>();
            int waveNum = 0;
            ScienceNum waveScale = new ScienceNum { baseValue = 1f, eFactor = 0 };
            foreach (WaveSO wave in progressInfo.NeighborhoodSO.waves)
            {
                waveNum++;
                waveScale *= scalingPerWave;
                difficultyDictionary.Add(waveNum, waveScale);
            }
        }

        public ScienceNum DifficultyScale
        {
            get
            {

                ScienceNum sn;
                if (!difficultyDictionary.TryGetValue(progressInfo.CurrentWaveNum, out sn))
                {
                    sn = new ScienceNum
                    {
                        baseValue = 1f,
                        eFactor = 0
                    };
                }
                return sn;
            }
        }
    }
}