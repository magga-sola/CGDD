using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    private float timeSinceLastShot;
    private float timeSinceLastAttack;
    public BossController bossController;
    public BossProjectile projectilecontroller;
    public GameObject projectile;
    public float projectileSpeed = 10;
    private int attackMode;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
        timeSinceLastAttack = Time.realtimeSinceStartup;
        attackMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ShootingMode();
    }

    void ShootingMode()
    {
        if (attackMode == 0 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            FlameThrower();
        }
        else if (attackMode == 1 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            OmniDirectionalAttack();
        }
        else if(Time.realtimeSinceStartup - timeSinceLastAttack > 5){
            attackMode = Random.Range(0,2);
            timeSinceLastAttack = Time.realtimeSinceStartup;
        }
    }
    void FlameThrower(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 0.1 && bossController.distanceFromPlayer <= 8){
            transform.rotation = Quaternion.Euler(0, 0, bossController.angle);
            projectilecontroller.bossController = bossController;
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, bossController.angle));
            projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }

    void OmniDirectionalAttack(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 2 && bossController.distanceFromPlayer <= 8){
            projectilecontroller.bossController = bossController;
            float dangle = 22.5f;
            for (int i = 0; i < 16; i++){
                transform.rotation = Quaternion.Euler(0, 0, dangle*i);
                GameObject projectileClone = Instantiate(projectile);
                projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, dangle*i));
                projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            }
            
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }
}
