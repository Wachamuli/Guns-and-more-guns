using UnityEngine;
using Cinemachine;

public class Shoot : MonoBehaviour
{
    [Header("Gun")]

    [SerializeField]
    private float damage = 1f;
    private float fireRateTimer;

    [SerializeField]
    [Range(0.5f, 2.0f)]
    private float fireRate = 1f;

    [SerializeField]
    private float recoil = 0.1f;
    private CinemachineComposer recoilComposer;

    [SerializeField]
    private float maxDistance = 100f;
    private delegate void DelGun();

    private void Update()
    {
        FireRateManager(GenericGun);
    }

    private void FireRateManager(DelGun FireGun)
    {
        fireRateTimer += Time.deltaTime;

        if (fireRateTimer >= fireRate)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                fireRateTimer = 0f;
                FireGun();
            }
        }
    }

    private void GenericGun()
    {

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.5f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, maxDistance))
        {
            var health = hitInfo.collider.GetComponent<EnemyHealth>();

            if (health != null)
                health.TakeDamage(damage);
        }

        Recoil();
    }

    private void Recoil()
    {
        recoilComposer.m_TrackedObjectOffset.y += recoil;
    }
}