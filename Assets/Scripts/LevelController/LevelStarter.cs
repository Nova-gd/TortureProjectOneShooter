using UnityEngine;
using TMPro;

public class LevelStarter : MonoBehaviour
{
    //[SerializeField] private PlayerPhaseSwitcher _phaseSwitcher;
    [SerializeField] private StartButtonUI _startButtonUI;
    //[SerializeField] private CanvasGroupView _mainUI;
    //[SerializeField] private CanvasGroupView _gameUI;
    //[SerializeField] private CanvasGroupView _walletUI;
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private TMP_Text _songName;

    private void Awake()
    {
        //_gameUI.SetVisibilityFast(false);
        //_mainUI.SetVisibilityFast(true);

        //GameProgressHolder.Instance.UpdateCurrentSceneData();
    }

    private void OnEnable()
    {
        _startButtonUI.GameStarted += OnButtonClick;
    }

    private void OnDisable()
    {
        _startButtonUI.GameStarted -= OnButtonClick;
    }

    private void Start()
    {
        //_levelName.text = GameProgressHolder.Instance.CurrentSceneData.Name;
        //_songName.text = GameProgressHolder.Instance.CurrentSceneData.Name;
    }

    public void OnButtonClick()
    {
        _startButtonUI.GameStarted -= OnButtonClick;
        //_phaseSwitcher.StartSearchingBlock();

        //_gameUI.SetVisibilityFast(true);
        //_mainUI.gameObject.SetActive(false);
        //_walletUI.SetVisibility(false);
    }
}