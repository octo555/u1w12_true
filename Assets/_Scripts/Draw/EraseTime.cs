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
            // eraseTime�ɋ߂Â��ɘA��ăA���t�@�l��������
            Color currentColor = lineRenderer.startColor; // LineRenderer�̊J�n�F���g�p
            currentColor.a = 1.0f - (timer / eraseTime);
            lineRenderer.startColor = currentColor;
            lineRenderer.endColor = currentColor; // �J�n�ƏI���̐F�𓯂��ɐݒ肷��ꍇ
        }
    }
}
