using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;
using System;

public class RevardAds : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private int _reward = 2;

    //[SerializeField] private TMP_Text _rewardUI;
    //[SerializeField] private int _initialReward = 10;
    //[SerializeField] private float _rewardMultiplayer = 2;
    //private int _digistCount = 2;
    //private string[] _names = { "", "K", "M", "B", "T" };
    //private int amountReductionStart = 1000;
    //private readonly string _money = "$";
    //private readonly string _plus = "+";
    //private readonly string _rewardtypeAdClick = "rewartype-ad-click";
    //private readonly string _gold = "gold";
    //private readonly string _rewardText = "reward";
    //private readonly string _rewardButton = "reward button";
    //private int _adStep = 5;

    private Action _adOpened;
    private Action _adRewarded;
    private Action _adCloset;
    private Action<bool> _interstitialAdClose;
    private Action<string> _adErrorOccured;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _adOpened += OnAdOpen;
        _adRewarded += OnAdRewarded;
        _adCloset += OnAdClosed;  
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _adOpened -= OnAdOpen;
        _adRewarded -= OnAdRewarded;
        _adCloset -= OnAdClosed;
    }

    private void OnAdOpen()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0f;
        Time.timeScale = 0f;
    }

    private void OnAdRewarded()
    {
        //UpdateRewardValue();
        int playerGold = _gameManager.LoadGold();
        _gameManager.SaveGold(playerGold+_reward);
        gameObject.SetActive(false);
    }

    private void OnAdClosed()
    {
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        Time.timeScale = 1f;
    } 


    private void OnClick()
    {
        VideoAd.Show(_adOpened, _adRewarded, _adCloset, _adErrorOccured);

        //GameAnalytics.NewDesignEvent(_rewardtypeAdClick);

#if YANDEX_GAMES && !UNITY_EDITOR
                VideoAd.Show(_adOpened, _adRewarded, _adCloset, _adErrorOccured);
#endif
#if UNITY_EDITOR

#endif
    }
}
