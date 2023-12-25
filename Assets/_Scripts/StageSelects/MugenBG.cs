using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugenBG : MonoBehaviour
{
    float xx = 14f;
    public GameObject bg;

    private void OnEnable()
    {
        for (int i = 1; i < 100; i++) 
        {
            Instantiate(bg, new Vector2(1.39f + xx * i, 0.42f), Quaternion.identity);
        }
    }
}
