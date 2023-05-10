
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
    public GameObject explosion;
    public Explosion explosionController;
    public int[] weights = {33,33,33};

    void Start()
    {
        player = GameManager.instance.player.transform;
        element = (GameManager.Element)RandomElement();
        GetComponent<SpriteRenderer>().sprite = spriteArray[(int)element];
        elementalBar.Initialize(element, health, health);
        animator.SetInteger("Element", (int)element);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            //GameManager.Element projectileElement = col.gameObject.GetComponent<PlayerProjectile>().element;
            TakeDamage(col.gameObject);
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

    int Mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    void TakeDamage(GameObject projectile)
    {
        GameManager.Element projectileElement = projectile.GetComponent<PlayerProjectile>().element;
        bool basicAttack = projectile.GetComponent<PlayerProjectile>().basicAttack;
        //int enum_length = System.Enum.GetValues(typeof(GameManager.Element)).Length;
        if (basicAttack || (GameManager.Element)Mod((int)projectileElement - 1,3) == element){
            elementalBar.DecreaseByWeakOpponent();
        }
        else if ((GameManager.Element)Mod((int)projectileElement + 1,3) == element){
            elementalBar.DecreaseByStrongOpponent();
            explosionController.element = projectileElement;
            GameObject explosionClone = Instantiate(explosion);
            explosionClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
        }
        
        else if (projectileElement == element){

            elementalBar.DecreaseBySameOpponent();
        }

        if (elementalBar.IsHealthFinished())
        {
            // Health orbs
            //healingorbcontroller.enemyController = this;
            healingorbcontroller.element = element;
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

    int RandomElement()
    {
        int randomCeiling = 0;
        int currentNum = 0;
        foreach(int num in weights)
        {
            randomCeiling += num;
        }
        int randomNumber = Random.Range(0,randomCeiling+1);
        //Debug.Log(randomNumber);
        for (int i = 0; i < weights.Length; i++)
        {
            if (currentNum + weights[i] >= randomNumber){
                return i;
            }
            currentNum += weights[i];
        }
        return 0;
    }
}
