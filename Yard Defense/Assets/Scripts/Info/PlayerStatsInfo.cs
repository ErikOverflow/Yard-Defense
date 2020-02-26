using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerStatsInfo : MonoBehaviour
    {
        [SerializeField] PlayerLevelData playerLevelData;
        [SerializeField] ItemData collar;
        [SerializeField] ItemData toy;

        public PlayerLevelData PlayerLevelData { get => playerLevelData; }
        public ItemData Collar { get => collar; }
        public ItemData Toy { get => toy; }
    }
}