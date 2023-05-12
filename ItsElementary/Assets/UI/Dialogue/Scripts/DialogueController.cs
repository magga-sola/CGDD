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
            nameComponent.text = npc.npcName;
            
            if(!isFinished) 
            {
                Debug.Log("name: "+ npc.npcName);
                //nameComponent.text = npc.npcName;
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

    IEnumerator TypeLine()
    {
        char[] newArray = lines[index].ToCharArray();
        for (int i = 0; i < (newArray.Length); i++)
        {
            if (newArray[i] == '<')
            {
                if (newArray[i+1] == 'b')
                {
                    //<b>
                    textComponent.text += newArray[i];
                    textComponent.text += newArray[i+1];
                    textComponent.text += newArray[i+2];
                    i = i + 2;
                    yield return new WaitForSeconds(textSpeed);

                } else 
                {
                    // </b>
                    textComponent.text += newArray[i];
                    textComponent.text += newArray[i+1];
                    textComponent.text += newArray[i+2];
                    textComponent.text += newArray[i+3];
                    i = i + 3;
                    yield return new WaitForSeconds(textSpeed);
                }
            } else 
            {
                textComponent.text += newArray[i];
                yield return new WaitForSeconds(textSpeed);
            }
        }
    }

    void NextLine()
    {
        if(index < (lines.Length - 1))
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        } else
        {
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
