using UnityEngine;
using Cinemachine;

public class AimCameraController : MonoBehaviour
{
    [Header("Aim Camera")]
    [SerializeField] private CinemachineComposer _composer;
    [SerializeField] [Range(0.01f, 50.0f)] private float _sensitiveXAxis = 30f;
    [SerializeField] [Range(0.01f, 10.0f)] private float sensitiveYAxis = 0.1f;
    [SerializeField] private static bool _isAiming;

    void Update()
    {
        CameraController();
    }

    private void CameraController()
    {

        if (Input.GetKey(KeyCode.Mouse1))
            _isAiming = true;
        else
            _isAiming = false;
            
        if (_isAiming)
        {
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensitiveYAxis;
            _composer.m_TrackedObjectOffset.y += mouseY;
            _composer.m_TrackedObjectOffset.y = Mathf.Clamp(_composer.m_TrackedObjectOffset.y, -1f, 2.5f);

            float x = Input.GetAxisRaw("Mouse X") * _sensitiveXAxis;
            transform.Rotate(Vector3.up, x * Time.deltaTime);
        }
    }
}