using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private float _currentHealth;
    private float _minHealth = 0;
    private Animator _animator;
    private PlayerMotorTest _playerMotorTest;
    private CharacterController _characterController;
    private InputManger _input;
    private bool _isAlive = true;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public bool IsAlive => _isAlive;

    public event Action<float> HealthChange;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponentInChildren<Animator>();
        _animator.SetFloat("health", _currentHealth);
        _playerMotorTest = GetComponent<PlayerMotorTest>();
        _characterController = GetComponent<CharacterController>();
        //_input = GetComponent<InputManger>();
    }

    private void Start()
    {
        HealthChange?.Invoke(_currentHealth);
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= 0)
        {
            _currentHealth -= damage;

            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

            HealthChange?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                
                Die();
            }
        }
    }

    public void HealHealth(int heal)
    {
        if (heal >= 0)
        {
            _currentHealth += heal;

            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

            HealthChange?.Invoke(_currentHealth);
        }
    }

    private void Die()
    {
        _isAlive = false;
        _animator.SetFloat("health", _currentHealth);
        _characterController.enabled = false;
        _playerMotorTest.enabled = false;
        //_input.enabled = false;
    }
}