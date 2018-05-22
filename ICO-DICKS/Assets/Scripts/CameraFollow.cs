using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public int targetType;

    void FixedUpdate()
    {
        if(targetType == 1)
        {
            target = FindObjectOfType<PlayerController1>().transform;
        }

        if (targetType == 2)
        {
            target = FindObjectOfType<PlayerController2>().transform;
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}