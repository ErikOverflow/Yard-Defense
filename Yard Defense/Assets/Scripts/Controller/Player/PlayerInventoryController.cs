using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Item;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerInventoryController : MonoBehaviour
    {
        [SerializeField] PlayerInventoryInfo playerInventoryInfo;

        private void Awake()
        {
            EventManager.Instance.OnItemCollision += playerInventoryInfo.AddItem;
        }
        
        private void OnDestroy()
        {
            EventManager.Instance.OnItemCollision -= playerInventoryInfo.AddItem;
        }
    }
}