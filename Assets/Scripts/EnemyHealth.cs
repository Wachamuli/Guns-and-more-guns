using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 5f;
    [SerializeField] private float _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}