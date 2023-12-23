using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private void Awake()
    {
        if(this.transform.GetComponentInChildren<Rigidbody2D>() != null)
        {
            this.transform.GetComponentInChildren<Rigidbody2D>().gravityScale = 0;
        }
    }
}
