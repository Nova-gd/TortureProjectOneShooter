using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    private int _collectedCoins;
    private int _sceneIndex;
    private int _addMaxHealth;

    public int CollectedCoins => _collectedCoins;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "1 lvl")
        {
            _collectedCoins = 0;
            PlayerPrefs.SetInt("CollectedCoins", _collectedCoins);

            _sceneIndex = 0;
            PlayerPrefs.SetInt("LevelProgress", _sceneIndex);

            _addMaxHealth = 0;
            PlayerPrefs.SetInt("MaxHealth", _sceneIndex);
        }
    }

    private void Start()
    {  
        _collectedCoins = LoadGold();
        _sceneIndex = LoadScene();
        _addMaxHealth = LoadMaxHealth();
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

    public void SaveScene()
    {
        _sceneIndex++;
        PlayerPrefs.SetInt("LevelProgress", _sceneIndex);
    }

    public int LoadScene()
    {
        int saveLevel = PlayerPrefs.GetInt("LevelProgress", 0);
        return saveLevel;
    }

    public void SetGold(int gold)
    {
        _collectedCoins -= gold;
        SaveGold(_collectedCoins);
    }
}
