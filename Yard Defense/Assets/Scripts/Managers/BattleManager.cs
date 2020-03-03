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
        
        [SerializeField] MobInfo mob;
        
        public MobInfo Mob { get => mob; }
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

            EventManager.Instance.OnMobDied += EndBattle;
        }

        //Start a battle against the mob
        public void StartBattle(MobInfo _mob)
        {
            mob = _mob;
            mob.gameObject.SetActive(false);
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
            StartCoroutine(BattleLoader(sceneLoad));
        }

        IEnumerator BattleLoader(AsyncOperation sceneLoad)
        {
            while(!sceneLoad.isDone)
            {
                yield return null;
            }
            EventManager.Instance.BattleStarted();
        }
        
        public void EndBattle(MobBattleInfo mobBattleInfo)
        {
            AsyncOperation sceneLoad = SceneManager.UnloadSceneAsync("BattleScene");
            StartCoroutine(BattleUnloader(sceneLoad));
        }

        IEnumerator BattleUnloader(AsyncOperation sceneLoad)
        {
            while (!sceneLoad.isDone)
            {
                yield return null;
            }
            EventManager.Instance.BattleEnded();
        }
    }
}
