using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobInfo : MonoBehaviour
    {
        [SerializeField] MobSO mobSO;
        [SerializeField] ScienceNum difficultyScale;
        [SerializeField] SpriteRenderer spriteRenderer;
        
        public MobSO MobSO { get => mobSO; }
        public ScienceNum DifficultyScale { get => difficultyScale; }
        
        public void Spawn(MobSO _mobSO, ScienceNum _difficultyScale)
        {
            mobSO = _mobSO;
            difficultyScale = _difficultyScale;
            spriteRenderer.sprite = mobSO.sprite;
        }
    }
}