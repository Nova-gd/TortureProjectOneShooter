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
        [SerializeField] private TimeCount _timeCount;

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
                Time.timeScale = 0;

                Debug.Log("����� � ���� �������");

                Debug.Log("�������");

                Time.timeScale = 1;

                Debug.Log("����� � ���� �������������");
            }
        }
    }