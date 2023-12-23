using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxUI : MonoBehaviour
{
    [SerializeField] float _followFactor;

    private float firstPosX;

    private void Awake()
    {
        firstPosX = transform.localPosition.x;
    }

    private void Update()
    {
        if (UIManager.instance.canStageMove)
        {
            // マウスカーソルの位置を取得
            Vector3 mousePosition = Input.mousePosition;

            // スクリーンの中心座標を計算
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

            // マウスカーソルとスクリーンの中心との差分を計算
            Vector3 distanceFromCenter = mousePosition - screenCenter;

            transform.localPosition = new Vector3(firstPosX + distanceFromCenter.x * _followFactor * UIManager.instance.scrollBairitu, transform.localPosition.y, 0);
        }
    }
}
