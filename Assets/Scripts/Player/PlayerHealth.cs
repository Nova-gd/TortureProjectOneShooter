using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TimeCount _timeCount;



    private float _currentHealth;
    private float _minHealth = 0;
    private Animator _animator;
    private PlayerMotorTest _playerMotorTest;
    private CharacterController _characterController;
    private InputManger _input;
    private bool _isAlive = true;
    private float _delayBeforePlayerDead = 2f;

    public float MaxHealth => _maxHealth;
    public float MinHealth => _minHealth;
    public float CurrentHealth => _currentHealth;
    public bool IsAlive => _isAlive;


    public event Action<float> HealthChange;

    private void Awake()
    {
        _maxHealth += _gameManager.LoadMaxHealth();
        _currentHealth = _maxHealth;
        _animator = GetComponentInChildren<Animator>();
        _animator.SetFloat("health", _currentHealth);
        _playerMotorTest = GetComponent<PlayerMotorTest>();
        _characterController = GetComponent<CharacterController>();        
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
        StartCoroutine(DelayBeforePlayerDead());
    }

    private void RestartLevel()
    {
        //_timeCount.ActualTime = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator DelayBeforePlayerDead()
    { 
        yield return new WaitForSeconds(_delayBeforePlayerDead);
        RestartLevel();
    }
}