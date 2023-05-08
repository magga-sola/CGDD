using UnityEngine;
public class PlayerController : MonoBehaviour
{   public float moveSpeed;

    public static PlayerController instance;

    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public GameManager.Element elementalMode = GameManager.Element.Fire;
    public Camera cam;
    private Vector3 target;
    private Vector3 playerLastPosition;
    public float smoothTime = 0.25f;
    public Sprite[] wandSpriteArray;
    public Sprite[] playerSpriteArray;
    public Sprite[] playerRedSpriteArray;
    public Sprite[] playerGreenSpriteArray;
    public Sprite[] playerBlueSpriteArray;
    private Sprite[] activeColorSpriteArray;

    public GameObject firePoint;
    public ElementalBars elementalBars;
    public PlayerShooting playerShootingController;
    public Animator animator;
    public PlayerHurting hurting;
    public PlayerHealing healing;

    private void Start()
    {
        elementalBars.SetElementalMode(elementalMode);
        activeColorSpriteArray = playerRedSpriteArray;
    }

    void Awake()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        CheckMode();
    }

    void FixedUpdate()
    {
        SetCameraTarget();
        Move();
        PlayerDirection();
    }

    void ProcessInput()
    {
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        // Elements
        if (Input.GetKeyDown(KeyCode.Alpha1) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Fire))
        {
            ChangeMode(GameManager.Element.Fire);
            activeColorSpriteArray = playerRedSpriteArray;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Earth))
        {
            ChangeMode(GameManager.Element.Earth);
            activeColorSpriteArray = playerGreenSpriteArray;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Water))
        {
            ChangeMode(GameManager.Element.Water);
            activeColorSpriteArray = playerBlueSpriteArray;

        }
        if ((int)Input.mouseScrollDelta.y != 0){
            ChangeModeScroll((int)Input.mouseScrollDelta.y);
        }
        
    }

    private void ChangeMode(GameManager.Element mode)
    {
        elementalMode = mode;
        ChangeSprites();
        animator.SetInteger("Element", (int)mode);
        elementalBars.SetElementalMode(mode);
    }

    private void ChangeModeScroll(int scrollNum)
    {
        ChangeMode((GameManager.Element) (Mod((int) elementalMode + scrollNum, 3)));
        GameManager.Element element = (GameManager.Element) Mod((int)elementalMode + scrollNum, 3);
        for (int i = 0; i < 3; i++){
            Debug.Log(element);
            if (!elementalBars.IsHealthFinishedInElement(element)){
                ChangeMode(element);
                break;
            }
            Debug.Log("ASDASD");
            element = (GameManager.Element) Mod((int)element + scrollNum, 3);
        }
    }

    int Mod(int x, int p)
    {
        return (x%p + p)%p; 
    }

    private void CheckMode()
    {
        if(elementalBars.IsHealthFinishedInElement(elementalMode))
        {
            GameManager.Element firstElement = (GameManager.Element) (Mod((int) elementalMode + 1, 3));
            GameManager.Element secondElement = (GameManager.Element) (Mod((int) elementalMode - 1, 3));

            if(!elementalBars.IsHealthFinishedInElement(firstElement))
            {
                ChangeMode(firstElement);
            }
            else if(!elementalBars.IsHealthFinishedInElement(secondElement))
            {
                ChangeMode(secondElement);
            }
            else {
                // PLAYER IS DEAD
                PlayerDies();
                GameManager.instance.PlayerDied();
            }
        }
    }

    void PlayerDies()
    {
        elementalBars.RestartHealth();
    }

    void PlayerDirection()
    {                
        // Down
        if (playerShootingController.lookAngle >= -135 && playerShootingController.lookAngle < -45)
        {
            GetComponent<SpriteRenderer>().sprite = activeColorSpriteArray[0];
            animator.SetInteger("Direction", 0);
        }
        // Right
        else if (playerShootingController.lookAngle >= -45 && playerShootingController.lookAngle < 45)
        {
            GetComponent<SpriteRenderer>().sprite = activeColorSpriteArray[2];
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetInteger("Direction", 2);
        }
        // Up
        else if (playerShootingController.lookAngle >= 45 && playerShootingController.lookAngle < 135)
        {
            GetComponent<SpriteRenderer>().sprite = activeColorSpriteArray[1];
            animator.SetInteger("Direction", 1);
        }
        // Left
        else
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<SpriteRenderer>().sprite = activeColorSpriteArray[2];
            animator.SetInteger("Direction", 2);
        }
    }

    void ChangeSprites()
    {
        firePoint.GetComponent<SpriteRenderer>().sprite = wandSpriteArray[(int)elementalMode];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("Enemy Projectile"))
        {
            GameManager.Element projectileElement = col.gameObject.GetComponent<EnemyProjectile>().element;
        }

        if (col.gameObject.name.Contains("Healing Orb"))
        {
            GameManager.Element healingOrbElement = col.gameObject.GetComponent<HealingOrb>().element;
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
