using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Player;

#pragma warning disable 649
namespace YardDefense.Item
{
    //This controller will sit at the manager level.
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] GameObject itemPrefab;

        void Awake()
        {
            EventManager.Instance.OnMobDied += DropItemIfExists;
        }
        
        void OnDestroy()
        {
            EventManager.Instance.OnMobDied -= DropItemIfExists;
        }
        
        void DropItemIfExists(MobInfo mobInfo)
        {
            if(mobInfo.ItemData == null)
                return;
            ItemData item = mobInfo.ItemData;
        }
    }
}