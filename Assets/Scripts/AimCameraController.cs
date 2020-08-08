using UnityEngine;
using Cinemachine;

public class AimCameraController : MonoBehaviour
{
    [Header("Aim Camera")]

    public CinemachineComposer composer;

    [Range(0.01f, 50.0f)]
    [SerializeField]
    private float sensitiveXAxis = 30f;

    [Range(0.01f, 10.0f)]
    [SerializeField]
    private float sensitiveYAxis = 0.1f;
    public static bool isAiming;

    void Update()
    {
        CameraController();
    }

    private void CameraController()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isAiming = true;
        }
        else
        {
            isAiming = false;
        }

        if (isAiming)
        {
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensitiveYAxis;
            composer.m_TrackedObjectOffset.y += mouseY;
            composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1f, 2.5f);

            float x = Input.GetAxisRaw("Mouse X") * sensitiveXAxis;
            transform.Rotate(Vector3.up, x * Time.deltaTime);
        }
    }
}