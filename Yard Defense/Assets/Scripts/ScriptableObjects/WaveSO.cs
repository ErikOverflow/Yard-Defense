using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Mob;

namespace YardDefense
{
    [CreateAssetMenu(fileName = "New wave", menuName = "Create new wave", order = 1)]
    public class WaveSO : SpriteableObject
    {
        public List<WeightedMob> mobs;
        public MobSO boss;
    }
}