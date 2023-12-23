using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CamaraUI : MonoBehaviour
{
    public float sensitivity = 2.0f; // マウス感度

    private float firstRotationY;

    private void Awake()
    {
        firstRotationY = transform.localRotation.y;
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

            transform.rotation = Quaternion.Euler(0f, distanceFromCenter.x * sensitivity, 0f);
        }
    }
}
