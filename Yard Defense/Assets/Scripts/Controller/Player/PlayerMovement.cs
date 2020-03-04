using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace YardDefense.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        [SerializeField] Rigidbody2D rb2d;

        float moveX;

        private void Update()
        {
            moveX = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            rb2d.velocity = new Vector2(moveX* moveSpeed, rb2d.velocity.y);
        }
    }
}