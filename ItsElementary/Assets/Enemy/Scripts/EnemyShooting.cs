using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private float timeSinceLastShot;
    public EnemyController enemyController;
    public EnemyProjectile projectilecontroller;
    public GameObject projectile;
    public float projectileSpeed = 10;
    public AudioSource audioSource;

    public AudioClip[] attacksAudio;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 2 && enemyController.distanceFromPlayer <= 6){
            ChangeAudioClip();
            transform.rotation = Quaternion.Euler(0, 0, enemyController.angle);
            projectilecontroller.enemyController = enemyController;
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, enemyController.angle));
            projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }

    void ChangeAudioClip()
    {
        audioSource.clip = attacksAudio[(int)enemyController.element];
        audioSource.Play();
    }
}
