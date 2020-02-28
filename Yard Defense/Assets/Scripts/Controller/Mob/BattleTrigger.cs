using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class BattleTrigger : MonoBehaviour
    {
        [SerializeField] MobInfo mobInfo;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerMovement>() != null)
            {
                BattleManager.Instance.StartBattle(mobInfo);
            }
        }
    }
}