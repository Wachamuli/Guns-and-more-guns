using UnityEngine;

namespace MyPhysics
{
    public class PlayerPhysics : MonoBehaviour
    {
        public CharacterController characterController;

        [Header("Properties")]
        public float gravity = -9.81f;
        [Range(0, 100)] public float mass = 1;
        public Vector3 velocity;

        [Header("Ground Analyzer")]
        public Transform groundChecker;
        [SerializeField] private float _radius = 0.5f;
        public LayerMask ground;
        public bool isGrounded;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Gravity();
        }

        public void Gravity()
        {
            isGrounded = Physics.CheckSphere(groundChecker.position, _radius, ground);

            velocity.y += (gravity * mass * Time.deltaTime);

            characterController.Move(velocity * Time.deltaTime);

            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;
        }
    }
}
