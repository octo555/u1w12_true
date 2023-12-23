using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedX;
    [SerializeField] float speedY;

    private void Update()
    {
        rb.velocity = new Vector2(speedX, rb.velocity.y);
    }
}
