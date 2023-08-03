using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private Slider _slider;

    private Coroutine _valueChangeCoroutine;

    private void Awake()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.minValue = _health.MinHealth;
    }

    private void OnEnable()
    {
        _health.HealthChange += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.HealthChange -= OnValueChanged;
    }


    public void OnValueChanged(float value)
    {
        if (_valueChangeCoroutine != null)
        {
            StopCoroutine(_valueChangeCoroutine);
        }

        _valueChangeCoroutine = StartCoroutine(ChangingSlowly(value));
    }

    private IEnumerator ChangingSlowly(float value)
    {
        float speed = 100f;
        while (_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, speed * Time.deltaTime);
            yield return null;
        }

        _valueChangeCoroutine = null;
    }
}