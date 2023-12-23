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
            // �}�E�X�J�[�\���̈ʒu���擾
            Vector3 mousePosition = Input.mousePosition;

            // �X�N���[���̒��S���W���v�Z
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);

            // �}�E�X�J�[�\���ƃX�N���[���̒��S�Ƃ̍������v�Z
            Vector3 distanceFromCenter = mousePosition - screenCenter;

            transform.localPosition = new Vector3(firstPosX + distanceFromCenter.x * _followFactor * UIManager.instance.scrollBairitu, transform.localPosition.y, 0);
        }
    }
}
