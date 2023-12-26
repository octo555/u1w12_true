using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string tagName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == tagName)
        {
            SEManager.instance.PlaySE(2);
            StageManager.instance.GoNextStage();
        }
    }
}
