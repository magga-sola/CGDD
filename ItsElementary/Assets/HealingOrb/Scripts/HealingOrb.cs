using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public GameManager.Element element;
    public EnemyController enemyController;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public PlayerHealing healing;
    public Animator animator;

    void Start()
    {
        
        //element = enemyController.element;
        
        //Debug.Log(element);
        animator.SetInteger("Element",(int)element);
        spriteRenderer.sprite = spriteArray[(int)element];
        healing = GameManager.instance.player.GetComponent<PlayerHealing>();    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Player"))
        {
            healing.IncreaseHealthByOrb(element);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



