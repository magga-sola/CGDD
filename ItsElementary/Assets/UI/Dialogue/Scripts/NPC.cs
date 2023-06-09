using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class NPC : MonoBehaviour
{
    public string npcName;
    [TextArea(3, 10)]
    public string[] sentences;

    public UnityAction<Collider2D> secondListener;

    public UnityEvent<Collider2D> dialogueTrigger;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            if(dialogueTrigger != null)
            {
                dialogueTrigger.Invoke(col);
                
            }
        }
    }
}
