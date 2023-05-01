using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum element
    {
        fire,
        water,
        earth
    }
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool elementalAttack;
    private bool basicAttack;
    public element elementalMode = element.fire;
    public Camera cam;
    private Vector3 target;
    private Vector3 playerLastPosition;
    public float smoothTime = 0.25f;

    


    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        //SetCameraTarget();
    }

    void FixedUpdate()
    {
        SetCameraTarget();
        Move();
        MousePosition();
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            elementalMode = element.fire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            elementalMode = element.water;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            elementalMode = element.earth;
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

    void MousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        if (elementalAttack || basicAttack){
            Debug.Log(mousePos.x);
            Debug.Log(mousePos.y);
        }
        
    }
}
