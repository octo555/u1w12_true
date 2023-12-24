using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    [SerializeField] AIEffect aIEffect;
    public Texture2D[] cursorTextures;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        if(instance == null)   
            instance = this;
    }

    public void ResetAIEffectNumber()
    {
        aIEffect.AIModeNumber = -1;
    }

    public void ChageCursor(int index)
    {
        Cursor.SetCursor(cursorTextures[index], hotSpot, CursorMode.Auto);
    }

    public void ResetCursor()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }
}
