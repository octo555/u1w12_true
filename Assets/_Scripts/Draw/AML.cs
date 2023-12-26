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
                // 次のウェイポイントの位置を取得
                Vector3 targetPosition = lineRenderer.GetPosition(currentWaypointIndex);

                // キャラクターをウェイポイントに向かって移動
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // ウェイポイントに十分に近づいたら次のウェイポイントへ
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
            currentWaypointIndex = 0; // ウェイポイントのインデックスをリセット
        }

        Debug.Log("ontrigger");
    }
}