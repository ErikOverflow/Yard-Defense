using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobBattleInitializer : MonoBehaviour
    {
        [SerializeField] MobBattleInfo mobBattleInfo;
        [SerializeField] SpriteRenderer spriteRenderer;

        void Awake()
        {
            MobInfo mob = BattleManager.Instance.Mob;
            spriteRenderer.sprite = mob.MobSO.sprite;
            mobBattleInfo.Initialize(
                mob.MobSO.name,
                mob.MobSO.health * mob.DifficultyScale,
                mob.MobSO.attackDamage * mob.DifficultyScale,
                mob.MobSO.attackFrequency
                );
        }
    }
}