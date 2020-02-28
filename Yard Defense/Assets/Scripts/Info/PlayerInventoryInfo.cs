using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Item;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerInventoryInfo : MonoBehaviour
    {
        [SerializeField] List<ItemData> itemDatas;

        public List<ItemData> ItemDatas { get => itemDatas; }

        public void AddItem(ItemData itemData)
        {
            itemDatas.Add(itemData);
        }
    }
}