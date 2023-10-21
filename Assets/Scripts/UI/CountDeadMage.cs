using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Agava.YandexGames;
using System;


public class CountDeadMage : MonoBehaviour
{
    [SerializeField] private Text _enemyCountText;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerGolds _playerGold;
    [SerializeField] private TimeCount _timeCount;

    private int _deadMages = 0;
    private float _delayBeforeNextLvl = 3f;

    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorOccured;

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.EnemyDie += OnEnemyDestroyed;
        }        
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.EnemyDie -= OnEnemyDestroyed;
        }
    }

    private void Start()
    {
        UpdateEnemyCountText();
    }

    public void OnEnemyDestroyed(Enemy enemy)
    {
        enemy.EnemyDie -= OnEnemyDestroyed;
        _deadMages++;
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        int totalEnemies = _enemies.Count;
        _enemyCountText.text = _deadMages.ToString() + " / " + totalEnemies.ToString();

        if (_deadMages >= _enemies.Count)
        {
            _gameManager.SaveGold(_playerGold.Golds);
            _timeCount.StopTimer();

            _gameManager.SaveTime(_gameManager.LoadTime() + _timeCount.LevelSpendTime);

            int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
            _gameManager.SaveScene(actualSceneIndex + 1);

            StartCoroutine(DelayBeforeNextLvl());
        }
    }

    private IEnumerator DelayBeforeNextLvl()
    {
        yield return new WaitForSeconds(_delayBeforeNextLvl);

        CompleteLevel();
    }

    private void CompleteLevel()
    {
        ShowAds();

        SceneManager.LoadScene("ShopScreen");
    }

    private void ShowAds()
    {
        if (SceneManager.GetActiveScene().name != "1 lvl")
        {
            InterstitialAd.Show(OnAdOpen, OnAdClose, _adErrorOccured);
        }
    }

    private void OnAdClose(bool state)
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
    }

    private void OnAdOpen()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
    }
}