using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePosition : MonoBehaviour
{

    public float radius = 0.5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(clickPosition, radius);

            foreach (Collider2D collider in hitColliders)
            {
                Vector3 offset = collider.transform.position - clickPosition;
                // �I�u�W�F�N�g�̐V�����ʒu��ݒ�
                collider.transform.position = clickPosition + offset;
            }
        }
    }
}
