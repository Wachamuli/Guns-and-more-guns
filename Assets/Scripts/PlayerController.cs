using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController characterController;
    [Range(0f, 20f)] public float speed = 10f;

    [Header("Jump")]
    public float gravity = -9.81f;
    [Range(0, 100)]
    public float mass = 1;
    public Vector3 velocity;
    public float jumpForce = 0.5f;
    public Transform GroundChecker;
    public float radius = 0.5f;
    public LayerMask ground;
    bool isGrounded;

    [Header("Camera ajusment")]
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        cam = GetComponent<Transform>().GetChild(1);
    }

    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, 0f, z).normalized;

        if (movement.magnitude >= 0.1f)
        {
            //? Take a look
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            speed = Input.GetKey(KeyCode.LeftShift) ? speed = 20f : speed = 10f;

            characterController.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }

    void PlayerJump()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, radius, ground);

        velocity.y += (gravity * mass * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * velocity.y * gravity);
        }
    }
}
