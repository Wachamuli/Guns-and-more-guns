using UnityEngine;
using Cinemachine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Gun")]

    [SerializeField]
    [Range(0.5f, 2.0f)]
    private float fireRate = 1f;

    [SerializeField]
    private float recoil = 0.1f;

    [SerializeField]
    private float damage = 1f;
    private float timer;

    [SerializeField]
    private float maxDistance = 100f;
    private delegate void DelGun();
    public CinemachineComposer composer;

    private void Update()
    {
        fireRateManager(GenericGun);
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

    private void GenericGun()
    {

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2.0f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, maxDistance))
        {
            var health = hitInfo.collider.GetComponent<EnemyHealth>();

            if (health != null)
                health.TakeDamage(damage);
        }

        Recoil(true);
    }

    //TODO:
    private void Recoil(bool shooted)
    {
        if (shooted)
        {
            composer.m_TrackedObjectOffset.y += recoil;
        }
    }
}