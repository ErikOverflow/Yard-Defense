using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerInitializer : MonoBehaviour
    {
        [SerializeField] PlayerBattleInfo playerBattleInfo;

        private void Awake()
        {
            PlayerStatsInfo psi = BattleManager.Instance.PlayerStatsInfo;
            playerBattleInfo.Initialize(
                psi.PlayerLevelData.HealthSN,
                psi.PlayerLevelData.AttackSN,
                psi.PlayerLevelData.DefenseSN,
                psi.PlayerLevelData.HealthRegenSN,
                0.5f
                );
        }
    }
}