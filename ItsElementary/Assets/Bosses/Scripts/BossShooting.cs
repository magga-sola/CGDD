using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    private float timeSinceLastShot;
    public BossController bossController;
    public BossProjectile projectilecontroller;
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
        Shoot();
    }

    void Shoot(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 2 && bossController.distanceFromPlayer <= 6){
            transform.rotation = Quaternion.Euler(0, 0, bossController.angle);
            projectilecontroller.bossController = bossController;
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, bossController.angle));
            projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }
}
