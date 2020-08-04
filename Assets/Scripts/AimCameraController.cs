using UnityEngine;
using Cinemachine;

public class AimCameraController : MonoBehaviour
{
    public Transform player;

    [Header("Aim Camera")]

    [SerializeField]
    private CinemachineComposer composer;

    [Range(0.01f, 50.0f)] 
    [SerializeField] 
    private float sensitiveXAxis = 30f;

    [Range(0.01f, 10.0f)] 
    [SerializeField] 
    private float sensitiveYAxis = 0.1f;
    public static bool isAiming;

    void Start()
    { 
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        //player.transform.SetPositionAndRotation(player.transform.position, this.transform.rotation);
    }

    void Update()
    {
        CameraController();
        //FixPosition();
    }

    private void CameraController()
    {
        isAiming = true;

        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitiveYAxis;
        composer.m_TrackedObjectOffset.y += mouseY;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1f, 2.5f);

        float x = Input.GetAxisRaw("Mouse X") * sensitiveXAxis;
        player.transform.Rotate(Vector3.up, x * Time.deltaTime);
    }

    private void FixPosition()
    {
       
    }
}