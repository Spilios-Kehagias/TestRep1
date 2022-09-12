using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector3 velocity;

    public GameObject groundCheck;

    public float movementSpeed = 8f;
    private float defultMovementSpeed;

    public float jumpForce = 3.5f;
    public float smoothTime = 0.2f;
    private float moveDirection = 0f;
    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded;
    private bool isFacingLeft = false;
    private bool isJumpPressed = false;
    private bool isMoving;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    // Start is called before the first frame update
    void Start()
    {
        defultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveDirection) > 0.05)
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
            audioSource.PlayOneShot(pickupClip);
        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));

    }

    private void FixedUpdate()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }

        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if (isGrounded == false)
        {
            verticalVelocity = rigidBody2D.velocity.y;
        }

        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;

    }

    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if (isJumpPressed == true && isGrounded == true)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if (moveDirection.x > 0f && isFacingLeft == true)
        {
            FlipSpriteDirection();
        }

        else if (moveDirection.x < 0f && isFacingLeft == false)
        {
            FlipSpriteDirection();
        }
    }

    private void FlipSpriteDirection()
    {
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public bool isFalling()
    {
        if (rigidBody2D.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }
    public void ResetMovementSpeed()
    {
        movementSpeed = defultMovementSpeed;
    }

    public void SetNewMovementSpeed(float multiplyBy)
    {
        movementSpeed *= multiplyBy;
    }
}