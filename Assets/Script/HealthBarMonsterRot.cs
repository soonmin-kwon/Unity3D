using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMonsterRot : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>().transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
