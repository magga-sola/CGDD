using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public PlayerController player;

    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed;
    private Vector2 lookDirection;
    private float lookAngle;
    private float timeSinceLastShot;
    public ElementalBars elementalBars;

    void Start()
    {
        timeSinceLastShot = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y - transform.position.y, lookDirection.x - transform.position.x) * Mathf.Rad2Deg;
        Vector3 direction = new Vector3 (lookDirection.normalized.x, lookDirection.normalized.y, 0);
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        bool elementalAttack = Input.GetMouseButton(0);
        bool basicAttack = Input.GetMouseButton(1);
        if ( (elementalAttack || basicAttack) && Time.realtimeSinceStartup-timeSinceLastShot > 0.5)
        {
            GameObject projectileClone = Instantiate(projectile);
            if (basicAttack)
            {
                projectileClone.GetComponent<Renderer>().material.color = new Color(0,0,0);
            }
            else // Special attack
            {
                //DecreaseHealthByAttack();
            }
            //projectileClone.transform.position = firePoint.position + direction;
            projectileClone.transform.position = firePoint.position;

            projectileClone.transform.rotation = Quaternion.Euler(0,0, lookAngle);

            projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
            timeSinceLastShot = Time.realtimeSinceStartup;

        }
    }

    void DecreaseHealthByAttack()
    {
        Debug.Log("DecreaseHealthByAttack");
        Debug.Log("PlayerController.Element:" + player.elementalMode.ToString());
        switch (player.elementalMode)
        {
            case PlayerController.Element.Fire:
                elementalBars.fireBar.DecreaseHealthByAttack();
                break;
            case PlayerController.Element.Water:
                elementalBars.waterBar.DecreaseHealthByAttack();
                break;
            case PlayerController.Element.Earth:
                elementalBars.earthBar.DecreaseHealthByAttack();
                break;
        }
    }
}
