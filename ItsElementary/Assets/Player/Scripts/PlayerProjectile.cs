
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager.Element element;
    public bool basicAttack;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Sprite basicAttackSprite;
    void Start()
    {
        element = playerController.elementalMode;
        Debug.Log(element);

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
            Debug.Log(col.gameObject.name);
            Destroy(gameObject);      
        }
    }

    public void SetBasicAttack(bool bo)
    {
        basicAttack = bo;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
