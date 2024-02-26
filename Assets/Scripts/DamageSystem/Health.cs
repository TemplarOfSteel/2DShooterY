using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if(_currentHealth <= 0)
        {
            Application.Quit();
            SceneManager.LoadScene(0);
        }
    }
}
