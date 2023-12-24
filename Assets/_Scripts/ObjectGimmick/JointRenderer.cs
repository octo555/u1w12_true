using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
                 opp.transform.position// I—¹“_
            };

            // ü‚ğˆø‚­êŠ‚ğw’è‚·‚é
            line.SetPositions(positions);
        }
    }
}
