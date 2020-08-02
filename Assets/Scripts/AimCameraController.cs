using UnityEngine;
using Cinemachine;

public class AimCameraController : MonoBehaviour
{
    public CharacterController characterController;
    public Transform player;

    [Header("Aim Camera")]
    public CinemachineComposer composer;
    [Range(0.01f, 10.0f)] public float sensitiveXAxis = 1f;
    [Range(0.01f, 10.0f)] public float sensitiveYAxis = 0.1f;
    public static bool isAiming;

    void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }

    void Update()
    {
        CameraController();
    }

    private void CameraController()
    {
        isAiming = true;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitiveYAxis;

        composer.m_TrackedObjectOffset.y += mouseY;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1f, 2.5f);

        float x = Input.GetAxisRaw("Mouse X") * sensitiveXAxis;
        player.transform.Rotate(Vector3.up, x * 100f * Time.deltaTime);
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
