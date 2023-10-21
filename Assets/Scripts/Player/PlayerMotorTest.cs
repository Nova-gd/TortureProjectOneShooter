using UnityEngine;
using Agava.WebUtility;

public class PlayerMotorTest : MonoBehaviour
{
    public bool CanMove { get; set; } = true;

    [SerializeField] private float _speed;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private FixedJoystick _joystick;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Animator _animator;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _speed += _gameManager.LoadMaxSpeed();
    }

    private void Update()
    {
        if (CanMove) 
        {
            if (Device.IsMobile)
            {
                float joystickHorizontal = _joystick.Horizontal;
                float joystickVertical = _joystick.Vertical;
                Vector2 joystickInput = new Vector2(joystickHorizontal, joystickVertical);
                ProcessMove(joystickInput);
            }

            if (!Device.IsMobile)
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                Vector2 input = new Vector2(horizontal, vertical);
                ProcessMove(input);
            }
        }

        //_controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _animator.SetBool("IsLeft", input.x < 0);
        _animator.SetBool("IsRight", input.x > 0);
        _animator.SetBool("IsForward", input.y > 0);
        _animator.SetBool("IsBack", input.y < 0);

        if (moveDirection != Vector3.zero) 
        {
            _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
        }
    }
}
