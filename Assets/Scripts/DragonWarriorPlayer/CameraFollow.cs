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
        Vector3 smoothPosition = dampingTime != 0 ? Vector3.Lerp(transform.position, followPosition, dampingTime): followPosition;
        // Debug.Log(smoothPosition);
        transform.position = smoothPosition;
        // transform.LookAt(target);
    }
}
