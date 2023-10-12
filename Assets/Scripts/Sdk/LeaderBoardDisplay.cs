using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class LeaderBoardDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScore;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text[] _ranks;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;
    [SerializeField] private string _leaderBoardName = "LeaderBoard";
    [SerializeField] private TMP_Text _authorizationStatusText;
    [SerializeField] private TMP_Text _personalProfileDataPermissionStatusText;

    private float _userScoreTime;
    private readonly string _anonimus = "Anonimus";

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        _userScoreTime = _gameManager.LoadTime();

        StartCoroutine(Start());
        gameObject.SetActive(false);
    }

    public void OpenLeaderboard()
    {
        StartCoroutine(Start());

        Leaderboard.GetEntries(_leaderBoardName, 
        result =>
        {

        },
        error =>
        {
            //_logInPanel.Show();
        });
        //#endif
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        //yield break;
#endif
        yield return YandexGamesSdk.Initialize();

        while (true)
        {
            _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

            if (PlayerAccount.IsAuthorized)
            {
                _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
            }
            else
            {
                _personalProfileDataPermissionStatusText.color = Color.red;
            }

            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}