using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgBody2D;
    private SpriteRenderer spriteRnd;
    private Animator animator;
    private BoxCollider2D friction;
    public float movementSpeed = 6f;
    public float jumpPower = 2000f;
    public float gravity = 1f;
    private float defaultMovementSpeed;
    [SerializeField] private bool defaultFriction;
    public GameObject GroundCheck;
    private bool isGrounded;
    private bool lookLeft = false;
    private Vector3 velocity;
    public float smoothDuration = 0.15f;
    private float moveDirection = 0f;
    private bool tryJump;
    [SerializeField] private LayerMask isItGround;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;

    // Start is called before the first frame update
    public void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rgBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRnd = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        defaultFriction = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        defaultFriction = true;

        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            tryJump = true;
            animator.SetTrigger("GoJump");

        }
        if (Input.GetKey(KeyCode.LeftShift) == true && isGrounded == true)
        {
            animator.SetTrigger("GoSlide");
            rgBody2D.gravityScale = 15f;
            defaultFriction = false;
        }
          
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Movement", Mathf.Abs(moveDirection));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            rgBody2D.gravityScale += 1.2f;
            rgBody2D.gravityScale *= 1.05f;
        }
        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            rgBody2D.gravityScale = gravity;

        }

        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.transform.position, 0.2f, isItGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }


        }

        Vector3 calcMove = Vector3.zero;

        float verticalVelocity = 0f;

        if (isGrounded == true)
        {
            verticalVelocity = rgBody2D.velocity.y;
        }

        calcMove.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calcMove.y = verticalVelocity;
        Move(calcMove, tryJump);
        tryJump = false;

    }

    private void Move(Vector3 moveDirection, bool tryJump)
    {

        rgBody2D.velocity = Vector3.SmoothDamp(rgBody2D.velocity, moveDirection, ref velocity, smoothDuration);

        if (tryJump == true && isGrounded == true)
        {
            audioSource.PlayOneShot(jumpSound);
            rgBody2D.AddForce(new Vector2(0f, jumpPower));
        }

        if (moveDirection.x > 0f && lookLeft == true)
        {
            FlipPlayerDirection();

        }
        else if (moveDirection.x < 0f && lookLeft == false)
        {
            FlipPlayerDirection();
        }
    }
    private void FlipPlayerDirection()
    {
        spriteRnd.flipX = !lookLeft;
        lookLeft = !lookLeft;
    }
    public bool IsFalling()
    {
        if (rgBody2D.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }

    public void ResetMovementSpeed()
    {
        movementSpeed = defaultMovementSpeed;
    }

    public void SetNewMovementSpeed(float multiplyBy)
    {
        movementSpeed *= multiplyBy;
    }
}
