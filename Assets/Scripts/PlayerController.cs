using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] private MyPhysics _myPhysics;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] [Range(0f, 20f)]private float _speed = 10f;

    [Header("Jump")]

    [SerializeField] private float _jumpForce = 1.0f;

    [Header("Camera ajusment")]

    [SerializeField] private Transform _cam;
    
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _characterController = GetComponent<CharacterController>();
        _cam = GetComponent<Transform>().GetChild(2);
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
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _speed = Input.GetKey(KeyCode.LeftShift) ? _speed = 20f : _speed = 10f;

            _characterController.Move(movDir.normalized * _speed * Time.deltaTime);
        }
    }

    void PlayerJump()
    {
        _myPhysics.Gravity();

        if (Input.GetKeyDown("space") && _myPhysics.isGrounded)
            _myPhysics.velocity.y = Mathf.Sqrt(_jumpForce * _myPhysics.velocity.y * _myPhysics.gravity);
    }
}