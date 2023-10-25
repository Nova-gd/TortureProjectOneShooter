using Agava.WebUtility;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Vector3 cameraStartPosition = new Vector3(0.03f, 1.95f, -1.37f);
    [SerializeField] private Vector3 cameraEndPosition = new Vector3(0.00f, 1.58f, 0.00f);
    [SerializeField] private Quaternion cameraEndRotation = Quaternion.Euler(0f, 180f, 0f);
    [SerializeField] private float cameraMoveSpeed = 5f;
    [SerializeField] private Transform projectileSource;
    [SerializeField] private GameObject playerProjectilePrefab;
    [SerializeField] private float projectileSpeed = 80f;
    [SerializeField] private int _projectileCount = 5;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _shootButton;
    [SerializeField] private Button _aimButton;
    [SerializeField] private Image _aimIcon;

    private Camera _playerCamera;
    private bool isCameraMoving = false;
    private bool isCameraAtStartPosition = true;
    private bool canShoot = false;
    private PlayerMotorTest _playerMotorTest;
    private CharacterController _characterController;
    private AudioSource _shootSound;

    public int ProjectileCount => _projectileCount;

    private void Start()
    {
        _playerCamera = GetComponent<PlayerLook>().Camera;
        _playerMotorTest = GetComponent<PlayerMotorTest>();
        _characterController = GetComponent<CharacterController>();
        _shootSound = GetComponentInChildren<AudioSource>();
        _projectileCount += _gameManager.LoadMaxProjectile();

        _shootButton.onClick.AddListener(ShootProjectile);
        _aimButton.onClick.AddListener(Aim);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isCameraMoving)
        {
            Aim();
        }

        ShootProjectile();
    }

    private void Aim()
    {
        if (isCameraAtStartPosition)
        {
            MoveCameraToPosition(cameraEndPosition, cameraEndRotation);
            _aimIcon.gameObject.SetActive(true);
            canShoot = true;
            _characterController.enabled = false;
            _playerMotorTest.enabled = false;
        }
        else
        {
            MoveCameraToPosition(cameraStartPosition, Quaternion.identity);
            _aimIcon.gameObject.SetActive(false);
            canShoot = false;
            _characterController.enabled = true;
            _playerMotorTest.enabled = true;
        }
    }

    private void MoveCameraToPosition(Vector3 targetPosition, Quaternion targetRotation)
    {
        if (_playerCamera == null) return;
        StartCoroutine(MoveCameraCoroutine(targetPosition, targetRotation));
    }

    private System.Collections.IEnumerator MoveCameraCoroutine(Vector3 targetPosition, Quaternion targetRotation)
    {
        isCameraMoving = true;
        Vector3 startPosition = _playerCamera.transform.localPosition;
        Quaternion startRotation = _playerCamera.transform.localRotation;
        float startTime = Time.time;

        while (Time.time < startTime + cameraMoveSpeed)
        {
            float t = (Time.time - startTime) / cameraMoveSpeed;
            _playerCamera.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            _playerCamera.transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

        _playerCamera.transform.localPosition = targetPosition;
        _playerCamera.transform.localRotation = targetRotation;
        isCameraMoving = false;
        isCameraAtStartPosition = !isCameraAtStartPosition;
    }

    private void ShootProjectile()
    {
        if (!Device.IsMobile)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                if (_projectileCount > 0)
                {
                    _projectileCount--;

                    _shootSound.Play();

                    GameObject projectile = Instantiate(playerProjectilePrefab, projectileSource.position, _playerCamera.transform.rotation);
                    Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

                    Vector3 shootDirection = _playerCamera.transform.forward;
                    projectileRigidbody.velocity = shootDirection * projectileSpeed;

                    projectile.transform.Rotate(90f, 0f, 0f);
                }
            }

        }

        if (Device.IsMobile)
        {
            if (canShoot)
            {
                if (_projectileCount > 0)
                {
                    _projectileCount--;

                    _shootSound.Play();

                    GameObject projectile = Instantiate(playerProjectilePrefab, projectileSource.position, _playerCamera.transform.rotation);
                    Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

                    Vector3 shootDirection = _playerCamera.transform.forward;
                    projectileRigidbody.velocity = shootDirection * projectileSpeed;

                    projectile.transform.Rotate(90f, 0f, 0f);
                }
            }

        }
    }

    public void SetProjectileCount()
    {
        _projectileCount++;
    }
}
