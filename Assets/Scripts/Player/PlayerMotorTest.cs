using UnityEngine;

public class PlayerMotorTest : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private Animator _animator;
    public bool CanMove { get; set; } = true; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (CanMove) 
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 input = new Vector2(horizontal, vertical);
            ProcessMove(input);
        }

        _controller.Move(_playerVelocity * Time.deltaTime);
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
