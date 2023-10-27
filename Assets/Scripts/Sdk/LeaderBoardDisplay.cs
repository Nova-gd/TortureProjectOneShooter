using Agava.YandexGames;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class LeaderBoardDisplay : MonoBehaviour
{
    //[SerializeField] private TMP_Text _playerScore;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TMP_Text[] _ranks;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;
    [SerializeField] private string _leaderBoardName = "NewLeaderBoard1";
    [SerializeField] private TMP_Text _authorizationStatusText;
    [SerializeField] private TMP_Text _personalProfileDataPermissionStatusText;

    private float _userScoreTime;
    private readonly string _anonimusEn ="Anonimus";
    private readonly string _anonimusRu ="Аноним";
    private readonly string _anonimusTr ="Anonim";
    private string _playerName;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
        _userScoreTime = _gameManager.LoadTime();

        SetLeaderBoardScore();

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
                _playerName = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(_playerName))
                {
                    GetLanguage();
                }

                _leaderNames[i].text = _playerName;
                _scoreList[i].text = result.entries[i].formattedScore;
                _ranks[i].text = (i + 1).ToString();
            }
        },
        error =>
        {
            print(error);
        });
        //#endif
    }

    private void GetLanguage()
    {
        Locale currentSelectedLocale = LocalizationSettings.SelectedLocale;
        ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;

        if (currentSelectedLocale == availableLocales.GetLocale("en"))
        {
            _playerName = _anonimusEn;
        }
        else if (currentSelectedLocale == availableLocales.GetLocale("ru"))
        {
            _playerName = _anonimusRu;
        }
        else if (currentSelectedLocale == availableLocales.GetLocale("tr"))
        {
            _playerName = _anonimusTr;
        }
        else
        {
            _playerName = _anonimusEn;
        }


        //int ID = Agava.YandexGames.PlayerPrefs.GetInt("LocaleKey", 0);

        //if (ID == 0)
        //{
        //    name = _anonimusEn;
        //}
        //else if (ID == 1)
        //{
        //    name = _anonimusRu;
        //}
        //else if (ID == 2)
        //{
        //    name = _anonimusTr;
        //}
        //else
        //{
        //    name = _anonimusEn;
        //}
    }

    public void SetLeaderBoardScore()
    {
        Leaderboard.GetPlayerEntry(_leaderBoardName, OnSuccessCallback);
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {

        if (result == null || _gameManager.LoadTime() > result.score)
        {
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