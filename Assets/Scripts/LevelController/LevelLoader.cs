using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string GameLogic = nameof(GameLogic);
    private string _sceneToLoad;
    private const float DonePercentDivider = 0.9f;
    private Coroutine _loadingCoroutine;

    public void RestartLevel()
    {
        _sceneToLoad = SceneManager.GetActiveScene().name;

        if (_loadingCoroutine == null)
            _loadingCoroutine = StartCoroutine(LoadingScene());
    }

    public void LoadLevel()
    {
        //_sceneToLoad = GameProgressHolder.Instance.GetNextSceneName();

        if (_loadingCoroutine == null)
            _loadingCoroutine = StartCoroutine(LoadingScene());
    }

    public void LoadLevel(string sceneToLoad)
    {
        _sceneToLoad = sceneToLoad;

        if (_loadingCoroutine == null)
            _loadingCoroutine = StartCoroutine(LoadingScene());
    }

    private IEnumerator LoadingScene()
    {
        yield return new WaitForEndOfFrame();

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);
        asyncOperation.allowSceneActivation = false;

        LevelLoaderView.Instance.ShowLoadingProgress(asyncOperation);

        SceneManager.LoadScene(GameLogic, LoadSceneMode.Additive);

        while (asyncOperation.progress < DonePercentDivider)
        {
            yield return null;
        }

        yield return null;

        asyncOperation.allowSceneActivation = true;

        _loadingCoroutine = null;
    }
}
