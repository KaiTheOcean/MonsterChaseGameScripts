using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private string WALK_ANIMATION = "Walk"; // This is access the parameters in the animator

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        // This is what we need in order to move the player
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard() 
    {
        // In this situation we can also use GetAxis
        // Get the input when we press the left or right arrow
        movementX = Input.GetAxisRaw("Horizontal"); 

        // Allows the player move left and right according to the keyboard 
        // only add movementX because we are only move left and right
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce; 
    }

    void AnimatePlayer()
    {
        // We are going to the right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; // This will walk because in animator we set in both ways
        }

        // We are going to the left side
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; // This will walk because in animator we set in both ways
        }

        // Not moving
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        // This is jump is predefined by Unity
        // And aslo make sure the player is grounded
        if (Input.GetButton("Jump") && isGrounded)
        {
            isGrounded = false;
            // Vector2 is we are adding the force on X and Y, because X is 0, we are only adding on the Y
            // ForceMode2D.Impulse means push the player right up
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
