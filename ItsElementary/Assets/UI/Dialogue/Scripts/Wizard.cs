using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    //public DialogueManager dialogueManager;
    //public Dialogue dialogue;
    public DialogueController dialogueController;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            dialogueController.StartDialogue();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ProcessInput();
    }

}
