﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YardDefense.Mob;
using YardDefense.Player;


#pragma warning disable 649
namespace YardDefense.UI
{
    public class HealthRenderer : MonoBehaviour
    {
        [SerializeField] Slider playerHPSlider;
        [SerializeField] PlayerBattleInfo playerBattleInfo;

        [SerializeField] Slider mobHPSlider;
        [SerializeField] MobBattleInfo mobBattleInfo;

        private void Awake()
        {
            EventManager.Instance.OnMobHealthChanged += UpdateMobHealth;
            EventManager.Instance.OnPlayerHealthChanged += UpdatePlayerHealth;
        }

        private void OnDestroy()
        {
            EventManager.Instance.OnMobHealthChanged -= UpdateMobHealth;
            EventManager.Instance.OnPlayerHealthChanged -= UpdatePlayerHealth;
        }

        private void Start()
        {
            UpdateMobHealth();
            UpdatePlayerHealth();
        }

        private void UpdatePlayerHealth()
        {
            playerHPSlider.minValue = 0;
            playerHPSlider.maxValue = 1;
            playerHPSlider.value = (playerBattleInfo.CurrentHealth / playerBattleInfo.MaxHealth).Conversion();
        }

        private void UpdateMobHealth()
        {
            mobHPSlider.minValue = 0;
            mobHPSlider.maxValue = 1;
            mobHPSlider.value = (mobBattleInfo.CurrentHealth / mobBattleInfo.MaxHealth).Conversion();
        }
    }
}