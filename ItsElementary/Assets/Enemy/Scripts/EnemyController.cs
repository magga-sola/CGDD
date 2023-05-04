
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector2 direction;
    public float angle;
    public float distanceFromPlayer;
    public int health = 100;
    public GameManager.Element element;
    public Rigidbody2D rb;
    public Sprite[] spriteArray;
    public GameObject healingOrb;
    public HealingOrb healingorbcontroller;



    void Start()
    {
        element = (GameManager.Element)Random.Range(0,3);
        GetComponent<SpriteRenderer>().sprite = spriteArray[(int)element];
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
        CalculateMovment();
        distanceFromPlayer = Vector3.Distance (player.transform.position, transform.position);
    }

    void FixedUpdate()
    {
        moveCharacter();
    }

    void FlipSprite()
    {
        if (angle <= 90 && angle > -90)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    void TakeDamage(GameObject projectile)
    {
        GameManager.Element projectileElement = projectile.GetComponent<PlayerProjectile>().element;
        int enum_length = System.Enum.GetValues(typeof(GameManager.Element)).Length;
        Debug.Log(projectileElement + " " + element);  
        if ((GameManager.Element)(mod(((int)projectileElement + 1),3)) == element){
            Debug.Log(projectileElement + " WEAK " + element);  
            health -= 50;
        }
        else if ((GameManager.Element)(mod(((int)projectileElement - 1),3)) == element){
            Debug.Log("STRONG");
            health -= 20;
        }
        else if (projectileElement == element){
            Debug.Log("SAME");
            health -= 34;
        }

        if (health <= 0)
        {
            // health orbs
            healingorbcontroller.enemyController = this;
            GameObject healingOrbClone = Instantiate(healingOrb);
            healingOrbClone.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

    void CalculateMovment()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(){
        if (distanceFromPlayer <= 10){
            FlipSprite();
            if (distanceFromPlayer > 4){
                rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
            }
        }
    }

    
}
