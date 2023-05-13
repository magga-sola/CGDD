using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerController player;
    public PlayerProjectile playerProjectile;
    public GameManager.Element playerMode;

    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed;
    private Vector2 lookDirection;
    public float lookAngle;
    private float timeSinceLastShot;
    public ElementalBars elementalBars;
    public AudioSource audioSource;
    public AudioClip[] attacksAudio;

    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isPaused)
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookAngle = Mathf.Atan2(lookDirection.y - transform.position.y, lookDirection.x - transform.position.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
            bool elementalAttack = Input.GetMouseButton(0);
            bool basicAttack = Input.GetMouseButton(1);
            if ((elementalAttack || basicAttack) && Time.realtimeSinceStartup - timeSinceLastShot > 0.5)
            {
                playerMode = player.elementalMode;
                if (basicAttack)
                {
                    BasicAttackAudioClip();
                    playerProjectile.SetBasicAttack(true);
                    GameObject projectileClone = Instantiate(projectile);
                    projectileClone.transform.SetPositionAndRotation(firePoint.position, Quaternion.Euler(0, 0, lookAngle));
                    projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
                    timeSinceLastShot = Time.realtimeSinceStartup;
                    playerProjectile.SetBasicAttack(false);
                }
                // Special attack
                else if (!elementalBars.IsHealthFinishedInElement(playerMode))
                {
                    ChangeAudioClip();
                    GameObject projectileClone = Instantiate(projectile);
                    projectileClone.transform.SetPositionAndRotation(firePoint.position, Quaternion.Euler(0, 0, lookAngle));
                    projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
                    timeSinceLastShot = Time.realtimeSinceStartup;
                    DecreaseHealthByAttack();
                }
            }
        }
    }

    void ChangeAudioClip()
    {
        audioSource.clip = attacksAudio[(int)playerMode];
        audioSource.Play();
    }

    void BasicAttackAudioClip()
    {
        audioSource.clip = attacksAudio[3];
        audioSource.Play();
    }

    void DecreaseHealthByAttack()
    {
        switch (player.elementalMode)
        {
            case GameManager.Element.Fire:
                elementalBars.fireBar.DecreaseHealthByAttack();
                break;
            case GameManager.Element.Water:
                elementalBars.waterBar.DecreaseHealthByAttack();
                break;
            case GameManager.Element.Earth:
                elementalBars.earthBar.DecreaseHealthByAttack();
                break;
        }
    }
}
