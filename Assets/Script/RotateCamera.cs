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
    void LateUpdate()
    {
        FixCam();
        Zoom();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0 )
        {            
            mainCamera.fieldOfView += distance;
        }
    }

    private void FixCam()
    {
        cameraPosition.x = target.position.x;
        cameraPosition.y = target.position.y + 5f;
        cameraPosition.z = target.position.z + (-4.5f);

        transform.position = cameraPosition;
        transform.LookAt(target);
    }
}
