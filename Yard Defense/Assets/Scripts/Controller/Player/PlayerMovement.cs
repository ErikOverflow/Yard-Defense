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

        private void Update()
        {
            Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), 0);
            MovePlayer(moveDir);
        }

        private void MovePlayer(Vector2 moveDir)
        {
            rb2d.velocity = moveDir * moveSpeed;
        }
    }
}