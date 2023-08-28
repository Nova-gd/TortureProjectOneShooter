using UnityEngine;

public class UpgradeHealth : Upgrade
{
    [SerializeField] private int _healthIncrease = 60;
    [SerializeField] private int _moneyForUpgrade = 2;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ApplyUpgrade()
    {
        if (_gameManager.CollectedCoins >= _moneyForUpgrade) 
        {
            _gameManager.SetGold(_moneyForUpgrade);
            _audioSource.Play();
            _gameManager.SaveMaxHealth(_healthIncrease);
        }        
    }
}
