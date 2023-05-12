using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.Events;
using TMPro;
public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public string[] lines;
    public string npcName;
    public float textSpeed;
    private int index;
    private bool isFinished;
    //public PlayerController player;

    private GameObject npc;
    NPC npcController;
    EnemyController enemyController;

    public UnityEvent onFinished;

    void Start()
    {
   
        if (GameObject.FindWithTag("NPC").TryGetComponent(out NPC script))
        {
            // FIND NPC GAMEOBJECT AND LISTEN IN ON DIALOGUE TRIGGER
            
            npcController = GameObject.FindWithTag("NPC").GetComponent<NPC>();
            //npcController.dialogueTrigger.AddListener(DialogueTrigger);

            //enemyController = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
            //enemyController.onEnemyDeath.AddListener(SecondDialogueTrigger);

        } 

        // INITIALIZE THE PANEL
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
        nameComponent.text = string.Empty;
    }

    public void StartDialogue(NPC npc)
    {
        if (this != null){
            gameObject.SetActive(true);
            GameManager.instance.player.Pause();
            
            if(!isFinished) 
            {
                nameComponent.text = npc.name;
                index = 0;
                lines = npc.sentences;
                StartCoroutine(TypeLine());
            }
        }
    } 

     public void DialogueTrigger(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            StartDialogue(npcController);
        }
             
    }

    public void SecondDialogueTrigger()
    {
        Debug.Log("Wow! good job!");
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        } else
        {
            if (onFinished != null) { onFinished.Invoke();}
            textComponent.text = lines[index];
            isFinished = true;
            gameObject.SetActive(false);
            GameManager.instance.player.UnPause();
            
        }

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        
    }
}
