using UnityEngine;

public class AML : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 5f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (lineRenderer != null)
        {
            if (currentWaypointIndex < lineRenderer.positionCount)
            {
                // ���̃E�F�C�|�C���g�̈ʒu���擾
                Vector3 targetPosition = lineRenderer.GetPosition(currentWaypointIndex);

                // �L�����N�^�[���E�F�C�|�C���g�Ɍ������Ĉړ�
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // �E�F�C�|�C���g�ɏ\���ɋ߂Â����玟�̃E�F�C�|�C���g��
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    currentWaypointIndex++;
                }
            }
            else
            {
                lineRenderer = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LineRenderer collidedLineRenderer = collision.gameObject.GetComponent<LineRenderer>();
        if (collidedLineRenderer != null)
        {
            lineRenderer = collidedLineRenderer;
            currentWaypointIndex = 0; // �E�F�C�|�C���g�̃C���f�b�N�X�����Z�b�g
        }

        Debug.Log("ontrigger");
    }
}