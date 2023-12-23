using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAspectRatio : MonoBehaviour
{
    [SerializeField] Transform spriteMask;

    Vector2 size1by1 = new Vector2(2.52f, 2.52f);
    Vector2 size16by9 = new Vector2(4.48f, 2.52f);
    Vector2 size9by16 = new Vector2(1.4175f, 2.52f);

    public void Size1by1()
    {
        spriteMask.localScale = size1by1;
    }

    public void Size16by9()
    {
        spriteMask.localScale = size16by9;
    }

    public void Size9by16()
    {
        spriteMask.localScale = size9by16;
    }
    
}
