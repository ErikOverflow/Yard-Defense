using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobHealth : MonoBehaviour
    {
        [SerializeField] MobBattleInfo mobBattleInfo;

        private void OnEnable()
        {
            EventManager.Instance.OnPlayerAttack += TakeDamage;
            EventManager.Instance.OnMobDied += DisableHealth;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnPlayerAttack -= TakeDamage;
            EventManager.Instance.OnMobDied -= DisableHealth;
        }

        private void DisableHealth(MobBattleInfo _mobBattleInfo)
        {
            if(mobBattleInfo == _mobBattleInfo)
            {
                this.enabled = false;
            }
        }

        private void TakeDamage(ScienceNum damageAmount)
        {
            mobBattleInfo.ChangeHealth(mobBattleInfo.CurrentHealth - damageAmount);
        }
    }
}