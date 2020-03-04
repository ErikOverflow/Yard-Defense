using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobBattleInfo : MonoBehaviour
    {
        [SerializeField] string mobName = "Mob";
        [SerializeField] ScienceNum currentHealth;
        [SerializeField] ScienceNum maxHealth;
        [SerializeField] ScienceNum attackDamage;
        [SerializeField] float attackFrequency = 1f; //seconds between attacks
        [SerializeField] MobInfo mobInfo;

        public ScienceNum CurrentHealth { get => currentHealth; }
        public float AttackFrequency { get => attackFrequency; }
        public ScienceNum AttackDamage { get => attackDamage; }
        public ScienceNum MaxHealth { get => maxHealth; }
        public string MobName { get => mobName; }
        public MobInfo MobInfo { get => mobInfo; }

        public void Initialize(
            string _name,
            ScienceNum _maxHealth,
            ScienceNum _attackDamage, 
            float _attackFrequency,
            MobInfo _mobInfo
            )
        {
            mobName = _name;
            maxHealth = _maxHealth;
            attackDamage = _attackDamage;
            attackFrequency = _attackFrequency;
            mobInfo = _mobInfo;
            ChangeHealth(maxHealth);
        }

        public void ChangeHealth(ScienceNum newHealth)
        {
            currentHealth = newHealth;
            EventManager.Instance.MobHealthChanged();
        }
    }
}