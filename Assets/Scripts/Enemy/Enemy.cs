using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Range(0.1f, 10)] public float fireRate;
    public Transform SourceOfDamage;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private string _currentState;
    [SerializeField] private GameObject _player;
    [SerializeField] private Path _path;
    [SerializeField] private GameObject _coinPrefab;      

    private int _currentHealth;
    private int _minHealth = 0;
    private StateMachine _stateMachine;
    private NavMeshAgent _agent;
    private Vector3 _lastKnowPos;
    private TargetDetective _targetDetective;
    private float _signDistance = 20f;
    private float _fieldOfView = 85f;
    private float _eyeHight;   
    private AudioSource _takeDamageSound;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public Path Path => _path;
    public NavMeshAgent Agent { get => _agent; }
    public GameObject Player { get => _player; }
    public Vector3 LastKnowPos { get => _lastKnowPos; set => _lastKnowPos = value; }

    public event Action<Enemy> EnemyDie;

    void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
        _agent = GetComponent<NavMeshAgent>();
        _stateMachine.Initialise();
        _currentHealth = _maxHealth;
        _targetDetective = GetComponentInChildren<TargetDetective>();
        _takeDamageSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        CanSeePlayer();
        _currentState = _stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (_targetDetective.PlayerHealth != null && _targetDetective.PlayerHealth.IsAlive)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < _signDistance)
            {
                Vector3 targetDirection = _player.transform.position - transform.position - (Vector3.up * _eyeHight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angleToPlayer >= -_fieldOfView && angleToPlayer <= _fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * _eyeHight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();

                    if (Physics.Raycast(ray, out hitInfo, _signDistance))
                    {

                        if (hitInfo.transform.gameObject == _player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * _signDistance);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= 0)
        {
            _currentHealth -= damage;

            _takeDamageSound.Play();

            _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

            if (_currentHealth <= 0)
            {                
                EnemyDie?.Invoke(this);
                DropCoin();
                gameObject.SetActive(false);
            }
        }
    }

    private void DropCoin()
    {        
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
    }
}
