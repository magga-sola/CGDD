
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public int health = 100;
    GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Color[] colorArray = {new Color(255,0,0),new Color(0,0,255),new Color(0,255,0)};

    void Start()
    {
        element = (GameManager.Element)Random.Range(0,3);
        spriteRenderer.color = colorArray[(int)element];
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            GameManager.Element projectileElement = col.gameObject.GetComponent<PlayerProjectile>().element;
            TakeDamage(col.gameObject);
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    void TakeDamage(GameObject projectile)
    {
        GameManager.Element projectileElement = projectile.GetComponent<PlayerProjectile>().element;
        int enum_length = System.Enum.GetValues(typeof(GameManager.Element)).Length;
        if ((GameManager.Element)(mod(((int)projectileElement - 1),3)) == element){
            Debug.Log("WEAK");
            health -= 50;
        }
        else if ((GameManager.Element)(mod(((int)projectileElement + 1),3)) == element){
            Debug.Log("STRONG");
            health -= 20;
        }
        else if (projectileElement == element){
            Debug.Log("SAME");
            health -= 34;
        }
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {

    }
}
