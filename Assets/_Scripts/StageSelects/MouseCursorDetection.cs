using UnityEngine;

public class MouseCursorDetection : MonoBehaviour
{
    // ��ʒ����ɋ߂Â����Ƃ݂Ȃ��͈�
    public float detectionThreshold = 50f;

    void Update()
    {
        // �}�E�X�J�[�\����X���W���擾
        float mouseX = Input.mousePosition.x;

        // ��ʒ�����X���W���v�Z
        float centerX = Screen.width / 2;

        // �}�E�X�J�[�\������ʒ����ɋ߂Â������ǂ������m�F
        if (Mathf.Abs(mouseX - centerX) < detectionThreshold)
        {
            // ��ʒ����ɋ߂Â����Ƃ��̏������Ăяo��
            OnMouseCursorNearCenter();
        }
    }

    // ��ʒ����ɋ߂Â����Ƃ��̏���
    void OnMouseCursorNearCenter()
    {
        UIManager.instance.canStageMove = true;
    }
}
