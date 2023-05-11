using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;

    private NPC npc;
    private string[] lines;
    private string name;
    public float textSpeed;
    private int index;
    private bool isFinished;
    public PlayerController player;

    //private UnityAction<Collider2D> onTheOtherTriggerEnterMethod;
    
    void Start()
    {
        //npc = GameObject.Find("NPC").GetComponent<NPC>();

        gameObject.SetActive(false);
        textComponent.text = string.Empty;
        //npc.dialogueTrigger.AddListener(testListener);
    }

    public void StartDialogue(NPC npc)
    {
        gameObject.SetActive(true);
        player.Pause();

        if(!isFinished) 
        {
            nameComponent.text = npc.name;
            index = 0;
            lines = npc.sentences;
            StartCoroutine(TypeLine());
        }

    } 
     void testListener(Collider2D col)
    {
        Debug.Log("hello");
        if(col.gameObject.name == "Player")
        {
            //StartDialogue(npc);
            Debug.Log("Start Dialogue");
        }
             
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
            textComponent.text = lines[index];
            isFinished = true;
            gameObject.SetActive(false);
            player.UnPause();
        }

    }

    // Update is called once per frame
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
