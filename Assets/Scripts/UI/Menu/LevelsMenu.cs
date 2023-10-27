using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        PrintLevels();

        HideUndoneLvls();
    }
    private void PrintLevels()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            TextMeshProUGUI buttonText = _buttons[i].GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = (i + 1).ToString();
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI component not found on button " + _buttons[i].name);
            }
        }
    }

    private void HideUndoneLvls()
    {
        int actualLvl = _gameManager.LoadScene()+1;

        for (int i = 0; i < _buttons.Length; i++)
        {

            TextMeshProUGUI buttonText = _buttons[i].GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                int buttonNumber;
                if (int.TryParse(buttonText.text, out buttonNumber))
                {
                    Debug.Log("текущая кнопка" + buttonNumber);
                    Debug.Log("актуальный уровень" + actualLvl);

                    if (actualLvl >= buttonNumber)
                    {
                        Debug.Log("кнопка включена");
                        _buttons[i].gameObject.SetActive(true);

                        int levelToLoad = buttonNumber;

                        Debug.Log(levelToLoad + "уровня для загрузки");
                        _buttons[i].onClick.AddListener(() => LoadSaveGame(levelToLoad));
                    }
                    else
                    {
                        Debug.Log("кнопка выключена");
                        _buttons[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                Debug.LogWarning("Text component not found on button " + _buttons[i].name);
            }
        }
    }

    public void LoadSaveGame(int levelID)
    {
        
        SceneManager.LoadScene(levelID);
    }
}
