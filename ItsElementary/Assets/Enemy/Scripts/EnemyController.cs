
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
    public EnemyEnergyBar elementalBar;
    public Animator animator;

    void Start()
    {
        element = (GameManager.Element)Random.Range(0,3);
        GetComponent<SpriteRenderer>().sprite = spriteArray[(int)element];
        elementalBar.Initialize(element, health, health);
        animator.SetInteger("Element",(int)element);

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
        CalculateMovement();
        distanceFromPlayer = Vector3.Distance (player.transform.position, transform.position);
    }

    void FixedUpdate()
    {
        MoveCharacter();
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
        bool basicAttack = projectile.GetComponent<PlayerProjectile>().basicAttack;
        int enum_length = System.Enum.GetValues(typeof(GameManager.Element)).Length;
        if (basicAttack || (GameManager.Element)(mod(((int)projectileElement - 1),3)) == element){
            Debug.Log("STRONG");
            elementalBar.DecreaseByWeakOpponent();
        }
        else if ((GameManager.Element)(mod(((int)projectileElement + 1),3)) == element){
            Debug.Log(projectileElement + " WEAK " + element);
            elementalBar.DecreaseByStrongOpponent();
        }
        
        else if (projectileElement == element){

            elementalBar.DecreaseBySameOpponent();
            Debug.Log("SAME");
        }

        if (elementalBar.IsHealthFinished())
        {
            // health orbs
            healingorbcontroller.enemyController = this;
            GameObject healingOrbClone = Instantiate(healingOrb);
            healingOrbClone.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

    void CalculateMovement()
    {
        direction = player.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
    }

    void MoveCharacter(){
        if (distanceFromPlayer <= 10){
            FlipSprite();
            if (distanceFromPlayer > 4){   
                animator.SetBool("Walking",true);
                rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
            }
            else
            {
                animator.SetBool("Walking",false);
            }
        }
        else
        {
                animator.SetBool("Walking",false);
        }
    }    
}
