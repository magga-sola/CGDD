using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room0 : MonoBehaviour
{
    public NPC npc;
    public DialogueController dialogueController;

    UnityEvent<Collider2D> firstTrigger;
    UnityEvent onFinished;
    GameObject[] enemies;
    public int enemyLength;
    public int updatedEnemyList;



    // Start is called before the first frame update
    void Start()
    {
        //GameObject newWizard = GameObject.Find("Wizard2");
        //newWizard.SetActive(false);

        
        firstTrigger = npc.dialogueTrigger;
        firstTrigger.AddListener(dialogueController.DialogueTrigger);

        onFinished = dialogueController.onFinished;
        onFinished.AddListener(objectiveCompleted);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyLength = 14;

    }

    void objectiveCompleted()
    {
        if (enemyLength > updatedEnemyList) {

            // GameObject newWizard = GameObject.Find("Wizard2");
            // GameObject oldWizard = GameObject.Find("Wizard1");
            // npc = newWizard.GetComponent<NPC>();
            // Destroy(oldWizard);

        }
    }

    // Update is called once per frame
    void Update()
    {
        updatedEnemyList = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
