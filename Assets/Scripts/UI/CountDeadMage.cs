using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDeadMage : MonoBehaviour
{
    [SerializeField] private Text _enemyCountText;
    private int _deadMages = 0;
    [SerializeField] private List<Enemy> _enemies; 

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
        _enemies.Remove(enemy);
        enemy.EnemyDie -= OnEnemyDestroyed;
        _deadMages++;
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        int totalEnemies = _enemies.Count;
        _enemyCountText.text = _deadMages.ToString() + " / " + totalEnemies.ToString();
    }
}
