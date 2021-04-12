using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Collider[] player;
    [SerializeField] private Animator anim;
    private Vector3 initPos;
    [SerializeField] private LayerMask targetMask;    

    public enum State
    {
        Idle,
        BattleIdle,
        Chase,
        Reset,
        Attack
    }
    public State state = State.Idle;
    float timer;
    private void Start()
    {
        initPos = transform.position;
    }
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                IdleState();
                break;
            case State.BattleIdle:
                BattleIdleState();
                break;
            case State.Chase:
                ChasePlayer();
                break;
            case State.Reset:
                ResetEnemy();
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }
    }

    void IdleState()
    {
        //anim.SetBool("Attack", false);
        if (Physics.OverlapSphereNonAlloc(initPos, 10f, player, targetMask) >= 1)
        {
            state = State.Chase;
            anim.SetBool("Walk", true);
        }
        
    }
    void ResetEnemy()
    {
        if (Vector3.Distance(initPos, transform.position) <= 1f)
        {
            state = State.Idle;
            anim.SetBool("Walk", false);
            return;
        }
        enemy.SetDestination(initPos);
    }

    void ChasePlayer()
    {
        if (Vector3.Distance(initPos, transform.position) >= 10f)
        {
            state = State.Reset;
            return;
        }
        
        /*if (Vector2.Distance(player[0].transform.position, transform.position) <= 2f)
        {
            state = State.Attack;            
            return;
        }*/
        enemy.SetDestination(player[0].transform.position);
    }

    void AttackPlayer()
    {
        anim.SetBool("Attack",true);
        anim.SetBool("Attack", false);
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 0.0f;
            enemy.isStopped = false;
            anim.SetTrigger("Idle");
            state = State.Idle;
        }               

    }

    void BattleIdleState()
    {
        anim.SetBool("Attack", false);
        if (Vector2.Distance(player[0].transform.position, transform.position) <= 2f)
        {
            state = State.Attack;
            return;
        }

        if (Vector3.Distance(initPos, transform.position) >= 10f)
        {
            anim.SetTrigger("Idle");
            state = State.Reset;
            return;
        }

    }
}