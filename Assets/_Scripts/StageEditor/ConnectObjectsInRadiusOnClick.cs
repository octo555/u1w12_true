using System.Collections.Generic;
using UnityEngine;

public class ConnectObjectsInRadiusOnClick : MonoBehaviour
{
    public static ConnectObjectsInRadiusOnClick instance;

    public float radius = 5f; // �ڑ��͈͂̔��a
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

            // �}�E�X���N���b�N���ꂽ��
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody2D op = null;

                // �}�E�X�̃N���b�N�ʒu���擾
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // �N���b�N�ʒu���甼�aradius�̉~���ɑ��݂���Collider2D���擾
                Collider2D[] colliders = Physics2D.OverlapCircleAll(clickPosition, radius);

                // Collider2D�̐����J�E���g
                int colliderCount = 0;

                // �擾����Collider2D��SpringJoint2D��ǉ����Đڑ�
                foreach (Collider2D collider in colliders)
                {
                    // Rigidbody2D���A�^�b�`����Ă���ꍇ�̂ݏ������s��
                    Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        if (op != null && rb.gameObject != op.gameObject)
                        {
                            // SpringJoint2D��ǉ�
                            SpringJoint2D springJoint = collider.gameObject.AddComponent<SpringJoint2D>();


                            // SpringJoint2D�̐ݒ�
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

                        // Collider2D�̐���2�ɒB�����珈���I��
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