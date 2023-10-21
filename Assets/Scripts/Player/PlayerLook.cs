using Agava.WebUtility;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _xSensitivity = 30f;
    [SerializeField] private float _ySensitivity = 30f;
    [SerializeField] private FixedJoystick _joystick;

    private int _visionArea = 80;

    public Camera Camera => _camera;

    private float _xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        if (!Device.IsMobile)
        {
            float mouseX = input.x;
            float mouseY = input.y;

            _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -_visionArea, _visionArea);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
        }


        if (Device.IsMobile)
        {
            float joystickHorizontal = _joystick.Horizontal;
            float joystickVertical = _joystick.Vertical;

            _xRotation -= (joystickVertical * Time.deltaTime) * _ySensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -_visionArea, _visionArea);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            transform.Rotate(Vector3.up * (joystickHorizontal * Time.deltaTime) * _xSensitivity);
        }
    }
}
