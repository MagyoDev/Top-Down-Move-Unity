using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    private float activeMoveSpeed; 
    public float dashSpeed = 10f; 

    public float dashLength = .5f, dashCooldown = 1f; 

    private float dashCounter; 
    private float dashCooldownCounter; 

    private void Start()
    {
        activeMoveSpeed = moveSpeed; 
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCooldownCounter <=0 && dashCounter <=0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCooldownCounter = dashCooldown;
            }
        }

        if (dashCooldownCounter > 0) 
        { 
            dashCooldownCounter -= Time.deltaTime;
        }
    }
}
