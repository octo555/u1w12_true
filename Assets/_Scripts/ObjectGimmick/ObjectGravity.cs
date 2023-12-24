using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [HideInInspector] public Vector2 preVelocity = Vector2.zero;
    [HideInInspector] public float preAngular = 0;
    private FlipStage flipStage;

    private void OnEnable()
    {
        flipStage = FindObjectOfType<FlipStage>();
        if (flipStage != null)
        {
            flipStage.gravityResetEvent.AddListener(GravityZero);
        }
        else
        {
            Debug.LogError("FlipStage not found!");
        }
    }

    private void OnDisable()
    {
        /*if (flipStage != null)
        {
            flipStage.gravityResetEvent.RemoveListener(GravityZero);
        }
        else
        {
            Debug.LogError("FlipStage not found!");
        }*/
    }

    private void GravityZero()
    {
        if(rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
