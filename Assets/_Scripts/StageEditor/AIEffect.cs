using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AIEffect : MonoBehaviour
{
    public float tForce;
    public int AIModeNumber = -1;



    private void Update()
    {
        if(AIModeNumber != -1 && Input.GetMouseButtonDown(0))
        {
            GameObject go = null;
            go = SearchRBObject();

            if (go != null)
            {
                SEManager.instance.PlaySE(1);

                switch (AIModeNumber)
                {
                    case 0:
                        ToBig(go);
                        break;
                    case 1:
                        ToSmall(go);
                        break;
                    case 2:
                        ToTorque(go);
                        break;
                    case 3:
                        PinClip(go);
                        break;
                    case 4:
                        EraseObject(go);
                        break;

                }
            }
        }
    }


    public void ChangeAIModeNubmer(int index)
    {
        AIModeNumber = index;
    }

    private void ToBig(GameObject g)
    {
        var s = g.transform.localScale;
        g.transform.localScale = new Vector2(s.x * 1.5f, s.y * 1.5f);
    }

    private void ToSmall(GameObject g)
    {
        var s = g.transform.localScale;
        g.transform.localScale = new Vector2(s.x * 0.75f, s.y * 0.75f);

    }

    private void ToTorque(GameObject g)
    {
        g.GetComponent<TorqueForce>().torqueForce -= tForce;
    }

    private void PinClip(GameObject g)
    {
        g.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void EraseObject(GameObject g)
    {
        Destroy(g);
    }


    private GameObject SearchRBObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayRadius = 0.5f;  // 円状Rayの半径

        // CircleCastで円状のRayを飛ばす
        RaycastHit2D hit = Physics2D.CircleCast(ray.origin, rayRadius, ray.direction);

        // Rayが何かに当たったか確認
        if (hit.collider != null)
        {
            // 当たったオブジェクトがRigidbody2Dを持っているか確認
            Rigidbody2D hitRigidbody = hit.collider.GetComponent<Rigidbody2D>();
            if (hitRigidbody != null)
            {
                return hitRigidbody.gameObject;
            }
        }

        return null;
    }
}
