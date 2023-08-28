using TMPro;
using UnityEngine;

public class HealthPointview : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;
    [SerializeField] private TextMeshProUGUI _hPView;

    private void Start()
    {
        UpdateCountText();
    }

    private void Update()
    {
        UpdateCountText();
    }

    private void UpdateCountText()
    {
        float health = _health.CurrentHealth;
        _hPView.text = health.ToString();
    }
}
