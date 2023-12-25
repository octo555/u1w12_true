using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    [SerializeField] bool orUseFlightGravity;
    [SerializeField] float flightSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedX;
    [SerializeField] float popPower;
    [SerializeField] float forceMultiplier;
    public float maxSpeed = 5f; // ‘¬“x‚ÌãŒÀ

    private void Update()
    {
        if (StopTime.instance.isPaused == false)
        {
            if (orUseFlightGravity)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f; // ƒJƒƒ‰‚Æ‚Ì‹——£‚ðŒÅ’è
                Vector2 forceDirection = (mousePosition - transform.position).normalized;
                rb.AddForce(forceDirection * forceMultiplier);

                if (rb.velocity.magnitude > maxSpeed)
                {
                    rb.velocity = rb.velocity.normalized * maxSpeed;
                }
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
