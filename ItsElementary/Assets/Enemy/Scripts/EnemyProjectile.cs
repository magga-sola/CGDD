
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyController enemyController;
    public PlayerController player;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        player = GameManager.instance.player;
        element = enemyController.element;
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("Enemy") && !col.gameObject.name.Contains("Projectile") && !col.gameObject.name.Contains("Healing Orb"))
        {
            if (col.gameObject.name.Contains("Player"))
            {
                player.hurting.HitByEnemyProjectile(element);
            }
            
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}