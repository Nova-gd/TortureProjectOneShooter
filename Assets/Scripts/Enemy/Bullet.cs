//using System.Collections;
//using System.Collections.Generic;
//using DG.Tweening;
//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    private const string Target = nameof(Target);

//    [SerializeField] private List<TrailRenderer> _trailRenderer;
//    [SerializeField] private AudioSource _audioSource;
//    [SerializeField] private AudioSource _hitSound;
//    [SerializeField] private ParticleSystem _hitEffect;
//    [SerializeField] private ProjectilePopUp _popUp;

//    private Rigidbody _rigidbody;
//    private float _damage;
//    private Sequence _sequence;
//    private float _distance;
//    private float _speed;
//    private Coroutine _flyingToDoDamage;
//    private RaycastHit[] _objects;
//    private Ray _ray;
//    private bool _isFlying;
//    private bool _isHaveTarget;

//    public float Damage => _damage;

//    private void Awake()
//    {
//        _rigidbody = GetComponent<Rigidbody>();
//    }

//    public void FlyForward()
//    {
//        float Distance = Vector3.Distance(transform.position, transform.position + (transform.forward * _distance));

//        _ray = new Ray(transform.position, transform.forward);

//        _objects = Physics.RaycastAll(_ray, Distance);

//        if (_objects.Length != 0)
//        {
//            foreach (var target in _objects)
//            {
//                if (target.transform.tag == Target)
//                    if (_flyingToDoDamage == null)
//                        _isHaveTarget = true;
//            }
//        }

//        _isFlying = true;
//        //_flyingToDoDamage = StartCoroutine(FlyingToDoDamage());
//    }

//    public void SetProjectileParams(float damageValue, WeaponInfo weaponInfo)
//    {
//        _damage = damageValue;
//        _distance = weaponInfo.AttackDistance;
//        _speed = weaponInfo.ProjectileSpeed;
//    }

//    public void CleanTrail()
//    {
//        foreach (var renderer in _trailRenderer)
//        {
//            renderer.Clear();
//        }
//    }

//    public void ReturnTOPool()
//    {
//        if (_flyingToDoDamage != null)
//        {
//            _isFlying = false;
//            StopCoroutine(_flyingToDoDamage);
//            _flyingToDoDamage = null;
//        }


//        gameObject.SetActive(false);
//    }

//    private IEnumerator FlyingToDoDamage()
//    {
//        var dealy = new WaitForFixedUpdate();
//        float oneFixedUpdateDistance = _distance / _speed * Time.fixedDeltaTime;
//        float remainTime = _speed;

//        while (_isFlying)
//        {
//            if (_isHaveTarget)
//            {
//                _ray = new Ray(transform.position, transform.forward);
//                Debug.DrawRay(transform.position, transform.forward * oneFixedUpdateDistance);
//                _objects = Physics.RaycastAll(_ray, oneFixedUpdateDistance);


//                if (_objects.Length != 0)
//                {
//                    foreach (var target in _objects)
//                    {
//                        if (target.transform.tag == Target)
//                        {
//                            _hitEffect.transform.parent = null;
//                            _hitSound.transform.parent = null;
//                            _hitEffect.transform.position = target.point;
//                            _hitSound.transform.position = target.point;
//                            _hitEffect.transform.rotation = Quaternion.LookRotation(target.normal);

//                            _hitEffect.Play();
//                            _hitSound.Play();
//                            transform.position = target.point;

//                            _audioSource.Play();
//                            target.transform.gameObject.BroadcastMessage("ApplyDamage", _damage);

//                            var popUp = Instantiate(_popUp, this.transform);
//                            popUp.gameObject.SetActive(true);
//                            popUp.PlayPopUp(_damage);

//                            ReturnTOPool();

//                            break;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}