using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector2 direction;
    public int health = 100;
    PlayerController.Element element;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Color[] colorArray = {new Color(255,0,0),new Color(0,0,255),new Color(0,255,0)};

    void Start()
    {
        element = (PlayerController.Element)Random.Range(0,3);
        spriteRenderer.color = colorArray[(int)element];
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            PlayerController.Element  projectileElement = col.gameObject.GetComponent<PlayerProjectile>().element;
            TakeDamage(col.gameObject);
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovment();
    }

    void FixedUpdate()
    {
        moveCharacter();
    }

    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    void TakeDamage(GameObject projectile)
    {
        PlayerController.Element projectileElement = projectile.GetComponent<PlayerProjectile>().element;
        int enum_length = System.Enum.GetValues(typeof(PlayerController.Element)).Length;
        if ((PlayerController.Element)(mod(((int)projectileElement - 1),3)) == element){
            Debug.Log("WEAK");
            health -= 50;
        }
        else if ((PlayerController.Element)(mod(((int)projectileElement + 1),3)) == element){
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

    void CalculateMovment()
    {
        direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(){
        rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
    }
}
