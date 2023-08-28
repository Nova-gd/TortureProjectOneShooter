using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CountDeadMage : MonoBehaviour
{
    [SerializeField] private Text _enemyCountText;    
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerGolds _playerGold;

    private int _deadMages = 0;
    private float _delayBeforeNextLvl = 3f;

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
            StartCoroutine(DelayBeforeNextLvl());
        }
    }

    private IEnumerator DelayBeforeNextLvl()
    {        
        yield return new WaitForSeconds(_delayBeforeNextLvl);
        _gameManager.SaveGold(_playerGold.Golds);
        _gameManager.SaveScene();

        CompleteLevel();
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("ShopScreen");        
    }
}
