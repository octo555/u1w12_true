using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseTime : MonoBehaviour
{
    public float eraseTime;
    public LineRenderer lineRenderer;
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > eraseTime)
        {
            Destroy(gameObject);
        }
        else
        {
            // eraseTimeに近づくに連れてアルファ値を下げる
            Color currentColor = lineRenderer.startColor; // LineRendererの開始色を使用
            currentColor.a = 1.0f - (timer / eraseTime);
            lineRenderer.startColor = currentColor;
            lineRenderer.endColor = currentColor; // 開始と終了の色を同じに設定する場合
        }
    }
}
