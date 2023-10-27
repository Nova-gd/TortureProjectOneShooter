using UnityEngine;

public class LevelEnder : MonoBehaviour
{
    //[SerializeField] private Points _levelPoints;
    [SerializeField] private LevelCompleteScreen _completeScreen;
    [SerializeField] private LevelLoader _levelLoader;
    //[SerializeField] private CatFinisher _catFinisher;
    //[SerializeField] private CanvasGroupView _walletUI;
    //[SerializeField] private CanvasGroupView _gameUI;

    private void OnEnable()
    {
        _completeScreen.LevelEnded += OnLevelEnd;
        //_catFinisher.Finished += OnCatFinished;
    }

    private void OnDisable()
    {
        _completeScreen.LevelEnded -= OnLevelEnd;
        //_catFinisher.Finished -= OnCatFinished;
    }

    private void OnLevelEnd()
    {
        //GameProgressHolder.Instance.UpdateProgress(_levelPoints.Amount);
        _levelLoader.LoadLevel();
    }

    private void OnCatFinished()
    {
        //_walletUI.SetVisibilityFast(true);
        //_gameUI.SetVisibility(false);
    }
}