using System.Dynamic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{


    [SerializeField]
    [Range(0.5f, 2.0f)]
    private float fireRate = 1f;

    [SerializeField]
    private float damage = 1f;
    private float timer;
    private delegate void DelGun();

    private void Update() 
    {
        fireRateManager(Gun);
    }

    private void fireRateManager(DelGun FireGun)
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void Gun()
    {
        Debug.DrawRay(transform.position, transform.forward * 100f , Color.red, 2.0f);
    }
}