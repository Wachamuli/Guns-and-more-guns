using UnityEngine;

public class SwitchCameras : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    public GameObject aimCamera;

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
        }
        else
        {
            thirdPersonCamera.SetActive(true);
            
            aimCamera.SetActive(false);
        }
    }
}