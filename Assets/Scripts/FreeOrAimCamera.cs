using UnityEngine;

public class FreeOrAimCamera : MonoBehaviour {

    public GameObject aimCamera;
    public GameObject aimSight;

    private void Update() 
    {
        SwitchCameras();
    }

    void SwitchCameras()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            aimCamera.SetActive(true);
            aimSight.SetActive(true);
        }
        else
        {
            aimCamera.SetActive(false);
            aimSight.SetActive(false);
        }

    }
}