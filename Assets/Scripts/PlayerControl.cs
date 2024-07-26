using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerMoveSpeed = 5.0f;
    public float jumpingPower = 6.0f;
    private float horizontal = 0.0f;
    public bool isFacingRight = true;
    public float groundedDistance = 0.5f;

    [SerializeField] private LayerMask groundLayer;
    public Rigidbody2D rb;
    // [SerializeField] private Transform groundCheckObject;
    [SerializeField] private SpriteRenderer sr;
    public Animator animator;
    [SerializeField] private GameObject obstacleDetectionRayOrigin;
    [SerializeField] private RaycastHit2D jumpDetector;

    // Start is called before the first frame update
    void Start(){}

    private bool IsGrounded()
    {
        return (jumpDetector.collider != null);
       // return Physics2D.OverlapCircle(groundCheckObject.position, groundedDistance, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {

        jumpDetector = Physics2D.Raycast(obstacleDetectionRayOrigin.transform.position, Vector2.down, groundedDistance, groundLayer);

        horizontal = Input.GetAxis("Horizontal") * playerMoveSpeed;
        horizontal = Input.GetAxis("Horizontal") * playerMoveSpeed;

        if ((isFacingRight && horizontal < 0.0f) || (!isFacingRight && horizontal > 0.0f)) {
            isFacingRight = !isFacingRight;
            if (animator.GetBool("playerPushing"))
            {
                animator.SetBool("playerPulling", !animator.GetBool("playerPulling"));
            }
        }

        if(!IsGrounded()) {
            animator.SetBool("playerJumping", true);
        } else {
            animator.SetBool("playerJumping", false);
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            // animator.SetBool("playerJumping", true);
        } // else if (IsGrounded())
        // {
        //     animator.SetBool("playerJumping", false);
        // }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            // animator.SetBool("playerJumping", true);
        }

        animator.SetFloat("playerSpeed", Mathf.Abs(horizontal));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        //sr.flipX = (!isFacingRight) ? true : false;
        if (isFacingRight && !animator.GetBool("playerPushing"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (!isFacingRight && !animator.GetBool("playerPushing"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}


