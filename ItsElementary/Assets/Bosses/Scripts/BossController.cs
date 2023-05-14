using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Vector2 direction;
    public float angle;
    public float distanceFromPlayer;
    public int health = 2000;
    public GameManager.Element element;
    public Rigidbody2D rb;
    public Sprite[] spriteArray;
    public EnemyEnergyBar elementalBar;
    public Animator animator;
    public bool moving;
    public bool finalBoss;
    private float timeSinceLastSwitch;
    //public GameManager gameManager;
    public GameObject[] healingOrbs;
    public GameObject trace;
    public ElementalTrace elementalTrace;
    public ExitRoomScript exitRoom;
    public EndPanelController endPanel;

    void Start()
    {
        player = GameManager.instance.player.transform;
        animator.SetInteger("Element", (int)element);
        animator.SetBool("Final Boss", finalBoss);
        elementalBar.Initialize(element, health, health);
        moving = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Projectile(Clone)")
        {
            TakeDamage(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnd();
        CalculateMovement();
        distanceFromPlayer = Vector3.Distance (player.transform.position, transform.position);
    }

    void FixedUpdate()
    {
        MoveCharacter();
        if(finalBoss)
        {
            SwitchForms();
        }
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
        if (basicAttack || (GameManager.Element)Mod((int)projectileElement - 1,3) == element){
            elementalBar.DecreaseByWeakOpponent();
        }
        else if ((GameManager.Element)Mod((int)projectileElement + 1,3) == element){
            elementalBar.DecreaseByStrongOpponent();
            projectile.GetComponent<PlayerProjectile>().Explode();
        }
        
        else if (projectileElement == element){

            elementalBar.DecreaseBySameOpponent();
        }
        if (elementalBar.IsHealthFinished())
        {
            LeaveTraces();
            if (!finalBoss)
            {
                exitRoom.isBossKilled = true;
                Destroy(gameObject);
            }
            else
            {
                animator.SetBool("Dead",true);
                //endPanel.ShowGameWonScreen();
                //GameManager.instance.GameWon();
            }
        }
    }

    void CheckEnd()
    {
        if (animator.GetBool("End"))
        {
            endPanel.ShowGameWonScreen();
            GameManager.instance.GameWon();
        }
    }
    void LeaveTraces()
    {
        elementalTrace.SetElement(element);
        Transform newParent = new GameObject("Trace").transform;
        trace.transform.SetParent(newParent);
        trace.SetActive(true);

        foreach (GameObject orb in healingOrbs)
        {
            orb.transform.SetParent(newParent);
            orb.SetActive(true);
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
        FlipSprite();
        if (moving && distanceFromPlayer > 4){   
            animator.SetBool("Walking",true);
            rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
        }
        else
        {
            animator.SetBool("Walking",false);
        }
    }

    void SwitchForms()
    {
        if (Time.realtimeSinceStartup - timeSinceLastSwitch > 10)
        {
            element = (GameManager.Element) Random.Range(0,3);
            elementalBar.ChangeMode(element);
            animator.SetInteger("Element", (int)element);
            timeSinceLastSwitch = Time.realtimeSinceStartup;
        }
    }
}
