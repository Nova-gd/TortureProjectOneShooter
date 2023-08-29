using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _collectedCoins;
    private int _sceneIndex;
    private int _addMaxHealth;
    private int _addProjectileMax;
    private int _addDmg;
    private int _addSpeed;

    public int CollectedCoins => _collectedCoins;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "1 lvl")
        {
            _collectedCoins = 0;
            PlayerPrefs.SetInt("CollectedCoins", _collectedCoins);

            _sceneIndex = 1;
            PlayerPrefs.SetInt("LevelProgress", _sceneIndex);

            _addMaxHealth = 0;
            PlayerPrefs.SetInt("MaxHealth", _addMaxHealth);

            _addProjectileMax = 0;
            PlayerPrefs.SetInt("MaxProjectileCount", _addProjectileMax);

            _addDmg = 0;
            PlayerPrefs.SetInt("AddDmg", _addDmg);

            _addSpeed = 0;
            PlayerPrefs.SetInt("AddSpeed", _addSpeed);
        }
    }

    private void Start()
    {
        _collectedCoins = LoadGold();
        _sceneIndex = LoadScene();
        _addMaxHealth = LoadMaxHealth();
        _addProjectileMax = LoadMaxProjectile();
        _addDmg = LoadMaxDmg();
        _addSpeed = LoadMaxSpeed();
    }

    public int LoadMaxSpeed()
    {
        int maxSpeed = PlayerPrefs.GetInt("AddSpeed", 0);
        return maxSpeed;
    }

    public void SaveMaxSpeed(int addMaxSpeed)
    {
        _addSpeed += addMaxSpeed;
        PlayerPrefs.SetInt("AddSpeed", _addSpeed);
    }

    public void SaveMaxDmg(int addMaxDmg)
    {
        _addDmg += addMaxDmg;
        PlayerPrefs.SetInt("AddDmg", _addDmg);
    }

    public int LoadMaxDmg()
    {
        int maxDmg = PlayerPrefs.GetInt("AddDmg", 0);
        return maxDmg;
    }

    public void SaveMaxProjectile(int addMaxProjectile)
    {
        _addProjectileMax += addMaxProjectile;
        PlayerPrefs.SetInt("MaxProjectileCount", _addProjectileMax);
    }

    public int LoadMaxProjectile()
    {
        int maxProjectile = PlayerPrefs.GetInt("MaxProjectileCount", 0);

        return maxProjectile;
    }

    public void SaveGold(int newGolds)
    {
        _collectedCoins = newGolds;
        PlayerPrefs.SetInt("CollectedCoins", _collectedCoins);
    }

    public int LoadGold()
    {
        int saveGolds = PlayerPrefs.GetInt("CollectedCoins", 0);

        return saveGolds;
    }

    public void SetGold(int gold)
    {
        _collectedCoins -= gold;
        SaveGold(_collectedCoins);
    }

    public void SaveMaxHealth(int addMaxHealth)
    {
        _addMaxHealth += addMaxHealth;
        PlayerPrefs.SetInt("MaxHealth", _addMaxHealth);
    }

    public int LoadMaxHealth()
    {
        int maxHealth = PlayerPrefs.GetInt("MaxHealth", 0);

        return maxHealth;
    }

    public void SaveScene(int actualSceneIndex)
    {
        _sceneIndex = actualSceneIndex;
        PlayerPrefs.SetInt("LevelProgress", _sceneIndex);
    }

    public int LoadScene()
    {
        int saveLevel = PlayerPrefs.GetInt("LevelProgress", 0);
        return saveLevel;
    }
}
