using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] float dampingTime;
    [SerializeField] Vector3 offset;

    private void FixedUpdate() 
    {
        Vector3 followPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, followPosition, dampingTime);
        transform.position = smoothPosition;
        // transform.LookAt(target);
    }
}
