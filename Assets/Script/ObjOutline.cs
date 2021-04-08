using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOutline : MonoBehaviour
{
    [SerializeField] private Material mat;        

    public void OnMouseEnter()
    {
        mat.SetFloat("_Outline", 0.2f);
    }

    public void OnMouseExit()
    {
        mat.SetFloat("_Outline", 0.0f);
    }
    
}
