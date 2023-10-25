using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitive : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Slider _mouseSensitiveSlider;

    private float _mouseSensitivity;

    private void Start()
    {
        _mouseSensitivity = _gameManager.LoadMouseSensitive();

        _mouseSensitiveSlider.value = _mouseSensitivity;

        _mouseSensitiveSlider.onValueChanged.AddListener(OnMouseSensitivityChanged);
    }

    private void OnMouseSensitivityChanged(float newValue)
    {
        _mouseSensitivity = newValue;
        _gameManager.SaveMouseSensitive(_mouseSensitivity);
    }


}
