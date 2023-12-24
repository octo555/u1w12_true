using System.Collections.Generic;
using UnityEngine;

public class ConnectObjectsInRadiusOnClick : MonoBehaviour
{
    public static ConnectObjectsInRadiusOnClick instance;

    public float radius = 5f; // 接続範囲の半径
    public float springForce = Mathf.Infinity;
    public Transform circle;
    public bool orConnect;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ConnectOn()
    {
        orConnect = true;
        circle.gameObject.SetActive(true);
    }

    void Update()
    {
        if (orConnect)
        {
            circle.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

            // マウスがクリックされたら
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody2D op = null;

                // マウスのクリック位置を取得
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // クリック位置から半径radiusの円内に存在するCollider2Dを取得
                Collider2D[] colliders = Physics2D.OverlapCircleAll(clickPosition, radius);

                // Collider2Dの数をカウント
                int colliderCount = 0;

                // 取得したCollider2DにSpringJoint2Dを追加して接続
                foreach (Collider2D collider in colliders)
                {
                    // Rigidbody2Dがアタッチされている場合のみ処理を行う
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        if (op != null && rb.gameObject != op.gameObject)
                        {
                            // SpringJoint2Dを追加
                            SpringJoint2D springJoint = collider.gameObject.AddComponent<SpringJoint2D>();


                            // SpringJoint2Dの設定
                            //springJoint.connectedAnchor = Vector2.zero;
                            springJoint.connectedBody = op;
                            //springJoint.distance = 0;
                            //springJoint.autoConfigureDistance = false;
                            springJoint.enableCollision = true;
                            SEManager.instance.PlaySE(1);
                            rb.gameObject.GetComponent<JointRenderer>().opp = op.transform;
                        }
                        
                        op = rb;
                            

                        colliderCount++;

                        // Collider2Dの数が2つに達したら処理終了
                        if (colliderCount >= 2)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}