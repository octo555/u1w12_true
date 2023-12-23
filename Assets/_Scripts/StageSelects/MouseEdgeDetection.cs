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
        // �}�E�X�̃X�N���[�����W���擾
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // ��ʒ[�͈̔͂��w��
        edgeThreshold = Screen.width / 60f; // ��ʒ[����̋����i�s�N�Z���j

        // ���[�܂��͉E�[�ɂ��邩�ǂ����𔻒�
        bool isOnLeftEdge = mousePosition.x < edgeThreshold;
        bool isOnRightEdge = mousePosition.x > Screen.width - edgeThreshold;

        // �J�[�\�������[�܂��͉E�[�ɂ��邩�ǂ������m�F
        if (isOnLeftEdge || isOnRightEdge)
        {
            // 臒l�𒴂����珈�������s
            if (!isCursorOnEdge && tien == false) //tien == false�͋C�ɂ��Ȃ���
            {
                // �ǂ���̉�ʒ[�ɂ��邩��\��
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
                isCursorOnEdge = true; // �d�����Ď��s���Ȃ��悤�Ƀt���O��ݒ�
            }
        }
        else
        {
            isCursorOnEdge = false;
        }
    }
}