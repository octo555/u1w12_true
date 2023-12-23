using UnityEngine;

public class MouseCursorDetection : MonoBehaviour
{
    // 画面中央に近づいたとみなす範囲
    public float detectionThreshold = 50f;

    void Update()
    {
        // マウスカーソルのX座標を取得
        float mouseX = Input.mousePosition.x;

        // 画面中央のX座標を計算
        float centerX = Screen.width / 2;

        // マウスカーソルが画面中央に近づいたかどうかを確認
        if (Mathf.Abs(mouseX - centerX) < detectionThreshold)
        {
            // 画面中央に近づいたときの処理を呼び出す
            OnMouseCursorNearCenter();
        }
    }

    // 画面中央に近づいたときの処理
    void OnMouseCursorNearCenter()
    {
        UIManager.instance.canStageMove = true;
    }
}
