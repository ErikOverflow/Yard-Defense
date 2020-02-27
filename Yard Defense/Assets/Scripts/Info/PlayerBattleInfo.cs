using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerBattleInfo : MonoBehaviour
    {
        [SerializeField] ScienceNum currentHealth;
        [SerializeField] ScienceNum maxHealth;
        [SerializeField] ScienceNum attack;
        [SerializeField] ScienceNum defense;
        [SerializeField] ScienceNum healthRegen;
        [SerializeField] float attackFrequency = 0.5f; //Seconds between attacks

        public ScienceNum Attack { get => attack; }
        public ScienceNum Defense { get => defense; }
        public ScienceNum CurrentHealth { get => currentHealth; }
        public ScienceNum MaxHealth { get => maxHealth; }
        public ScienceNum HealthRegen { get => healthRegen; }
        public float AttackFrequency { get => attackFrequency; }

        public void Initialize(
            ScienceNum _maxHealth,
            ScienceNum _attack,
            ScienceNum _defense,
            ScienceNum _healthRegen,
            float _attackFrequency
            )
        {
            maxHealth = _maxHealth;
            attack = _attack;
            defense = _defense;
            healthRegen = _healthRegen;
            attackFrequency = _attackFrequency;
            ChangeHealth(maxHealth);
        }

        public void ChangeHealth(ScienceNum newHealth)
        {
            currentHealth = newHealth;
            EventManager.Instance.PlayerHealthChanged();
        }
    }
}