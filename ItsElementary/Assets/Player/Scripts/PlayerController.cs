using UnityEngine;
public class PlayerController : MonoBehaviour
{
    //public bool gameOver;
    public float moveSpeed;

    //public GameManager GM;
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


    private void Start()
    {
        elementalBars.SetElementalMode(elementalMode);
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
        if (Input.GetKeyDown(KeyCode.Alpha1) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Fire))
        {
            ChangeMode(GameManager.Element.Fire);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Earth))
        {
            ChangeMode(GameManager.Element.Earth);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !elementalBars.IsHealthFinishedInElement(GameManager.Element.Water))
        {
            ChangeMode(GameManager.Element.Water);
        }
        //ChangeModeScroll((int)Input.mouseScrollDelta.y);
    }

    private void ChangeMode(GameManager.Element mode)
    {
        elementalMode = mode;
        ChangeSprites();
        //Debug.Log("set elemental mode: " + mode.ToString());
        elementalBars.SetElementalMode(mode);
    }

    private void ChangeModeScroll(int scrollNum)
    {
        elementalMode = (GameManager.Element) (mod((int) elementalMode + scrollNum, 3));
    }
    int mod(int x, int p)
    {
        return (x%p + p)%p; 
    }
    private void CheckMode()
    {
        if(elementalBars.IsHealthFinishedInElement(elementalMode))
        {
            // The element that 
            GameManager.Element firstElement = (GameManager.Element) (mod((int) elementalMode + 1, 3));
            GameManager.Element secondElement = (GameManager.Element) (mod((int) elementalMode - 1, 3));

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
                GameManager.instance.GameOver();
            }
        }
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
            //elementalBars.HitByElement(projectileElement);
            //Destroy(gameObject);
        }

        if (col.gameObject.name.Contains("Healing Orb"))
        {
            GameManager.Element healingOrbElement = col.gameObject.GetComponent<HealingOrb>().element;

            //elementalBars.HealedByElement(healingOrbElement);
            
            //random comment
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
