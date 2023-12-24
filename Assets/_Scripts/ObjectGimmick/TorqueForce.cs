using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueForce : MonoBehaviour
{
    public float torqueForce = 0;
    public Vector2 rotationPoint; // 回転の中心となるポイントを指定

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (torqueForce != 0 && !StopTime.instance.isPaused)
        {
            RotateAroundPoint(rotationPoint, torqueForce);
        }
    }

    private void RotateAroundPoint(Vector2 point, float force)
    {
        Vector2 offset = (Vector2)transform.position - point;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        rb.AddTorque(force * Time.fixedDeltaTime);

        float currentAngle = rb.rotation;
        float newAngle = currentAngle + torqueForce * Time.fixedDeltaTime;

        Vector2 newPosition = RotatePointAroundPivot(transform.position, point, new Vector3(0, 0, newAngle - angle));
        rb.MovePosition(newPosition);
    }

    private Vector2 RotatePointAroundPivot(Vector2 point, Vector2 pivot, Vector3 angles)
    {
        Vector2 direction = point - pivot;
        direction = Quaternion.Euler(angles) * direction;
        return direction + pivot;
    }
}
