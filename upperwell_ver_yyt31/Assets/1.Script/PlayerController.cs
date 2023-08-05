using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{



    public Vector3 m_LastPosition;

    public Rigidbody2D rb;
    private InputManager inputs;
    bool isMoving;


    public float fmoveSpeed = 5f;
    public float jumpForce = 15f;
    public bool isJumping = false;
    public bool isGrounded = false;
    
    public Collider2D collider;

    public float fillDuration = 1.5f; // Time in seconds for the alpha value to fill up
    public float alphaIncreaseRate = 1f; // Rate at which the alpha value increases per second
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    private float currentAlpha = 0f; // Current alpha value
    private float fillTimer = 0f; // Timer for tracking fill duration
    private float gageTimer = 0f; 


    public bool B_usedshot;

    private void Awake()
    {

        m_LastPosition = Vector3.zero;

        inputs = GetComponent<InputManager>();

        rb = GetComponentInChildren<Rigidbody2D>();
        collider = GetComponentInChildren<Collider2D>();
        B_usedshot = false;
        gageTimer = 0;
    }


    void Rotate()
    {
        if (isMoving)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
            rb.gameObject.transform.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


 


    private void Update()
    {
        /*

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb.AddForce(movement * fmoveSpeed/77);

        */



        // rb.AddRelativeForce(inputs.MoveInput.normalized) ; // moveDir = inputs.MoveInput.normalized;
        // rb.AddForce(inputs.MoveInput.normalized*fmoveSpeed);
        // rb.MovePosition(inputs.MoveInput.normalized*moveSpeed);
        if (B_usedshot)
        {

           /* Vector2 shootDirection = (rb.position  - (Vector2)transform.position).normalized;


            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
           */
            // Check for shooting input (e.g., left mouse click).
            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))            
                OnDash();
            
               

        }
        isMoving = Convert.ToBoolean(rb.velocity.magnitude);
       // Rotate();

       if(B_usedshot == false)
        { 
          gageTimer += Time.deltaTime;
          FillAlpha();
            if (gageTimer >= fillDuration)
                B_usedshot = true;
        }    

    }

    public void OnDash()
    {

        if (B_usedshot == true)// && isGrounded)
        {
    
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);// AIMㅇㅡㄹㅗ ㅆㅗㄴㄷㅏ
                isJumping = true;
                B_usedshot = false;
                fillTimer = 0f;
                gageTimer = 0f;

        
        }
    }


    private void FillAlpha()
    {
        // Increase fill timer
        fillTimer += Time.deltaTime;
        B_usedshot = false;
        // Calculate alpha value based on the fill duration and increase rate
        currentAlpha = Mathf.Clamp01(fillTimer / fillDuration * alphaIncreaseRate);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, currentAlpha);
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Collider2D>().CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<Collider2D>().CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    */
}
