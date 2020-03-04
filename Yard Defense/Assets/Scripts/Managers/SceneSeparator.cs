using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense
{
    public class SceneSeparator : MonoBehaviour
    {
        [SerializeField] GameObject backyard;
        [SerializeField] GameObject player;

        private void Awake()
        {
            EventManager.Instance.OnBattleStarted += AnimateBattleStart;
            EventManager.Instance.OnBattleEnded += AnimateBattleEnded;
        }

        private void AnimateBattleEnded()
        {
            backyard.SetActive(true);
            player.SetActive(true);
        }

        private void AnimateBattleStart()
        {
            backyard.SetActive(false);
            player.SetActive(false);
        }
    }
}