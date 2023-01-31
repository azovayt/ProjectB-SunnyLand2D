using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jump;
    [SerializeField] private LayerMask jumpableGround;
    
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private BoxCollider2D coll;
    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;
    
    private float horizontal = 0f;
    private bool isLadder;
    private bool isClimbing;
    private float vertical;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    
    void Update() {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimationState();
        Climbing();
    }
    private void UpdateAnimationState() {
        
        MovementState state;
        
        if (horizontal > 0f)
        {
            state = MovementState.running;
            sp.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Climbing() {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            anim.SetBool("climping", true);
        }

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("climping", false);
        }
    }
}
