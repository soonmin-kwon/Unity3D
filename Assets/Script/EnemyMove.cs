using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Collider[] player;
    private Vector3 initPos;
    [SerializeField] private LayerMask targetMask;
    int targetLength;

    enum State
    {
        Idle,
        Chase,
        Reset
    }
    State state = State.Idle;
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
            case State.Chase:
                ChasePlayer();
                break;
            case State.Reset:
                ResetEnemy();
                break;
        }        
    }

    void IdleState()
    {
        if (Physics.OverlapSphereNonAlloc(initPos, 5f, player, targetMask) >= 1)
        {
            state = State.Chase;
        }
    }
    void ResetEnemy()
    {
        if(Vector3.Distance(initPos, transform.position ) <= 1f)
        {
            state = State.Idle;
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
        enemy.SetDestination(player[0].transform.position);
    }
}
