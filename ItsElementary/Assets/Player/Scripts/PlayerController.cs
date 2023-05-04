
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool elementalAttack;
    private bool basicAttack;
    public GameManager.Element elementalMode = GameManager.Element.Fire;
    public Camera cam;
    private Vector3 target;
    private Vector3 playerLastPosition;
    public float smoothTime = 0.25f;
    public Sprite[] wandSpriteArray;
    public Sprite[] playerSpriteArray;
    public GameObject firePoint;
    public ElementalBars elementalBars;
 
    
    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        //SetCameraTarget();
    }

    void FixedUpdate()
    {
        SetCameraTarget();
        Move();
    }

    // TODO: Nota acceleration
    void ProcessInput()
    {
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Attack
        elementalAttack = Input.GetMouseButton(0);
        basicAttack = Input.GetMouseButton(1);

        // Elements
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeMode(GameManager.Element.Fire);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeMode(GameManager.Element.Earth);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeMode(GameManager.Element.Water);
        }        
    }

    private void ChangeMode(GameManager.Element mode)
    {
        elementalMode = mode;
        ChangeSprites();
        elementalBars.SetElementalMode(mode);
    }

    void ChangeSprites()
    {
        firePoint.GetComponent<SpriteRenderer>().sprite = wandSpriteArray[(int)elementalMode];
        GetComponent<SpriteRenderer>().sprite = playerSpriteArray[(int)elementalMode];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Enemy Projectile"))
        {
            GameManager.Element projectileElement = col.gameObject.GetComponent<EnemyProjectile>().element;
            elementalBars.HitByElement(projectileElement);
            //Destroy(gameObject);
        }

        if (col.gameObject.name.Contains("Healing Orb"))
        {
            GameManager.Element healingOrbElement = col.gameObject.GetComponent<HealingOrb>().element;

            //elementalBars.HitByElement(projectileElement);
            //elementalBars.HealedByElement(healingOrbElement);
            
        }
    }

    void SetCameraTarget()
    {
        Vector2 movementDelta = transform.position - playerLastPosition;
        target.x += movementDelta.x;
        target.y += movementDelta.y;
        target.z = -10;
        playerLastPosition = transform.position; 
    }
    
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        cam.transform.position = target;
    }
}
