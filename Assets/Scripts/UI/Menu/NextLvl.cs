using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLvl : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

  public void NextLvlLoad()
    {
        {  
            int nextSceneIndex =_gameManager.LoadScene();  

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
