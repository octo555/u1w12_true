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
    public float maxSpeed = 5f; // ���x�̏��

    private void Update()
    {
        if (StopTime.instance.isPaused == false)
        {
            if (orUseFlightGravity)
            {
                float xSpeed = speedX;
                float ySpeed = rb.velocity.y;

                // Y�������̃}�E�X�ɒǏ]����ړ�
                float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                ySpeed = Mathf.MoveTowards(ySpeed, mouseY - transform.position.y, speedY * Time.deltaTime);

                // Rigidbody2D���g�p���ĕ��̂��ړ�������
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
