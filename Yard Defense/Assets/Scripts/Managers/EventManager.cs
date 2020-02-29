using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Item;
using YardDefense.Mob;

#pragma warning disable 649
namespace YardDefense
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        /// <summary>
        /// Player specific scripts
        /// </summary>

        public event Action<ScienceNum> OnPlayerAttack;
        public void PlayerAttack(ScienceNum damage)
        {
            OnPlayerAttack?.Invoke(damage);
        }

        public event Action OnPlayerHealthChanged;
        public void PlayerHealthChanged()
        {
            OnPlayerHealthChanged?.Invoke();
        }

        /// <summary>
        /// Mob specific scripts
        /// </summary>

        public event Action<ScienceNum> OnMobAttack;
        public void MobAttack(ScienceNum damage)
        {
            OnMobAttack?.Invoke(damage);
        }

        public event Action OnMobHealthChanged;
        public void MobHealthChanged()
        {
            OnMobHealthChanged?.Invoke();
        }

        public event Action<MobBattleInfo> OnMobDied;
        public void MobDied(MobBattleInfo mobBattleInfo)
        {
            OnMobDied?.Invoke(mobBattleInfo);
        }

        public event Action<ItemData> OnItemCollision;
        public void ItemCollision(ItemData itemData)
        {
            OnItemCollision?.Invoke(itemData);
        }
    }
}