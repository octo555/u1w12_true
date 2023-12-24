using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueForce : MonoBehaviour
{
    public float torqueForce = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(torqueForce != 0 && StopTime.instance.isPaused == false)
        rb.MoveRotation(rb.rotation + torqueForce * Time.fixedDeltaTime);
    }

    public void DiableColliderTempraly()
    {
        transform.GetComponent<Collider2D>().enabled = false;
        Invoke("C", 1f);
    }

    private void C()
    {
        transform.GetComponent<Collider2D>().enabled = true;
    }
}
