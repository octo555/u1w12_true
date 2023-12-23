using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipStage : MonoBehaviour
{
    public Vector3 flipCenter = Vector3.zero; // 上下反転の中心点
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
            // 子オブジェクトの位置を中心点を基準に上下反転させる
            Vector3 relativePosition = child.position - flipCenter;
            relativePosition.x = -relativePosition.x;
            child.position = flipCenter + relativePosition;

            // SpriteRendererがアタッチされていれば上下反転させる
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            // 再帰的に子オブジェクトの子も調整
            FlipY(child);
        }
    }

    private void FlipY(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // 子オブジェクトの位置を中心点を基準に上下反転させる
            Vector3 relativePosition = child.position - flipCenter;
            relativePosition.y = -relativePosition.y;
            child.position = flipCenter + relativePosition;

            // SpriteRendererがアタッチされていれば上下反転させる
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = !spriteRenderer.flipY;
            }

            // 再帰的に子オブジェクトの子も調整
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
