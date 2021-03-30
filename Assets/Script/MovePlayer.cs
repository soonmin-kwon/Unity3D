using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float speed = 5.0f;
    [SerializeField]
    private Camera camera;
    Transform dir;
    void Awake()
    {
        dir = camera.transform;
    }
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(dir.right * Time.deltaTime * speed * horizontal, Space.World);
        transform.Translate(dir.forward * Time.deltaTime * speed * vertical, Space.World);
    }
}
