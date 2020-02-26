using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense.Mob
{
    public class MobInitializer : MonoBehaviour
    {
        [SerializeField] MobInfo mobInfo;
        [SerializeField] SpriteRenderer spriteRenderer;

        void Awake()
        {
            MobSO mobSO = BattleManager.Instance.MobSO;
            spriteRenderer.sprite = mobSO.sprite;
            mobInfo.Initialize(
                mobSO.name,
                mobSO.health,
                mobSO.attackDamage,
                mobSO.attackFrequency
                );
        }
    }
}