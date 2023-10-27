using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class LevelLoaderView : MonoBehaviour
{
    public static LevelLoaderView Instance { get; private set; }

    [SerializeField] private Slider _bar;
    [SerializeField] private TMP_Text _percent;
    [SerializeField] private CanvasGroup _canvasGroup;

    private const float DonePercentDivider = 0.9f;
    private Coroutine _loadingCoroutine;
    private AsyncOperation _asyncOperation;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void ShowLoadingProgress(AsyncOperation asyncOperation)
    {
        _asyncOperation = asyncOperation;

        if (_loadingCoroutine == null)
        {
            _loadingCoroutine = StartCoroutine(LoadingScene());
        }
    }

    private IEnumerator LoadingScene()
    {
        float speed = 1f;

        Tween tween;

        if (_canvasGroup.alpha != 1)
        {
            tween = _canvasGroup.DOFade(1f, 0.2f);

            yield return tween.WaitForCompletion();
        }

        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;

        while (_asyncOperation.progress < DonePercentDivider)
        {
            float progress = _asyncOperation.progress / DonePercentDivider * 100;

            _bar.value = Mathf.MoveTowards(_bar.value, progress, speed * Time.deltaTime);
            _percent.text = ((int)(_bar.value)).ToString();
            yield return null;
        }

        //_percent.DOCounter((int)_bar.value, (int)_bar.maxValue, 1f);
        tween = _bar.DOValue(_bar.maxValue, 1f);
        yield return tween.WaitForCompletion();

        yield return new WaitForSeconds(1f);

        tween = _canvasGroup.DOFade(0f, 0.7f);

        yield return tween.WaitForCompletion();

        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        _bar.value = 0;
        _percent.text = "0";

        _loadingCoroutine = null;
    }
}

