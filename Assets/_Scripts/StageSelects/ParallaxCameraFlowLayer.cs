using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����X�N���[���p�̃��C���[�ɐݒ肷��X�N���v�g
public class ParallaxCameraFlowLayer : MonoBehaviour
{
    // �Ǐ]�Ώۂ̃J����
    [SerializeField] Transform _cameraTransfrom;
    // �J�����ɒǏ]������x(1: �J�����Ɠ����ړ��� 0: �ړ����Ȃ�)
    [SerializeField] float _followFactor;

    Vector3 _previousCameraPos;

    private void Update()
    {
        Vector3 currentPos = _cameraTransfrom.position;
        var deltaPos = currentPos - _previousCameraPos;
        _previousCameraPos = currentPos;
        var calcedPos = deltaPos * _followFactor;
        transform.AddLocalPos((Vector2)calcedPos);
    }
}

// ���[�e�B���e�B
public static class ParallaxCameraFlowLayerExtensions
{
    public static void AddLocalPos(this Transform self, in Vector2 pos)
    {
        Vector3 vec = self.localPosition;
        vec.x += pos.x;
        vec.y += pos.y;
        self.localPosition = vec;
    }
}
