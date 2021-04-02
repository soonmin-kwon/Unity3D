using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Transform target;
    private Vector3 cameraPosition;
    public Vector3 offset;
    public bool RotateAroundPlayer = true;
    
    void LateUpdate()
    {
        FixCam();
        Zoom();
        Rotate();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -0.1f * zoomSpeed;
        if (distance != 0 )
        {            
            offset.y += distance;
            offset.z += distance;
        }
    }

    private void FixCam()
    {
        cameraPosition.x = target.position.x + offset.x;
        cameraPosition.y = target.position.y + offset.y;
        cameraPosition.z = target.position.z + offset.z;

        transform.position = cameraPosition;
        transform.LookAt(target);
    }

    private void Rotate()
    {        
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetMouseButton(0))
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
            offset = camTurnAngle * offset;
            Vector3 newPos = target.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPos, .5f);
            transform.LookAt(target);
        }
    }
}
