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
    bool isRunning;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        PlayerMove();
        MoveAnim();
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
            agent.enabled = false;
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
        agent.enabled = true;
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

    void MoveAnim()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;            
        }

        anim.SetBool("Run", isRunning);
    }
}
