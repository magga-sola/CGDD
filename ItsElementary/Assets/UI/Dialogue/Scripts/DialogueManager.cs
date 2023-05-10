using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public PlayerController player;
    //public Text nameText;
    //public Text dialogueText;
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;

    public bool isInDialogue;
    public bool finishedDialogue;
    
    
    void Start()
    {
        //gameObject.SetActive(false);
        sentences = new Queue<string>();
        //player = GameManager.instance.player.transform;
        //nameText = 
        //dialogueText.text = string.Empty;
    }

        void Update()
    {
        ProcessInput();
        gameObject.SetActive(isInDialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        isInDialogue = true;
        gameObject.SetActive(true);
        GameManager.instance.player.Pause();

        if(!finishedDialogue)
        {
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count > 1){
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;

        } else 
        {
            EndDialogue();
            return;
        }

    }

    void EndDialogue()
    {
        isInDialogue = false;
        finishedDialogue = true;
        Debug.Log("end of conversation");
        GameManager.instance.player.UnPause();
        //gameObject.SetActive(false);
        //UnpausePlayer();
    }

    void ProcessInput()
    {
        bool click = Input.GetMouseButtonDown(0);
        if(click && isInDialogue)
        {
            DisplayNextSentence();
        }
    }



    // Update is called once per frame

}
