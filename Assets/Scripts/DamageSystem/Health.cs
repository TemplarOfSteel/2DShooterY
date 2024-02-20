using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]
    private UI_Bar _healthbar;

    [SerializeField]
    private float _health = 100;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _healthbar.SetFill(_currentHealth / _health);
    }
}
