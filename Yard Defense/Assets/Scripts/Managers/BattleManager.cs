using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    public class BattleManager : MonoBehaviour
    {
        public static BattleManager Instance;
        [SerializeField] PlayerInfo playerInfo;
        
        MobSO mob;
        
        public MobSO MobSO { get => mob; }
        public PlayerStatsInfo PlayerStatsInfo { get=> playerInfo; }
        
        void Awake()
        {
            if(instance == null)
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
