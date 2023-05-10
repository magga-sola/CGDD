using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public PlayerController player;
    
    
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with: " + dialogue.name);
        sentences.Clear();
        GameManager.instance.player.Pause();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");
        GameManager.instance.player.UnPause();
        //UnpausePlayer();
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame

}
