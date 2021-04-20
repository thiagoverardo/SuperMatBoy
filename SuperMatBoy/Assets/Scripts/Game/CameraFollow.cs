using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;
    public PlayerController pc;
    public Vector3 minValues, maxValue;

    void LateUpdate()
    {
        if(pc.moving){
            Vector3 desiredPosition = target.position + offset;
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(desiredPosition.x, minValues.x, maxValue.x),
                Mathf.Clamp(desiredPosition.y, minValues.y, maxValue.y),
                Mathf.Clamp(desiredPosition.z, minValues.z, maxValue.z));
            Vector3 smoothedPos = Vector3.Lerp(transform.position, boundPosition, smoothSpeed);
            transform.position = smoothedPos;
        }   
    }
}