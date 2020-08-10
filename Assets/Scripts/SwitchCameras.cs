using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    [SerializeField] private GameObject _thirdPersonCamera;
    [SerializeField] private GameObject _aimCamera;

    private void Update()
    {
        SwitchFreeOrAim();
    }

    void SwitchFreeOrAim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _thirdPersonCamera.SetActive(false);

            _aimCamera.SetActive(true);
        }
        else
        {
            _thirdPersonCamera.SetActive(true);
            
            _aimCamera.SetActive(false);
        }
    }
}