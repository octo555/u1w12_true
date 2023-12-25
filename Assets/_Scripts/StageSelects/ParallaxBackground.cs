using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParallaxBackground : MonoBehaviour
{
    public Transform[] backgrounds; // 背景レイヤーのTransformを格納する配列
    public float[] parallaxSpeeds; // 各背景レイヤーの移動速度
    public float resetPosition = -10f; // 背景をリセットする位置

    public Transform player; // プレイヤーオブジェクトのTransform
    private float[] backgroundWidths; // 背景の幅

    void Start()
    {

        // 背景の幅を取得
        backgroundWidths = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgroundWidths[i] = backgrounds[i].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        // プレイヤーのX座標に応じて背景をスクロールさせる
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float moveAmount = parallaxSpeeds[i] * Time.deltaTime;
            backgrounds[i].position += new Vector3(moveAmount, 0, 0);

            // 背景がリセット位置に達したら、元の位置に戻す
            if (backgrounds[i].position.x > resetPosition)
            {
                backgrounds[i].position -= new Vector3(backgroundWidths[i], 0, 0);
            }
        }
    }
}