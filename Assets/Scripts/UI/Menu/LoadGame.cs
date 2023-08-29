using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public void LoadSaveGame()
    {
        int saveSceneIndex = _gameManager.LoadScene();

        SceneManager.LoadScene(saveSceneIndex);
    }
}
