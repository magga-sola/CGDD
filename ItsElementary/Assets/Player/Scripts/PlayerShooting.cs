using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 50;
    private Vector2 lookDirection;
    private float lookAngle;

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y - transform.position.y, lookDirection.x - transform.position.x) * Mathf.Rad2Deg;
        Debug.Log(lookDirection.x +","+transform.position.x);
        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButton(0))
        {
            GameObject projectileClone = Instantiate(projectile);
            projectileClone.transform.position = firePoint.position;
            projectileClone.transform.rotation = Quaternion.Euler(0,0, lookAngle);

            projectileClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * projectileSpeed;
        }
    }
}
