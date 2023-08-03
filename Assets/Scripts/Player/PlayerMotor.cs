using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float gravity = -9.8f;
    //[SerializeField] private float jumpHeight = 3f;

    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool IsGrounded;
    private Animator _animator;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        IsGrounded = _controller.isGrounded;
    }

    public void ProcessMove (Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        _animator.SetBool("IsLeft", input.x < 0);
        _animator.SetBool("IsRight", input.x > 0);
        _animator.SetBool("IsForward", input.y > 0);
        _animator.SetBool("IsBack", input.y < 0);

        _controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        if (IsGrounded && _playerVelocity.y<0) 
        {
            _playerVelocity.y = -2f;
        }

        _playerVelocity.y += gravity * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    //public void Jump() 
    //{ 
    //    if (IsGrounded) 
    //    {
    //        _playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    //    }
    //} 
}
