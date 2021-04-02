using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public PlayerController pc;

    void LateUpdate()
    {
        if(pc.moving){
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPos;
        }   
    }
}
