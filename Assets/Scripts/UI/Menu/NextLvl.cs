using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLvl : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

  public void NextLvlLoad()
    {
        {
            Debug.Log("Текущий индекс сцены: " + SceneManager.GetActiveScene().buildIndex);

            int nextSceneIndex =_gameManager.LoadScene();

            
            Debug.Log("Следующий индекс сцены: " + nextSceneIndex);

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
