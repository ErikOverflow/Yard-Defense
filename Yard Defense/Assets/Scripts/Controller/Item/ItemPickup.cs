using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YardDefense.Player;

#pragma warning disable 649
namespace YardDefense.Item
{
    public class ItemPickup : MonoBehaviour
    {
        [SerializeField] ItemInfo itemInfo;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerMovement>() != null)
            {
                EventManager.Instance.ItemCollision(itemInfo.ItemData);
                gameObject.SetActive(false);
            }
        }
    }
}