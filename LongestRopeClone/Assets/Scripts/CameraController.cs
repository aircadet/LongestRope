using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offSet;
    [SerializeField] bool lookAt;

    private void Update()
    {
        if (lookAt) 
        {
            transform.LookAt(target);
        }
        transform.position = Vector3.Lerp(transform.position, target.position-offSet, .5f);
    }
}
