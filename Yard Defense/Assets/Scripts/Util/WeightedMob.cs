using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    [Serializable]
    public struct WeightedMob
    {
        public MobSO mob;
        public float weight;
    }
}