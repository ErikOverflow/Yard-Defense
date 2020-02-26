using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] PlayerBattleInfo playerBattleInfo;
        float timer;

        private void Awake()
        {
            timer = 0f;
        }

        private void Update()
        {
            //Automated attacking
            timer += Time.deltaTime;
            if (timer > playerBattleInfo.AttackFrequency)
            {
                timer -= playerBattleInfo.AttackFrequency;
                EventManager.Instance.PlayerAttack(playerBattleInfo.Attack);
            }

            //Manual attacking (via clicks)
#if !UNITY_IOS && !UNITY_ANDROID
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.Instance.PlayerAttack(playerBattleInfo.Attack);
            }
#endif
        }
    }
}