using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float CameraDamp;

    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = target.position.x;
        temp.y = target.position.y;

        transform.position = Vector3.Lerp(transform.position, temp + offset, CameraDamp * Time.deltaTime);
    }
}
