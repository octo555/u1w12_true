using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform ima;
    public Camera m_Camera;
    public bool inZoom = false;

    public void MoveToIma()
    {
        transform.DOMove(new Vector3(ima.position.x,ima.position.y,-10), speed);
        inZoom = true;
        OnFoVChange();
    }

    public void MoveToKiza()
    {
        transform.DOMove(new Vector3(23.1f, -30, -10), speed);
        inZoom = true;
        OnFoVChange();
    }

    public float FoVTarget = 145;
    public float DefaultFoV;

    void Start()
    {
        m_Camera = GetComponentInChildren<Camera>();
        DefaultFoV = m_Camera.fieldOfView;
    }

    void LateUpdate()
    {
        ZoomControl();
    }

    /// <summary>
    /// ズーム処理
    /// </summary>
    void ZoomControl()
    {
        if (inZoom)
        {
            m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, FoVTarget, Time.deltaTime * 2);
        }
        else
        {
            m_Camera.fieldOfView = Mathf.Lerp(m_Camera.fieldOfView, DefaultFoV, Time.deltaTime * 4);
        }
    }

    /// <summary>
    /// FoC変更
    /// </summary>
    void OnFoVChange()
    {
        StartCoroutine(DoZoomEffect(1.2f));
    }


    /// <summary>
    /// ズームエフェクト
    /// </summary>
    /// <returns></returns>
    IEnumerator DoZoomEffect(float duration)
    {
        inZoom = true;
        yield return new WaitForSeconds(duration);
        inZoom = false;
    }
}
