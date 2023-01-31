using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJump;
    private float horizontal;
    private float vertical;
    
    public bool isJumping;
    public bool doubleJump;
    private bool isLadder;
    private bool isClimbing;

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private enum MovementState { idle, running, jumping, falling }
    private MovementState state = MovementState.idle;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update() {
        PlayerMove();
        PlayerJump();
        PlayerClimb();
        PlayerAnimationState();
    }

    private void PlayerMove() {
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);
    }

    private void PlayerJump() {
        if (Input.GetButtonDown("Jump")) {
            if (!isJumping) {
                rb.velocity = new Vector2(rb.velocity.x, playerJump);
                doubleJump = true;
            }
            else {
                if (doubleJump) {
                    rb.velocity = new Vector2(rb.velocity.x, playerJump);
                    doubleJump = false;
                }
            }
        }
    }

    private void PlayerClimb() {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f) {
            isClimbing = true; 
        }

        if (isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * playerSpeed);
            anim.SetBool("climbing", true);
        }
        else {
            rb.gravityScale = 2f;
        }
    }

    private void PlayerAnimationState() {
        MovementState state;
        
        if (horizontal > 0f) {
            state = MovementState.running;
            sp.flipX = false;
        }
        else if (horizontal < 0f) {
            state = MovementState.running;
            sp.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f && !isClimbing) {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f && !isClimbing) {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 3) {
            isJumping = false;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.layer == 3) {
            isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Ladder")) {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("climbing", false);
        }
    }
}
