using UnityEngine;

public class UpgradeDmg : Upgrade
{
    [SerializeField] private int _dmgIncrease = 111;
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
            _gameManager.SaveMaxDmg(_dmgIncrease);
        }
    }
}
