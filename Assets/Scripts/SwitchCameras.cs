using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    public GameObject aimCamera;
    public GameObject aimSight;

    private void Update()
    {
        SwitchFreeOrAim();
    }

    void SwitchFreeOrAim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            thirdPersonCamera.SetActive(false);

            aimCamera.SetActive(true);
            aimSight.SetActive(true);
        }
        else
        {
            thirdPersonCamera.SetActive(true);
            
            aimCamera.SetActive(false);
            aimSight.SetActive(false);
        }
    }
}