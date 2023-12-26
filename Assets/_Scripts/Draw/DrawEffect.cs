using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawEffect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            SuperGod.instance.PlaySE(4);
        else if(collision.gameObject.tag == "PlayerKIller")
        {
            SuperGod.instance.PlaySE(5);
        }
    }
}
