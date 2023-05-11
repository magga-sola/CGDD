using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public PlayerController player;


    void Start()
    {
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }

    public void StartDialogue()
    {
        gameObject.SetActive(true);
        player.Pause();

        if(!isFinished) 
        {
            nameComponent.text = npcName;
            index = 0;
            StartCoroutine(TypeLine());
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
