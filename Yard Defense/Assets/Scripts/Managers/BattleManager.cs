using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YardDefense.Mob;
using YardDefense.Player;

#pragma warning disable 649
namespace YardDefense
{
    public class BattleManager : MonoBehaviour
    {
        public static BattleManager Instance;
        [SerializeField] PlayerStatsInfo playerInfo;
        
        MobSO mob;
        
        public MobSO MobSO { get => mob; }
        public PlayerStatsInfo PlayerStatsInfo { get=> playerInfo; }
        
        void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
            {
                Destroy(this);
                return;
            }
        }
        
        //Start a battle against the mob
        public void StartBattle(MobSO _mob)
        {
            mob = _mob;
            SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        }
        
        public void EndBattle()
        {
            SceneManager.UnloadSceneAsync("BattleScene");
        }
    }
}
