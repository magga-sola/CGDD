using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public BossController bossController;
    public PlayerController player;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Animator animator;

    void Start()
    {
        player = GameManager.instance.player;
        element = bossController.element;
        animator.SetInteger("Element",(int)element);
        //spriteRenderer.sprite = spriteArray[(int)element];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("Boss") && !col.gameObject.name.Contains("Projectile") && !col.gameObject.name.Contains("Healing Orb"))
        {
            if (col.gameObject.name.Contains("Player"))
            {
                player.hurting.HitByEnemyProjectile(element);
                player.hurting.HitByEnemyProjectile(element);
            }
            
            animator.SetBool("Hit",true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Exploded"))
        {
            Destroy(gameObject);      
        }
    }

}
