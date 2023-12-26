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
            .From() // From���\�b�h���g�p���Č��݂̈ʒu����̑��ΓI�ȍ��W�ړ����w��
            .SetEase(Ease.OutQuad)
            .OnComplete(() => MoveToPoint(targetPosition == startPoint.position ? endPoint.position : startPoint.position));
    }
}