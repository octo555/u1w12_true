using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CamaraUI : MonoBehaviour
{
    public float sensitivity = 2.0f; // �}�E�X���x

    private float firstRotationY;

    private void Awake()
    {
        firstRotationY = transform.localRotation.y;
    }

    private void Update()
    {
        if (UIManager.instance.canStageMove)
        {
            // �}�E�X�J�[�\���̈ʒu���擾
            Vector3 mousePosition = Input.mousePosition;

            // �X�N���[���̒��S���W���v�Z
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

            // �}�E�X�J�[�\���ƃX�N���[���̒��S�Ƃ̍������v�Z
            Vector3 distanceFromCenter = mousePosition - screenCenter;

            transform.rotation = Quaternion.Euler(0f, distanceFromCenter.x * sensitivity, 0f);
        }
    }
}
