
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector2 direction;
    private float angle;
    private float distanceFromPlayer;
    public int health = 100;
    public GameManager.Element element;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Color[] colorArray = {new Color(255,0,0),new Color(0,0,255),new Color(0,255,0)};
    private float timeSinceLastShot;
    public GameObject projectile;
    public EnemyProjectile projectilecontroller;
    public float projectileSpeed = 10;



    void Start()
    {
        element = (GameManager.Element)Random.Range(0,3);
        spriteRenderer.color = colorArray[(int)element];
        timeSinceLastShot = Time.realtimeSinceStartup;

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
        shoot();
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

    void CalculateMovment()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    void moveCharacter(){
        if (distanceFromPlayer <= 10 && distanceFromPlayer > 4){
            rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
        }
        
    }

    void shoot(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 1 && distanceFromPlayer <= 6){
            projectilecontroller.enemyController = this;
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, angle));
            projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
        
    }
}