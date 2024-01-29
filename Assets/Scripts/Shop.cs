using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    float oCash = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddOCash(float cashToAdd)
    {
        oCash += cashToAdd;
        Debug.Log(oCash.ToString());
    }
}
