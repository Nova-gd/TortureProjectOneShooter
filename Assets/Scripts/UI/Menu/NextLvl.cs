using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLvl : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
  public void NextLvlLoad()
    {
        {
            Debug.Log("������� ������ �����: " + SceneManager.GetActiveScene().buildIndex);

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + _gameManager.LoadScene();

            
            Debug.Log("��������� ������ �����: " + nextSceneIndex);

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
