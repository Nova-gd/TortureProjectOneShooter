using UnityEngine;
using UnityEngine.UI;

public class GoldCount : MonoBehaviour
{
    [SerializeField] private Text _goldCountText;
    [SerializeField] private PlayerGolds _playerGolds; 

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
        int totalGold = _playerGolds.Gold;
        _goldCountText.text = totalGold.ToString();
    } 
}
