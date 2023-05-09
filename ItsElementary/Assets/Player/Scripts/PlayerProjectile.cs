
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager.Element element;
    public bool basicAttack;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Sprite basicAttackSprite;
    public Animator animator;
    void Start()
    {
        element = playerController.elementalMode;
        animator.SetInteger("Element",(int)element);
        if (basicAttack)
        {
            spriteRenderer.sprite = basicAttackSprite;
        }
        else
        {
            spriteRenderer.sprite = spriteArray[(int)element];
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player" && !col.gameObject.name.Contains("Projectile") && !col.gameObject.name.Contains("Healing Orb"))
        {
            animator.SetBool("Hit",true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }

    public void SetBasicAttack(bool bo)
    {
        basicAttack = bo;
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
