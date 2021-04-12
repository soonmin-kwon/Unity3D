using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuging : MonoBehaviour
{
    [SerializeField] private EnemyMove enemy;
    [SerializeField] private Text text;

    void LateUpdate()
    {
        text.text = "State : " + enemy.state;
    }
    
}

