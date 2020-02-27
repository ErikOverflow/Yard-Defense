using SQLite4Unity3d;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense.Player
{
    [Serializable]
    public class PlayerLevelData
    {
        [SerializeField] ScienceNum attack;
        [SerializeField] ScienceNum defense;
        [SerializeField] ScienceNum health;
        [SerializeField] ScienceNum healthRegen;

        public string Attack { get => attack.ToString(); set => attack = ScienceNum.FromString(value); }
        public string Defense { get => defense.ToString(); set => defense = ScienceNum.FromString(value); }
        public string Health { get => health.ToString(); set => health = ScienceNum.FromString(value); }
        public string HealthRegen { get => healthRegen.ToString(); set => healthRegen = ScienceNum.FromString(value); }
        [Ignore] public ScienceNum AttackSN { get => attack; }
        [Ignore] public ScienceNum DefenseSN { get => defense; }
        [Ignore] public ScienceNum HealthSN { get => health; }
        [Ignore] public ScienceNum HealthRegenSN { get => healthRegen; }
    }
}
