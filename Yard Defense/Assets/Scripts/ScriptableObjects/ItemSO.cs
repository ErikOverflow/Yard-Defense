using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense.Mob
{
    [CreateAssetMenu(fileName = "New item", menuName = "Create new item", order = 1)]
    public class ItemSO : SpriteableObject
    {
        public ScienceNum health;
        public ScienceNum attackDamage;
        public float attackFrequency = 0.5f;
    }
}