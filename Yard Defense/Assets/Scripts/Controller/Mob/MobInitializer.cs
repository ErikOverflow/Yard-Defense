using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobInitializer : MonoBehaviour
    {
        [SerializeField] MobBattleInfo mobBattleInfo;
        [SerializeField] SpriteRenderer spriteRenderer;

        void Start()
        {
            MobInfo mob = BattleManager.Instance.Mob;
            if(mob == null)
            {
                mobBattleInfo.Initialize(
                    "TestMob",
                    new ScienceNum { baseValue = 10 },
                    new ScienceNum { baseValue = 2 },
                    1f,
                    null
                    );
                return;
            }
            spriteRenderer.sprite = mob.MobSO.sprite;
            mobBattleInfo.Initialize(
                mob.MobSO.name,
                mob.MobSO.health * mob.DifficultyScale,
                mob.MobSO.attackDamage * mob.DifficultyScale,
                mob.MobSO.attackFrequency,
                mob
                );
        }
    }
}