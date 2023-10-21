using UnityEngine;

public class PlayerGolds : MonoBehaviour
{
    [SerializeField] private int _golds = 0;
    [SerializeField] private GameManager _gameManager;

    public int Golds => _golds;

    private void Start()
    {
        _golds = _gameManager.LoadGold();
    } 

    public void AddGold()
    {
        _golds++;
        _gameManager.SaveGold(_golds);
    }
}
