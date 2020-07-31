using UnityEngine;

public class FreeOrAimCamera : MonoBehaviour {

    public GameObject aimCamra;

    private void Update() 
    {
        //SwitchCmaeras();
    }

    void SwitchCmaeras()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            aimCamra.SetActive(true);
        }
        else
        {
            aimCamra.SetActive(false);
        }
    }
}