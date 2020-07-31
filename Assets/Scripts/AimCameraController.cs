using UnityEngine;
using Cinemachine; //Librería para el uso de Cinemachine

public class AimCameraController : MonoBehaviour
{
    public CinemachineComposer composer; //Modificaré el composer de la virtual camera
    [Range(1, 10)] public float sensivity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {        
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
        //Se toma el componente general que es CinemachineVirtualCamera
        //Y recordando que Cinemachine por si mismo tiene sus propios componentes, tomo uno que se encuetra dentro de este...
        //... con GetCinemachi...<CinemachineComposer>(), en este caso
    }

    // Update is called once per frame
    void Update()
    {
        CameraController();
    }

    void CameraController()
    {
        //float mouseX = Input.GetAxisRaw("Mouse X") * sensivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensivity;

        //composer.m_TrackedObjectOffset.x += mouseX;
        composer.m_TrackedObjectOffset.y += mouseY;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -1f, 2.5f);
    }
}
