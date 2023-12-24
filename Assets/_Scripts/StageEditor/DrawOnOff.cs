using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnOff : MonoBehaviour
{
    public static DrawOnOff instance;

    public bool canDraw = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SwitchDrawMode(bool b)
    {
        canDraw = b;
    }
}
