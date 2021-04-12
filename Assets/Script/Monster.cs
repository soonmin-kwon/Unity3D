using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp;
    
    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject, .5f);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
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
