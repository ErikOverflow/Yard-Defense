using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Mob;

namespace YardDefense
{
    [Serializable]
    public struct WeightedMob
    {
        public MobSO mob;
        public float weight;
    }
}