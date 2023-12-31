using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointRenderer : MonoBehaviour
{
    public Transform opp;
    [SerializeField] LineRenderer line;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (opp != null)
        {

            var positions = new Vector3[]{
                transform.position,
                 opp.transform.position// 終了点
            };

            // 線を引く場所を指定する
            line.SetPositions(positions);
        }
    }
}
