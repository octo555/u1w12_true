using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateStamp : MonoBehaviour
{

    [SerializeField] GameObject[] stamps;
    [SerializeField] Image showingImage;
    [SerializeField] Transform objects;
    private bool orReadyStamp = false;
    private GameObject currentObject;

    public void ReadyStamp(int index)
    {
        StartCoroutine(DelayStamp(index));
    }

    IEnumerator DelayStamp(int index)
    {
        yield return new WaitForSeconds(0.05f);

        currentObject = stamps[index];
        showingImage.transform.gameObject.SetActive(true);
        showingImage.sprite = stamps[index].GetComponent<SpriteRenderer>().sprite;
        orReadyStamp = true;
    }

    private void Update()
    {
        var c = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        showingImage.transform.position = new Vector3(c.x, c.y, 0);
        if (orReadyStamp && Input.GetMouseButtonDown(0))
        {
            var go = Instantiate(currentObject, new Vector3(c.x, c.y, 0), Quaternion.identity);
            go.transform.parent = objects;
            if (transform.GetComponent<StopTime>().isPaused)
            {
                if (go.GetComponent<Rigidbody2D>())
                {
                    go.GetComponent<Rigidbody2D>().isKinematic = true;
                    go.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }

            if (currentObject == stamps[1])
                ConnectBallon(go);

            currentObject = null;
            showingImage.transform.gameObject.SetActive(false);
            orReadyStamp = false;
        }
    }

    private void ConnectBallon(GameObject go)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        // Rayが何かに当たったか確認
        if (hit.collider != null)
        {
            // 当たったオブジェクトがRigidbody2Dを持っているか確認
            Rigidbody2D hitRigidbody = hit.collider.GetComponent<Rigidbody2D>();
            if (hitRigidbody != null)
            {
                go.GetComponent<FixedJoint2D>().enabled = true;
                go.GetComponent<FixedJoint2D>().connectedBody = hitRigidbody;
            }
        }
    }
}
