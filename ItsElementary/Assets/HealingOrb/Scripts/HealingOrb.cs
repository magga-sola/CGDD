using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public GameManager.Element element;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public PlayerHealing player;
    public Animator animator;
    // Start is called before the first frame update

    //animation ----> static

    //collision -----> on collision -> heal player
    //death     -----> on death of enemy -> make a healing orb at their death (x, y) coordinate


    // void animation()


    void Start()
    {
        element = enemyController.element;
        animator.SetInteger("Mode 0", (int)element);
        spriteRenderer.sprite = spriteArray[(int)element];
        //animator.SetInt("Mode", (int)element); 
    }

        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            player.IncreaseHealthByOrb(element);
            Destroy(gameObject);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}



