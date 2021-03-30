using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;

    [SerializeField]
    private Camera mainCamera;
    
    void Update()
    {
        Zoom();
        Rotate();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance != 0)
        {
            mainCamera.fieldOfView += distance;
        }
    }

    private void Move()
    {
        
    }
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rot.y += Input.GetAxis("Mouse X") * (rotateSpeed); // 마우스 X 위치 * 회전 스피드            
            Quaternion q = Quaternion.Euler(rot); // Quaternion으로 변환
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        }
    }
}
