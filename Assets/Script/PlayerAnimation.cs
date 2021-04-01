using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private NavMeshAgent player;

    private void Update()
    {
        MoveAnim();
    }

    void MoveAnim()
    {
        if (player.hasPath)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
