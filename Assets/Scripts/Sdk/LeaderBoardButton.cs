using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LeaderBoardDisplay _leaderBoardDisplay;
    [SerializeField] private Button _closeButton;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _closeButton.onClick.AddListener(OnCloseClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _closeButton.onClick.RemoveListener(OnCloseClick);
    }

    private void OnCloseClick() => Hide();

    private void OnClick()
    {
        if (_leaderBoardDisplay.gameObject.activeSelf)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Show()
    {
        _leaderBoardDisplay.gameObject.SetActive(true);
        _leaderBoardDisplay.OpenLeaderboard();
    }
    private void Hide() => _leaderBoardDisplay.gameObject.SetActive(false);
}
