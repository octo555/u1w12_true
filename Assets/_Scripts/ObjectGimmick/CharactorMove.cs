using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    [SerializeField] bool orUseFlightGravity;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float popPower;
    public float maxSpeed = 5f; // 速度の上限

    private void Update()
    {
        if (StopTime.instance.isPaused == false)
        {
            if (orUseFlightGravity)
            {
                float xSpeed = speedX;
                float ySpeed = rb.velocity.y;

                // Y軸方向のマウスに追従する移動
                float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                ySpeed = Mathf.MoveTowards(ySpeed, mouseY - transform.position.y, speedY * Time.deltaTime);

                // Rigidbody2Dを使用して物体を移動させる
                rb.velocity = new Vector2(xSpeed, ySpeed);
            }
            else
            {
                if(speedX != 0)
                    rb.velocity = new Vector2(speedX, rb.velocity.y);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(popPower * Vector2.up, ForceMode2D.Impulse);
    }
}
