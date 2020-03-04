using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Mob
{
    public class MobMovement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] float moveSpeed = 2f;

        private void OnEnable()
        {
            rb2D.velocity = new Vector2(-moveSpeed, 0);
        }
    }
}