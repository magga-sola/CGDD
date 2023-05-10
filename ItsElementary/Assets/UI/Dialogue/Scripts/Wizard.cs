using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public Dialogue dialogue;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
