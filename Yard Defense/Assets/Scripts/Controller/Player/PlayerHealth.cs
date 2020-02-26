using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] PlayerBattleInfo playerBattleInfo;
        [SerializeField] float healFrequency = 1.0f;
        float timer;
        
        private void OnEnable()
        {
            EventManager.Instance.OnMobAttack += TakeDamage;
            timer = 0f;
        }
        
        private void OnDisable()
        {
            EventManager.Instance.OnMobAttack -= TakeDamage;
        }

        //Taking damage from Events
        private void TakeDamage(ScienceNum damageAmount)
        {
            damageAmount -= playerBattleInfo.defense;
            if(damageAmount < 0)
                damageAmount = 0;
            playerBattleInfo.ChangeHealth(playerBattleInfo.CurrentHealth - damageAmount);
        }
        
        //Automatic healing
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > healFrequency)
            {
                timer -= healFrequency;
                playerBattleInfo.ChangeHealth(playerBattleInfo.CurrentHealth + playerBattleInfo.HealthRegen);
            }
        }
    }
}