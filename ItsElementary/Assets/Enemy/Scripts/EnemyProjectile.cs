
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyController enemyController;
    public PlayerController player;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Animator animator;

    void Start()
    {
        player = GameManager.instance.player;
        element = enemyController.element;
        animator.SetInteger("Element",(int)element);
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("Enemy") && !col.gameObject.name.Contains("Projectile") && !col.gameObject.name.Contains("Healing Orb") &&  !col.gameObject.name.Contains("Wizard"))
        {
            if (col.gameObject.name.Contains("Player"))
            {
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