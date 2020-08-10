using UnityEngine;
using Cinemachine;

public class Shoot : MonoBehaviour
{
    [Header("Gun")]

    [SerializeField] private float _damage = 1f;
    [SerializeField] [Range(0.5f, 2.0f)] private float _fireRate = 1f;
    [SerializeField] private float _recoil = 0.1f;
    [SerializeField] private CinemachineComposer _recoilComposer;
    [SerializeField] private float _maxDistance = 100f;

    private float _fireRateTimer;
    private delegate void DelGun();

    private void Update()
    {
        FireRateManager(GenericGun);
    }

    private void FireRateManager(DelGun FireGun)
    {
        _fireRateTimer += Time.deltaTime;

        if (_fireRateTimer >= _fireRate)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _fireRateTimer = 0f;
                FireGun();
            }
        }
    }

    private void GenericGun()
    {

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.5f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, _maxDistance))
        {
            var health = hitInfo.collider.GetComponent<EnemyHealth>();

            if (health != null)
                health.TakeDamage(_damage);
        }

        Recoil();
    }

    private void Recoil()
    {
        _recoilComposer.m_TrackedObjectOffset.y += _recoil;
    }
}