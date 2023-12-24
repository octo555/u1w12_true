using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    [SerializeField] bool orUseFlightGravity;
    [SerializeField] float flightSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speedX;

    private void Update()
    {
        if (StopTime.instance.isPaused == false)
        {
            if (orUseFlightGravity)
            {
                rb.velocity = new Vector2(speedX, 0);
                transform.Translate(Vector2.down * flightSpeed * Time.deltaTime);
            }
            else
            {
                rb.velocity = new Vector2(speedX, rb.velocity.y);
            }
        }
    }
}
