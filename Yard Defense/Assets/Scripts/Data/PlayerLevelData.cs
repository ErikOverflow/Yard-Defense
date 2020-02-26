using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense.Player
{
    [Serializable]
    public class PlayerLevelData
    {
        [SerializeField] int attack;
        [SerializeField] int defense;
        [SerializeField] int health;
        [SerializeField] int healthRegen;
    }
}
