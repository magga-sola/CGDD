
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyController enemyController;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        element = enemyController.element;
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.name.Contains("Enemy"))
        {
            Debug.Log(col.gameObject.name);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
