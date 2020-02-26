using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YardDefense
{
    //This is meant to be attached to a dropped item, or an item being held by a mob. 
    //This is not meant to be serialized.
    public class ItemInfo : MonoBehaviour
    {
        [SerializeField] ItemSO item;
        
        public void Initialize(ItemSO _item)
        {
            item = _item;
        }
    }
}
