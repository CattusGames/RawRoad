using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraFollow : MonoBehaviour
{
    //The target object
    public Transform targetObject;

    //Default distance between the target and the player.
    public Vector3 cameraOffset;

    public float smoothFactor = 0.5f;

    //This will check if the camera looks at the target or not.
    public bool lookAtTarget = false;

    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }
    void FixedUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        
        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }

}
