using UnityEngine;
using UnityEngine.UI;

public class ShopGoldCount : MonoBehaviour
{
    [SerializeField] private Text _goldCountText;
    [SerializeField] private GameManager _playerGolds;

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
        int totalGold = _playerGolds.CollectedCoins;
        _goldCountText.text = totalGold.ToString();
    }
}
