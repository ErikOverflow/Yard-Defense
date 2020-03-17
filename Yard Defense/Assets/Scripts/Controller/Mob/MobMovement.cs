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
        GameObject target;

        public void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        private void FixedUpdate()
        {
            Vector3 targetDir = target.transform.position - rb2D.transform.position;
            rb2D.velocity = targetDir.normalized * moveSpeed;
        }
    }
}