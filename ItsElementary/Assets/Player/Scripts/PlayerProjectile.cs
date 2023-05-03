
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    void Start()
    {
        element = playerController.elementalMode;
        spriteRenderer.sprite = spriteArray[(int)element];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player" && !col.gameObject.name.Contains("Projectile"))
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
