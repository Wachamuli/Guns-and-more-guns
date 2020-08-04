using UnityEngine;
using PhysicsClass = MyPhysics.PlayerPhysics;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public PhysicsClass myPhysics;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    [Range(0f, 20f)]
    private float speed = 10f;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce = 1.0f;

    [Header("Camera ajusment")]
    
    [SerializeField]
    private Transform cam;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

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
        myPhysics.Gravity();

        if (Input.GetKeyDown("space") && myPhysics.isGrounded)
            myPhysics.velocity.y = Mathf.Sqrt(jumpForce * myPhysics.velocity.y * myPhysics.gravity);
    }
}