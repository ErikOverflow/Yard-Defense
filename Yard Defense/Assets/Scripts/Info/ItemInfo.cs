using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense.Item
{
    //This is meant to be attached to a dropped item, or an item being held by a mob. 
    //This is not meant to be serialized.
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] ItemData itemData;

        public ItemData ItemData { get => itemData; }

        public void Initialize(ItemData _itemData)
        {
            itemData = _itemData;
        }
    }
}
