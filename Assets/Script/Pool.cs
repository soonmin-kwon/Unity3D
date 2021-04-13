using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject objPrefab;
    [SerializeField] private Queue<GameObject> objPool = new Queue<GameObject>();
    public int poolStartSize = 4;
    private float dyingTime;
    public int maxGenerate = 0;
    void Start()
    {
        for(int i=0; i< poolStartSize; i++)
        {
            GameObject obj = Instantiate(objPrefab,transform.position,Quaternion.identity);
            objPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        if (objPool.Count >0)
        {            
            GameObject obj = objPool.Dequeue();
            obj.SetActive(true);
            maxGenerate++;
            return obj;
        }
        else
        {
            Debug.Log("Instantiate");
            GameObject obj = Instantiate(objPrefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        objPool.Enqueue(obj);
        obj.SetActive(false);
        maxGenerate--;        
    }
}
