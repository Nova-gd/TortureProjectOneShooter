using Agava.YandexGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitSdk : MonoBehaviour
{
    private void Start()
    {  
        StartCoroutine(Init());
    }    

    private IEnumerator Init()
    {
        //yield return new WaitForSeconds(1);

        yield return YandexGamesSdk.Initialize();

        SceneManager.LoadScene("StartScreen");
    }
}
