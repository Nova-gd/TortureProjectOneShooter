using UnityEngine;

public class InputManger : MonoBehaviour
{
    public PlayerInput.OnFootActions OnFoot;

    private PlayerInput _playerInput;    
    private PlayerMotorTest _motor;
    private PlayerLook _look;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        OnFoot = _playerInput.OnFoot;
        _motor = GetComponent<PlayerMotorTest>();
        _look = GetComponent<PlayerLook>();

        //OnFoot.Jump.performed += ctx => _motor.Jump();
    }

    private void FixedUpdate()
    {
        _motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>()); 
    }

    private void LateUpdate()
    {
        _look.ProcessLook(OnFoot.Look.ReadValue<Vector2>()); 
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }

    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
