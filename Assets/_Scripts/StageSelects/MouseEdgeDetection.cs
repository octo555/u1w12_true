using UnityEngine;
using UnityEngine.InputSystem;

public class MouseEdgeDetection : MonoBehaviour
{
    public float edgeThreshold = 20f;
    private bool isCursorOnEdge = false;
    private bool tien = true;

    private void Awake()
    {
        Invoke("Tien",1f);
    }

    void Tien()
    {
        tien = false;
    }

    void Update()
    {
        // マウスのスクリーン座標を取得
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // 画面端の範囲を指定
        edgeThreshold = Screen.width / 60f; // 画面端からの距離（ピクセル）

        // 左端または右端にいるかどうかを判定
        bool isOnLeftEdge = mousePosition.x < edgeThreshold;
        bool isOnRightEdge = mousePosition.x > Screen.width - edgeThreshold;

        // カーソルが左端または右端にいるかどうかを確認
        if (isOnLeftEdge || isOnRightEdge)
        {
            // 閾値を超えたら処理を実行
            if (!isCursorOnEdge && tien == false) //tien == falseは気にしないで
            {
                // どちらの画面端にいるかを表示
                if (isOnLeftEdge && UIManager.instance.currentStageNumber != 2)
                {
                    UIManager.instance.currentStageNumber++;
                    UIManager.instance.ChangeStageEffect();
                }
                if (isOnRightEdge && UIManager.instance.currentStageNumber != 0)
                {
                    UIManager.instance.currentStageNumber--;
                    UIManager.instance.ChangeStageEffect();
                }
                isCursorOnEdge = true; // 重複して実行しないようにフラグを設定
            }
        }
        else
        {
            isCursorOnEdge = false;
        }
    }
}