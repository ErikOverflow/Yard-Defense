using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobAttack : MonoBehaviour
    {
        [SerializeField] MobBattleInfo mobBattleInfo;
        float timer;

        private void Awake()
        {
            timer = 0f;
            EventManager.Instance.OnMobDied += DisableAttacking;
        }

        private void OnDestroy()
        {
            EventManager.Instance.OnMobDied -= DisableAttacking;
        }

        private void DisableAttacking(MobInfo _mobInfo)
        {
            if (mobBattleInfo.MobInfo == _mobInfo)
                this.enabled = false;
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > mobBattleInfo.AttackFrequency)
            {
                timer -= mobBattleInfo.AttackFrequency;
                EventManager.Instance.MobAttack(mobBattleInfo.AttackDamage);
            } 
        }
    }
}