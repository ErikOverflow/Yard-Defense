using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] PlayerInfo playerInfo;
        [SerializeField] float healFrequency = 1.0f;
        float timer;
        
        private void Awake()
        {
            EventManager.Instance.OnMobAttack += TakeDamage;
            timer = 0f;
        }

        //Taking damage from Events
        private void TakeDamage(ScienceNum damageAmount)
        {
            damageAmount -= playerInfo.defense;
            if(damageAmount < 0)
                damageAmount = 0;
            playerInfo.ChangeHealth(playerInfo.CurrentHealth - damageAmount);
        }
        
        //Automatic healing
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer > healFrequency)
            {
                timer -= healFrequency;
                playerInfo.ChangeHealth(playerInfo.CurrentHealth + playerInfo.HealthRegen);
            }
        }
    }
}