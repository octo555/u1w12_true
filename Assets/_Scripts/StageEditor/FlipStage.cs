using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipStage : MonoBehaviour
{
    public Vector3 flipCenter = Vector3.zero; // �㉺���]�̒��S�_
    [SerializeField] Camera _camera;
    [SerializeField] Transform objects;
    [SerializeField] Transform mask;

    private bool isFlipHorizontal = false;
    private bool isFlipVertical = false;

    public UnityEvent gravityResetEvent;

    Vector3 flipYRotaion = new Vector3(0, 0, -180);
    Vector3 flipYPosition = new Vector3(4.8f, -0.65f, -10);

    private void FlipX(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // �q�I�u�W�F�N�g�̈ʒu�𒆐S�_����ɏ㉺���]������
            Vector3 relativePosition = child.position - flipCenter;
            relativePosition.x = -relativePosition.x;
            child.position = flipCenter + relativePosition;

            // SpriteRenderer���A�^�b�`����Ă���Ώ㉺���]������
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            // �ċA�I�Ɏq�I�u�W�F�N�g�̎q������
            FlipY(child);
        }
    }

    private void FlipY(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // �q�I�u�W�F�N�g�̈ʒu�𒆐S�_����ɏ㉺���]������
            Vector3 relativePosition = child.position - flipCenter;
            relativePosition.y = -relativePosition.y;
            child.position = flipCenter + relativePosition;

            // SpriteRenderer���A�^�b�`����Ă���Ώ㉺���]������
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = !spriteRenderer.flipY;
            }

            // �ċA�I�Ɏq�I�u�W�F�N�g�̎q������
            FlipY(child);
        }

        gravityResetEvent.Invoke();
    }
    public void FlipHorizontal()
    {
        FlipX(objects);
    }

    public void FlipVertical()
    {
        FlipY(objects);
    }
}
