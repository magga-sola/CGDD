using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private float timeSinceLastShot;
    public EnemyController enemyController;
    public EnemyProjectile projectilecontroller;
    public GameObject projectile;
    public float projectileSpeed = 10;




    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 1 && enemyController.distanceFromPlayer <= 6){
            transform.rotation = Quaternion.Euler(0, 0, enemyController.angle);
            projectilecontroller.enemyController = enemyController;
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, enemyController.angle));
            projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
        
    }
}
