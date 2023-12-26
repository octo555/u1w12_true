using UnityEngine;
using DG.Tweening;

public class TwoPoint : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration = 2f;

    void Start()
    {
        MoveToPoint(endPoint.position);
    }

    void MoveToPoint(Vector3 targetPosition)
    {
        transform.DOMove(targetPosition, duration)
            .From() // Fromメソッドを使用して現在の位置からの相対的な座標移動を指定
            .SetEase(Ease.OutQuad)
            .OnComplete(() => MoveToPoint(targetPosition == startPoint.position ? endPoint.position : startPoint.position));
    }
}