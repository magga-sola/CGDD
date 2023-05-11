using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    
    //public DialogueManager dialogueManager;
    //public Dialogue dialogue;
    //public DialogueController dialogueController;
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

    public UnityEvent<Collider2D> dialogueTrigger;
    //public UnityEvent<Collider> onTriggerEnter2D;
 

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("here");
        if (col.gameObject.name.Contains("Player"))
        {
            if(dialogueTrigger != null)
            {
                dialogueTrigger.Invoke(col);
            }
            //dialogueController.StartDialogue(this);
        }
    }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [System.Serializable]
// public class Dialogue : MonoBehaviour
// {
//     public string name;
//     [TextArea(3, 10)]
//     public string[] sentences;


// }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ProcessInput();
    }

}
