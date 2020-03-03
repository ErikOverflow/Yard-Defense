using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobInfo : MonoBehaviour
    {
        //mobSO should be null when this is attached to a prefab for spawning mobs, otherwise you waste CPU cycles double-initializing
        [SerializeField] MobSO mobSO;
        [SerializeField] ItemData itemData;
        [SerializeField] ScienceNum difficultyScale;
        [SerializeField] SpriteRenderer spriteRenderer;
        
        public MobSO MobSO { get => mobSO; }
        public ItemData ItemData {get => itemData; }
        public ScienceNum DifficultyScale { get => difficultyScale; }

        private void Start()
        {
            if(mobSO != null)
            {
                Initialize(mobSO, difficultyScale);
            }
        }

        public void Initialize(MobSO _mobSO, ScienceNum _difficultyScale)
        {
            mobSO = _mobSO;
            difficultyScale = _difficultyScale;
            spriteRenderer.sprite = mobSO.sprite;
            itemData = new ItemData{};
        }
    }
}