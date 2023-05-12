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
    private bool attacking;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
        timeSinceLastAttack = Time.realtimeSinceStartup;
        attackMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (bossController.element == GameManager.Element.Fire)
        {
            WaterShootingMode();
        }
        else if (bossController.element == GameManager.Element.Earth)
        {
            EarthShootingMode();
        }
        if (bossController.element == GameManager.Element.Water)
        {
            FireShootingMode();
        }
    }

    void FireShootingMode()
    {
        
        if (attackMode == 0 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            FlameThrower();
        }
        else if (attackMode == 1 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            FireRing();
            
        }
        else if(Time.realtimeSinceStartup - timeSinceLastAttack > 5){
            attackMode = Random.Range(0,2);
            timeSinceLastAttack = Time.realtimeSinceStartup;
        }
        else
        {
            bossController.moving = true;
        }
    }

    void EarthShootingMode()
    {
        if (attackMode == 0 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            EarthThrower();
        }
        else if (attackMode == 1 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            EarthRing();
            
        }
        else if(Time.realtimeSinceStartup - timeSinceLastAttack > 5){
            attackMode = Random.Range(0,2);
            timeSinceLastAttack = Time.realtimeSinceStartup;
        }
        else
        {
            bossController.moving = true;
        }
    }

    void WaterShootingMode()
    {
        if (attackMode == 0 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            WaveAttack();
        }
        else if (attackMode == 1 && Time.realtimeSinceStartup - timeSinceLastAttack < 4)
        {
            bossController.moving = false;
            WaterRing();
            
        }
        else if(Time.realtimeSinceStartup - timeSinceLastAttack > 5){
            attackMode = Random.Range(0,2);
            timeSinceLastAttack = Time.realtimeSinceStartup;
        }
        else
        {
            bossController.moving = true;
        }
    }
    void FlameThrower(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 0.1){
            ShootProjectile(bossController.angle);
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }

    void EarthThrower(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 0.2){
            ShootProjectile(bossController.angle);
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }

    void FireRing(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 2){
            projectilecontroller.bossController = bossController;
            float dangle = 22.5f;
            for (int i = 0; i < 16; i++){
                ShootProjectile(dangle*i);
            }
            
            timeSinceLastShot = Time.realtimeSinceStartup;
            
        }
    }

    void EarthRing(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 1){
            projectilecontroller.bossController = bossController;
            float dangle = 45f;
            for (int i = 0; i < 16; i++){
                ShootProjectile(dangle*i+offset);
            }
            offset += 22.5f;
            timeSinceLastShot = Time.realtimeSinceStartup;
            
        }
    }

    void WaveAttack(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 0.8){
            projectilecontroller.bossController = bossController;
            float dangle = 5f;
            for (int i = -2; i < 3; i++){
                ShootProjectile(bossController.angle+dangle*i,0.8f);
            }
            timeSinceLastShot = Time.realtimeSinceStartup;
        }
    }
    void WaterRing(){
        if (Time.realtimeSinceStartup-timeSinceLastShot > 4){
            projectilecontroller.bossController = bossController;
            float dangle = 14.4f;
            for (int i = 0; i < 25; i++){
                ShootProjectile(dangle*i,0.5f);
            }
            offset += 22.5f;
            timeSinceLastShot = Time.realtimeSinceStartup;
            
        }
    }

    void ShootProjectile(float angle, float speedMult = 1f){
        transform.rotation = Quaternion.Euler(0, 0, angle);
        GameObject projectileClone = Instantiate(projectile);
        projectileClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, angle));
        projectileClone.GetComponent<Rigidbody2D>().velocity = transform.right * (projectileSpeed*speedMult);
    }

}
