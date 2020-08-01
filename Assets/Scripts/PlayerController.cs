using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public CharacterController characterController;
    [Range(0f, 20f)] public float speed = 10f;

    [Header("Jump")]
    private float _gravity = -9.81f;
    [Range(0, 100)]
    [SerializeField] private float _mass = 1;
    private Vector3 _velocity;
    [SerializeField] private float jumpForce = 0.5f;
    public Transform groundChecker;
    private float _radius = 0.5f;
    public LayerMask ground;
    bool isGrounded;

    [Header("Camera ajusment")]
    public Transform cam;
    public float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    public float sensivity = 0.1f;

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
        float x = AimCameraController.AimingOrNot(sensivity, speed);
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(x, 0f, z).normalized;

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            speed = Input.GetKey(KeyCode.LeftShift) ? speed = 20f : speed = 10f;

            characterController.Move(movDir.normalized * speed * Time.deltaTime);
        }
    }

    void PlayerJump()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, _radius, ground);

        _velocity.y += (_gravity * _mass * Time.deltaTime);

        characterController.Move(_velocity * Time.deltaTime);

        if (isGrounded && _velocity.y < 0)
            _velocity.y = -2f;
        

        if (Input.GetKeyDown("space") && isGrounded)
            _velocity.y = Mathf.Sqrt(jumpForce * _velocity.y * _gravity);
    }
}
