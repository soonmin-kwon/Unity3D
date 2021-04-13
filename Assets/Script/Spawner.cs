using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn = 10f;
    private float timeSinceSpawn;
    [SerializeField] private Pool objectPool;
    [SerializeField] private int monsterMax;    
    
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn >= timeToSpawn)
        {   
            if(objectPool.maxGenerate < objectPool.poolStartSize)
            {
                GameObject newMonster = objectPool.GetObject();                
                newMonster.transform.position = this.transform.position;                
            }
            timeSinceSpawn = 0f;
        }
    }
}
