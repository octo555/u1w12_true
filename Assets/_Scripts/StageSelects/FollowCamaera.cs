using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamaera : MonoBehaviour
{
    [SerializeField] private Transform playrTransform;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    public float depth;
    private void Update()
    {
        transform.position = new Vector3(playrTransform.position.x + xOffset, 0 + yOffset, depth);
    }
}
