using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp;
    private Pool objectPool;
    [SerializeField] Monster monster;
    [SerializeField] Animator anim;
    [SerializeField] EnemyMove enemy;
    float dyingTime;
    [SerializeField] private float reGenSec = 1.3f;
    // Update is called once per frame
    private void Awake()
    {
        objectPool = FindObjectOfType<Pool>();
        anim = GetComponent<Animator>();
    }    

    void Update()
    {
        if (hp <= 0)
        {
            anim.SetTrigger("Die");
            dyingTime += Time.deltaTime;
            if (dyingTime >= reGenSec)
            {                
                objectPool.ReturnObject(this.gameObject);
                anim.SetTrigger("Idle");
                hp = 50;
                dyingTime = 0.0f;
                anim.ResetTrigger("Attack");
                enemy.state = EnemyMove.State.Idle;
            }            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            anim.SetTrigger("Hit");
            Debug.Log(hp);
            hp -= 10;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Debug.Log(hp);
            hp -= 10;
        }
    }

}
