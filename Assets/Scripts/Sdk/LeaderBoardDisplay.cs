using Agava.YandexGames;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.WebGL;

public class LeaderBoardDisplay : MonoBehaviour
{
    //[SerializeField] private TMP_Text _playerScore;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text[] _ranks;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;
    [SerializeField] private string _leaderBoardName = "NewLeaderBoard";
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
            int leaderNumber = result.entries.Length >= _leaderBoardName.Length ? _leaderBoardName.Length : result.entries.Length;

            for (int i = 0; i < leaderNumber; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    name = _anonimus;
                }

                _leaderNames[i].text = name;
                _scoreList[i].text = result.entries[i].formattedScore;
                _ranks[i].text = result.entries[i].ToString();
            }
        },
        error =>
        {
            print(error);
        });
        //#endif
    }

    public void SetLeaderBoardScore()
    {
        Leaderboard.GetPlayerEntry(_leaderBoardName, OnSuccessCallback);
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        print("Зашли в калбек до if");

        if (result == null || _gameManager.LoadTime() > result.score)
        {
            print("Зашли в if");
            print(_gameManager.LoadTime());
            Leaderboard.SetScore(_leaderBoardName, (int)_gameManager.LoadTime());
        }
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
