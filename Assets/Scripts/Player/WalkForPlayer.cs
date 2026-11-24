using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkForPlayer : MonoBehaviour
{

    private float movementSpeed;
    public float walkSpeed, runningSpeed;
    public Animator animator;
    //_______Для уникальных функций персонажей_______\\ 
    [Header("Which character")]
    public bool isRes, isCurio, isSkep;
    public static bool isResActive, isCurioActive, isSkepActive;
    //___________________________________________________________________________________________________\\ 


    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public float smoothTurnTime = 0.1f;
    float smoothTurnVelocity;


    public float playerHeight;
    public LayerMask isItGround;
    public bool grounded;
    public float groundDrag;

    Vector3 moveDirection;

    //Прыжок
    [Header("For Jumping")]
    public float jumpForce;
    public float StandartJumpForce;
    public float jumpCooldown;
    public float airMulti;
    bool isReadyToJump;

    //Приседание
    [Header("For Crouch")]
    public float centerStandYHeight;
    public float standingColliderHeight;
    public float centerCrouchYHeight;
    public float crouchColliderHeight;
    private CapsuleCollider characterCapsuleCollider;
    public float crouchSpeed;

    //скольжение
    [Header("SlopeHanding")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("_______For Res_______")]


    [Header("_______For Curio_______")]
    [Header("Ground Pound")]
    public float groundPoundForce = 30f;
    public float groundPoundCooldown = 0.3f;
    public bool isGroundPounding = false;
    public bool canGroundPound = true;
    public static bool GroundPoundActivated = false;


    Rigidbody rb;
    bool isOnPad = true;

    [Header("_______For BlendTree_______")]//_____Для дерева анимаций____\\
    public static float velocity = 0.0f;
    float acceleration = 2f;
    int VelocityHash;

    public MovementState state;
    public enum MovementState
    {
        walking,
        running,
        air,
        swinging,
        crouching,
        wallRunning
    }

    void Start()
    {
        jumpForce = StandartJumpForce;
        characterCapsuleCollider = GetComponent<CapsuleCollider>();
        isReadyToJump = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    private void Update()
    {

        if (isOnPad == true)
        {
            isOnPad = false;
            jumpForce = StandartJumpForce;
        }
        /*__________________Приседание__________________*/
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            characterCapsuleCollider.height = crouchColliderHeight;

            Vector3 center = characterCapsuleCollider.center;
            center.x = 0;
            center.y = centerCrouchYHeight;
            center.z = 0;
            characterCapsuleCollider.center = center;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterCapsuleCollider.height = standingColliderHeight;

            Vector3 center = characterCapsuleCollider.center;
            center.x = 0;
            center.y = centerStandYHeight;
            center.z = 0;
            characterCapsuleCollider.center = center;

        }
        /*___________________________________________*/

        if (isGroundPounding && grounded)
        {
            EndGroundPound();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isReadyToJump && grounded && !isGroundPounding)
            {
                isReadyToJump = false;
                Jump();
                animator.SetBool("isJumping", true);
                Invoke(nameof(ResetJump), jumpCooldown);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                if (Input.GetKeyDown(KeyCode.Space) && !grounded && canGroundPound && !isGroundPounding && isCurio && rb.velocity.y < 99)
                {
                    StartGroundPound();
                }
            }
        }
    }

    private void FixedUpdate()
    {

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, isItGround);


        //______Функции______\\
        MovePlayer();
        SpeedControl();
        StateHandler();
        //_________________\\


        //___________Плавный поворот модели персонажей___________\\
        if (moveDirection != Vector3.zero)
        {
            float targenAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targenAngle, ref smoothTurnVelocity, smoothTurnTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        //_______________________________________________\\


        //___________Бег и проверка, стоит ли перс на месте_____________\\
        else if (moveDirection == Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            VelocityHash = Animator.StringToHash("MovementTree");
            velocity = 0f;
            animator.SetFloat(VelocityHash, velocity);
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            VelocityHash = Animator.StringToHash("MovementTree");
            velocity = 1f;
            animator.SetFloat(VelocityHash, velocity);
        }

        else if (moveDirection == Vector3.zero)
        {
            animator.SetBool("isWalking", false);
        }
        
    }
      //______________________________________________________________\\

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (OnSlope() && !exitingSlope)
        {
            VelocityHash = Animator.StringToHash("MovementTree");
            rb.AddForce(GetSlopeMoveDirection() * movementSpeed * 20f, ForceMode.Force);
            velocity = 0f;
            animator.SetBool("isWalking", true);
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * movementSpeed * 10f * airMulti, ForceMode.Force);
            rb.useGravity = !OnSlope();
        }
        animator.SetFloat(VelocityHash, velocity);
    }
    private void Jump()
    {
        exitingSlope = true;
        rb.drag = 0f;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        exitingSlope = false;
        animator.SetBool("isJumping", false);
        isReadyToJump = true;
    }

    //_____________Для перемещения, попав крюком по цели__________________//
    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        rb.velocity = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
    }
    //_______________________________//

    private void SpeedControl()
    {
        if (OnSlope())
        {
            if (rb.velocity.magnitude > movementSpeed)
            {
                rb.velocity = rb.velocity.normalized * movementSpeed;
            }
        }
        else
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            if (flatVelocity.magnitude > movementSpeed)
            {
                Vector3 limitVelocity = flatVelocity.normalized * movementSpeed;
                rb.velocity = new Vector3(limitVelocity.x, rb.velocity.y, limitVelocity.z);
            }
        }
    }

    //___________В каком состоянии находится персонаж__________//

    private void StateHandler()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {

            animator.SetBool("isWalking", false);
            animator.SetBool("isCrouching", true);
            VelocityHash = Animator.StringToHash("CrouchTree");
            velocity = 0f;
            animator.SetFloat(VelocityHash, velocity);
            movementSpeed = crouchSpeed;

            if (moveDirection.magnitude > 0f && Input.GetKey(KeyCode.LeftControl))
            {
                VelocityHash = Animator.StringToHash("CrouchTree");
                velocity = 1f;
                animator.SetFloat(VelocityHash, velocity);
            }
        }
        else
        {
            animator.SetBool("isCrouching", false);
        }

        if (grounded && Input.GetKey(KeyCode.LeftShift))
        {

            VelocityHash = Animator.StringToHash("MovementTree");
            velocity = 1f;
            animator.SetFloat(VelocityHash, velocity);
            movementSpeed = runningSpeed;
        }
        if (grounded && Input.GetKey(KeyCode.LeftShift))
        {

            VelocityHash = Animator.StringToHash("MovementTree");
            velocity = 1f;
            animator.SetFloat(VelocityHash, velocity);
            movementSpeed = runningSpeed;
        }
        else if (grounded)
        {
            VelocityHash = Animator.StringToHash("MovementTree");
            velocity = 0f;
            animator.SetFloat(VelocityHash, velocity);

            animator.SetBool("isWalking", true);
            movementSpeed = walkSpeed;
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isCrouching", false);
        }

    }
    //___________________________//


    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    //________________________Удар о землю_____________________//
    public void StartGroundPound()
    {
        isGroundPounding = true;
        canGroundPound = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.down * groundPoundForce, ForceMode.Impulse);
        GroundPoundActivated = true;
    }

    public void EndGroundPound()
    {
        if (isGroundPounding)
        {
            isGroundPounding = false;
            Invoke(nameof(ResetGroundPound), groundPoundCooldown);
            GroundPoundActivated = false;
        }
    }

    public void ResetGroundPound()
    {
        canGroundPound = true;
    }

    //__________________//


    //________________________При прикосновении с панелью прыжка__________________________//
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("JumpPad"))
        {
            isOnPad = true;

            JumpPad jumpPadScr = collider.GetComponent<JumpPad>();
            JumpFromPad(jumpPadScr.JumpHeight);
        }
    }

    private void JumpFromPad(float jumpHeight)
    {
        exitingSlope = true;
        jumpForce = jumpHeight;
        rb.drag = 0f;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    //______________________________________________________________________//


    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.x);
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));
        return velocityXZ + velocityY;
    }

}
