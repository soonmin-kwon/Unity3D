using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovePlayer : MonoBehaviour
{    
    public NavMeshAgent agent;
    RaycastHit hit;
    Ray ray;
    [SerializeField] private GameObject effect;
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);                
                ClickEffect(hit.point);                
            }                
        }
    }

    void ClickEffect(Vector3 pos)
    {
        Instantiate(effect, pos, Quaternion.identity);
    }
}
