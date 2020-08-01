using System.IO.MemoryMappedFiles;
using UnityEngine;
using Cinemachine; //Librería para el uso de Cinemachine

public class AimCameraController : MonoBehaviour
{
    [Header("Camera")]
    public CinemachineComposer composer;
    [Range(0.00000001f, 10.0f)] public float sensitive = 1.0f;
    public static bool isAiming;
    public CharacterController characterController;
    public Transform player;
    //private float turnSmoothVelocity;
    //private float turnSmoothTime;
    //public Transform cam;

    void Start()
    {
        //characterController = GetComponentInParent<CharacterController>();
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        //player = GetComponentInParent<Transform>();
    }

    void Update()
    {
        CameraController();
    }

    private void CameraController()
    {
        isAiming = true;
        //float mouseX = Input.GetAxisRaw("Mouse X") * sensitive;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitive;

        //composer.m_TrackedObjectOffset.x += mouseX;
        composer.m_TrackedObjectOffset.y += mouseY;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1f, 2.5f);
    }

    public static float AimingOrNot(float mouseSensitive, float speed)
    {
        float key = Input.GetAxisRaw("Horizontal");
        float mouse = Input.GetAxisRaw("Mouse X");

        float Horizontal = isAiming ? mouse * mouseSensitive * Time.deltaTime : key * speed * Time.deltaTime;
        isAiming = false;

        return Horizontal;
    }
}
