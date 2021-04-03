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
    [SerializeField] private Animator anim;
    int comboStep = 0;
    bool comboPossible;
    void Update()
    {
        PlayerMove();
        PlayerAttack();
        Reset();
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
    
    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(comboStep == 0)
            {
                anim.SetInteger("Combo_1", 1);
                comboStep = 1;
            }
            else
            {
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                {
                    anim.SetInteger("Combo_1", 2);                 
                }                
            }
        }
    }

    public void Reset()
    {
        if (anim.GetAnimatorTransitionInfo(0).IsName("Attack1 -> Idle"))
        {
            comboStep = 0;
            anim.SetInteger("Combo_1", 0);
        }

        if (anim.GetAnimatorTransitionInfo(0).IsName("Attack2 -> Idle"))
        {
            comboStep = 0;
            anim.SetInteger("Combo_1", 0);
        }
    }
}
