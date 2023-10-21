using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCount : MonoBehaviour    
{
    [SerializeField] private TextMeshProUGUI _levelCountText;

    private void Start()
    {
        UpdateCountText();
    }

    private void Update()
    {
        UpdateCountText();
    }


    private void UpdateCountText()
    {
        int actualSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _levelCountText.text = actualSceneIndex.ToString();
    }
}
