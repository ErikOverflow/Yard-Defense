using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    [Serializable]
    public class ItemData
    {
        [SerializeField] int id;
        [SerializeField] string name;
        [SerializeField] ItemType itmType;
        [SerializeField] ScienceNum attack;
        [SerializeField] float attackMult;
        [SerializeField] ScienceNum defense;
        [SerializeField] float defenseMult;
        [SerializeField] ScienceNum health;
        [SerializeField] float healthMult;
        [SerializeField] ScienceNum healthRegen;
        [SerializeField] float healthRegenMult;
        
        [AutoIncrement, PrimaryKey] public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int ItmType { get => (int) itmType; set => itmType = (ItemType) value; }
        public string Attack { get => attack.ToString(); set => attack = ScienceNum.FromString(value); }
        public float AttackMult {get => attackMult; set => attackMult = value; }
        public string Defense { get => defense.ToString(); set => defense = ScienceNum.FromString(value); }
        public float DefenseMult {get => defenseMult; set => defenseMult = value; }
        public string Health { get => health.ToString(); set => health = ScienceNum.FromString(value); }
        public float HealthMult {get => healthMult; set => healthMult = value; }
        public string HealthRegen { get => healthRegen.ToString(); set => healthRegen = ScienceNum.FromString(value); }
        public float HealthRegenMult {get => healthRegenMult; set => healthRegenMult = value; }
    }
}
